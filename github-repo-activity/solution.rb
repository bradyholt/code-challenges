require 'open-uri'
require 'time'
require 'yajl'
require 'optparse'

#GitHub changed to Events API data format on 2015-01-01
EVENTS_API_CUTOVER_DATE = Time.parse('2015-01-01')

def parse_options(default_options)
	options = default_options
	optparse = OptionParser.new do |opt|
		opt.banner = "Usage: gh_repo_stats.rb [options]"
		opt.on('--after DATETIME', "After date [default=#{options[:after]}]") { |o| options[:after] = Time.parse(o) }
		opt.on('--before DATETIME', "Before date [default=#{options[:before]}") { |o| options[:before] = Time.parse(o) }
		opt.on('--event EVENT_NAME', "Event name [default=#{options[:event]}]") { |o| options[:event] = o }
		opt.on('-n', '--count COUNT', "Limit results to count [default=#{options[:count]}]") { |o| options[:count] = o.to_i }
		opt.on('-h', '--help', 'Display this screen') do
			puts opt
			exit
		end
	end.parse!

	options
end

def get_slices(after, before) 
	seconds_diff = (before.to_i - after.to_i)
	hours_diff = (seconds_diff / 3600);
	
	slices = []
	for slice_hour in 0..hours_diff
		slices << (after + (slice_hour*60*60))	 	
	end

	slices
end

def download_slices_get_counts(hour_slices, after, before, event_name)
	counts = Hash.new 0

	print "[Downloading data"
	hour_slices.each do |slice|
		print "." #status feeback

		#Base off of UTC for consistent handling
		slice.utc 

		if (slice < EVENTS_API_CUTOVER_DATE)
			#Timeline API recorded times and indexed times in UTC-7 so we need to adjust slice
			slice -= (7*60*60)
		end

		slice_formatted = slice.strftime('%Y-%m-%d-%-H') #Hour format is not left padded
		url = "http://data.githubarchive.org/#{slice_formatted}.json.gz"
		gz = open(url)
		js = Zlib::GzipReader.new(gz).read
		
		#Read the events one at a time
		Yajl::Parser.parse(js, :symbolize_keys => true) do |event|			
			unless event[:type] != event_name
				created_at_time = Time.parse(event[:created_at])
				if (created_at_time > after && created_at_time < before)
					#Repo name location is different in Timeline API format
					if (created_at_time < EVENTS_API_CUTOVER_DATE)
						repo_name = "#{event[:repository][:owner]}/#{event[:repository][:name]}" 
					else
						repo_name = event[:repo][:name]
					end
				
					counts[repo_name] += 1
				end
			end
		end
	end

	puts "done!]"

	counts
end

options = parse_options({
	#defaults
	:after => Time.now - (2*60*60),  #2 hours ago
	:before => Time.now - (1*60*60), #1 hour ago
	:event => 'PushEvent', 
	:count => 10
})

hour_slices = get_slices(options[:after], options[:before])
counts = download_slices_get_counts(hour_slices, options[:after], options[:before], options[:event])

if counts.count == 0
	puts "No #{options[:event]} events occured between #{options[:after]} and #{options[:before]}!"
else
	results = counts.sort_by { |k, v| -v }.first(options[:count])
	results.each {|x| 
		puts "#{x[0]} - #{x[1]} events" 
	}
end

=begin

Notes:

- I am filtering the data based on the event command line option passed in (line 54 above) so if additional types are added, this program should handle them automatically.
- The biggest impact to performance would be the after/before date range size. Since the data is segmented into hourly files, the wider the gap, the more files that will have to be downloaded. To help with this, I could utilize a queue and multiple threads to work through the data slices within the download_slices method. Also, the size of the JSON records in the data files affects performance since I am parsing each record fully. Using a different strategy (i.e. regex) to filter records based on event/time could potentially yield better performance.
- To handle different reporting formats I could convert the results into objects and then rely upon a gem like ActiveSupport to format to JSON, XML, etc. based on a command line option passed in.
- If I had to implement using only one gem, I would use yajl since it quickly parses JSON, one record at a time without requiring the entire hour slice to be loaded into memory at one time. Implementing this gem's logic would take some effort and I feel the benefit it provides is important to this program.

=end