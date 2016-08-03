require_relative '../lib/process_dependency'

describe ProcessDependency do
  describe "#initialize" do
    it "throws exception if ProcessId, ResourceId or W/H is missing" do
      expect { d = ProcessDependency.new("1") }.to raise_error(ArgumentError)
    end

    it "throws exception if W/H is not valid " do
      expect { d = ProcessDependency.new("1","2","1") }.to raise_error(ArgumentError)
    end

    it "sets members as expected" do
      d = ProcessDependency.new(2,4,"H")
      expect(d.process_id).to eq 2
      expect(d.resource_id).to eq 4
      expect(d.wait_hold).to eq "H"
    end
  end

  describe "#hold" do
    it "is true when H" do
      d = ProcessDependency.new("2","4","H")
      expect(d.hold?).to be true
    end

    it "is false when W" do
      d = ProcessDependency.new("1","2","W")
      expect(d.hold?).to be false
    end
  end
end
