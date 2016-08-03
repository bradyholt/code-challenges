require_relative '../lib/stack'

describe Stack do
  before :each do
    @stack = Stack.new
  end

  describe "#push" do
    it "adds items to stack" do
      5.times { @stack.push(1) }
      expect(@stack.length).to eq 5
    end
  end

  describe "#pop" do
    it "returns item from top of stack" do
      5.times do |i| #i starts at 0
        @stack.push(i+1)
      end
      expect(@stack.pop).to eq 5
    end
    it "does remove item from from top of stack" do
      5.times do |i|
        @stack.push(i+1)
      end
      @stack.pop
      expect(@stack.pop).to eq 4
    end
  end

  describe "#peek" do
    it "returns top of stack" do
      5.times do |i| #i starts at 0
        @stack.push(i+1)
      end
      expect(@stack.peek).to eq 5
    end
    it "does not remove item from top of stack" do
      5.times do |i|
        @stack.push(i+1)
      end
      @stack.peek
      expect(@stack.pop).to eq 5
    end
  end

  describe "#any?" do
    it "returns true if any items present" do
      @stack.push("new_item")
      expect(@stack.any?).to be true
    end

    it "returns false if empty" do
      expect(@stack.any?).to be false
    end
  end
end
