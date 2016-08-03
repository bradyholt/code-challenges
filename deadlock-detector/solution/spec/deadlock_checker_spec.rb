require_relative '../lib/deadlock_checker'

describe DeadlockChecker do
  describe ".generate_graph" do
    it "points edge to process on a [H]old" do
      dep = ProcessDependency.new(1,2,"H")
      process_dependencies = [ dep ]
      graph = DeadlockChecker.generate_graph(process_dependencies)
      edges = graph.vertex_edges(DeadlockChecker::RESOURCE_NAME_PREFIX + dep.resource_id.to_s)
      expect(edges).to contain_exactly(DeadlockChecker::PROCESS_NAME_PREFIX + dep.process_id.to_s)
    end

    it "points edge to resource on a [W]ait" do
      dep = ProcessDependency.new(1,2,"W")
      process_dependencies = [ dep ]
      graph = DeadlockChecker.generate_graph(process_dependencies)
      edges = graph.vertex_edges(DeadlockChecker::PROCESS_NAME_PREFIX + dep.process_id.to_s)
      expect(edges).to contain_exactly(DeadlockChecker::RESOURCE_NAME_PREFIX + dep.resource_id.to_s)
    end
  end

  describe ".deadlocked?" do
    it "detects a deadlock" do
      process_dependencies = []
      input = [
        #this is a deadlock!
        ["1","1","H"],
        ["1","2","W"],
        ["2","1","W"],
        ["2","2","H"]
      ]

      input.each do |i|
        process_dependencies << ProcessDependency.new(*i)
      end

      is_deadlocked = DeadlockChecker.deadlocked?(process_dependencies)
      expect(is_deadlocked).to be true
    end

    it "does not report false deadlock" do
      process_dependencies = []
      input = [
        #not a deadlock!
        ["1","1","H"],
        ["1","2","W"]
      ]

      input.each do |i|
        process_dependencies << ProcessDependency.new(*i)
      end

      is_deadlocked = DeadlockChecker.deadlocked?(process_dependencies)
      expect(is_deadlocked).to be false
    end
  end
end
