require_relative 'stack'

class DirectedGraph
  # A simple implementation of a directed graph (vertices connected together by directional edges)

  def initialize
    @vertices = []
    @edges = Hash.new # Edges are stored by source of directed edge (for A>B,A>C: @edges[A] == [B,C])
  end

  def add_vertex(vertex)
    if !@vertices.include? vertex
      @vertices << vertex
      @edges[vertex] = []
    end
  end

  def add_vertices(vertices)
    vertices.each do |v|
      add_vertex(v)
    end
  end

  def vertex_count
    @vertices.length
  end

  def add_edge(from_vertex, to_vertex)
    @edges[from_vertex] << to_vertex
  end

  def vertex_edges(vertex)
    @edges[vertex]
  end

  def edge_count
    @edges.values.reduce(0) {|count, n| count + n.length }
  end

  def cycle_exists?
    # Determine if a cycle (loop) exists in this directed graph
    # Approach: Use a Depth First Search (DPS) algorithm with WHITE/GRAY/BLACK flagging.

    # WHITE == not visited
    # GRAY  == visited before, edge targets still being traversed (cycle candidate)
    # BLACK == all edge targets traversed (no cycle)

    cycle_found = false
    visited_vertices = Hash.new(:white)
    vertex_stack = Stack.new

    #Start with first vertex
    vertex_stack.push(@vertices[0])

    while vertex_stack.any? do
        top = vertex_stack.peek
        case visited_vertices[top]
        when :white
          # Mark GRAY while we are traversing edge targets
          visited_vertices[top] = :gray

          edge_targets = @edges[top]
          edge_targets.each do |target|
            if visited_vertices[target] == :gray
              # CYCLE FOUND! - top has an edge pointing to a GRAY edge which means there is a cycle
              cycle_found = true
              break
            else
              #Add to stack so we can continue searching 'down'
              vertex_stack.push(target)
            end
          end
        when :gray
          # This is a GRAY vertex we have seen before so mark it
          # BLACK and pop it from the stack because no cycle has been found on it
          visited_vertices[top] = :black
          vertex_stack.pop
        when :black
          # We have seen this vertex before but it is BLACK and all clear
          vertex_stack.pop
        end

        break if cycle_found
      end

      cycle_found
    end

    def to_s
      description = "Vertex Count: #{@vertices.length}, Edge Count: #{edge_count}\n"
      @edges.each do |vertex, edges|
        description = description + " #{vertex} => #{edges.join(",")}\n"
      end
      description
    end

  end
