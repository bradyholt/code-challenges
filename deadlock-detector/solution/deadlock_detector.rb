require_relative 'lib/process_dependency'
require_relative 'lib/deadlock_checker'

# deadlock_detector - Reads an input file as a command line argument
#   and writes GOOD or BAD on the standard output
#   depending on the state (deadlocked?) of the input file.

data_file = ARGV[0]
raise "Input data file must be specified as first argument" unless data_file

# Read input data file lines and construct an array of ProcessDependency.
# Data file is expected to be in format (PID,RID,W/H); for example:
#   1,1,H
#   1,2,W

dependencies = []
File.readlines(data_file).each do |line|
  parts = line.chomp.split(",")
  dependencies << ProcessDependency.new(*parts)
end

is_deadlocked = DeadlockChecker.deadlocked?(dependencies)
puts is_deadlocked ? "BAD" : "GOOD"
