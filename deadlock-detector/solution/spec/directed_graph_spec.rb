require_relative '../lib/directed_graph'

describe DirectedGraph do
  before :each do
    @graph = DirectedGraph.new
  end

  describe "#add_vertex" do
    it "adds items to graph" do
      5.times do |i| #i starts at 0
        @graph.add_vertex(i)
      end
      expect(@graph.vertex_count).to eq 5
    end
  end

  describe "#add_vertices" do
    it "adds multiple items to graph at once" do
      @graph.add_vertices([1,2,3,4,5])
      expect(@graph.vertex_count).to eq 5
    end
  end

  describe "#add_edge" do
    it "adds new edge" do
      @graph.add_vertices(["1", "2"])
      @graph.add_edge("1", "2")
      expect(@graph.vertex_edges("1").length).to eq 1
    end

    it "adds edges in correct direction" do
      @graph.add_vertices(["1", "2", "3"])
      @graph.add_edge("1", "2")
      @graph.add_edge("2", "1")
      @graph.add_edge("2", "3")
      expect(@graph.vertex_edges("1")).to contain_exactly("2")
      expect(@graph.vertex_edges("2")).to contain_exactly("1", "3")
    end
  end

  context "when cycle exists" do
    it "calls A>A a cycle" do
      @graph.add_vertices(["A"])
      @graph.add_edge("A", "A")
      expect(@graph.cycle_exists?).to be true
    end

    it "calls A>B,B>C,C>D,D>A a cycle" do
      @graph.add_vertices(["A", "B", "C", "D"])
      @graph.add_edge("A", "B")
      @graph.add_edge("B", "C")
      @graph.add_edge("C", "D")
      @graph.add_edge("D", "A")
      expect(@graph.cycle_exists?).to be true
    end
  end

  context "when cycle does not exists" do
    it "does not call A>B,A>C cycle" do
      @graph.add_vertices(["A", "B", "C"])
      @graph.add_edge("A", "B")
      @graph.add_edge("A", "C")
      expect(@graph.cycle_exists?).to be false
    end

    it "does not call A>B,A>C,C>B a cycle" do
      @graph.add_vertices(["A", "B", "C"])
      @graph.add_edge("A", "B")
      @graph.add_edge("A", "C")
      @graph.add_edge("C", "B")
      expect(@graph.cycle_exists?).to be false
    end
  end

end
