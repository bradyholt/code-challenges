require_relative 'directed_graph'

module DeadlockChecker
  # Given an array of ProcessDepencency, will determine if deadlocked

  PROCESS_NAME_PREFIX = "P"
  RESOURCE_NAME_PREFIX = "R"

  def DeadlockChecker.deadlocked?(dependencies)
    graph = generate_graph(dependencies)
    graph.cycle_exists?
  end

  def DeadlockChecker.generate_graph(dependencies)
    graph = DirectedGraph.new
    dependencies.each do |d|
      process_name = PROCESS_NAME_PREFIX + d.process_id.to_s
      resource_name = RESOURCE_NAME_PREFIX + d.resource_id.to_s

      #Add process and resource as vertices in the graph
      graph.add_vertices([process_name, resource_name])

      if d.hold?
        #Add edge directed toward the process vertex if a [H]old
        graph.add_edge(resource_name, process_name)
      else
        #Add edge directed toward the resource vertex if a [W]ait.
        graph.add_edge(process_name, resource_name)
      end
    end

    graph
  end
end
