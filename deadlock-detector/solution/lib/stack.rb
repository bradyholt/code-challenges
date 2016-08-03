class Stack
  # Wrapper around an array to abstract out a Stack data structure

  def initialize
    @elements = []
  end

  def length
    @elements.length
  end

  def push(item)
    @elements.push item
  end

  def pop
    @elements.pop
  end

  def peek
    # Look but don't pop
    @elements[-1]
  end

  def any?
    @elements.length > 0
  end
end
