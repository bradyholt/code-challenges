class ProcessDependency
  # Container for single process dependency sourced from input file

  HOLD_CHARACTER = "H"
  attr_accessor :process_id, :resource_id, :wait_hold

  def initialize(process_id, resource_id, wait_hold)
    raise ArgumentError, 'process_id is required' unless !process_id.to_s.empty?
    @process_id = process_id

    raise ArgumentError, 'resource_id is required' unless !resource_id.to_s.empty?
    @resource_id = resource_id

    raise ArgumentError, 'W/H value (#{wait_hold}) is invalid' unless (wait_hold =~ /W|H/) == 0
    @wait_hold = wait_hold
  end

  def hold?
    @wait_hold == HOLD_CHARACTER
  end
end
