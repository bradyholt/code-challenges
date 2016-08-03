public class Node {
  public int Value {get;set}
  public Node Next {get;set;}
  public Node Random {get;set;}
}

//step 1: deep copy the node and keep track of node/copy correlations
public void CopyNode(Node node, Dictionary<Node, Node> nodeCopyCorrelations){
  Node nodeCopy = new Node(){Value = node.Value};
  nodeCopyCorrelations.Add(node, nodeCopy);
  
  if (node.Next != null) {
    Node nextCopy = CopyNode(node.Next, nodeCopyCorrelations);
    nodeCopy.Next = nextCopy;
  }
  
  return nodeCopy;
}

//step 2: set Random property on node copies from node/copy correlations
public void SetRandoms(Node node, Dictionary<Node, Node> nodeCopyCorrelations){
  Node nodeCopy = nodeCopyCorrelations[node];
  nodeCopy.Random = nodeCopyCorrelations[node.Random];
  
  if (node.Next != null) {
    SetRandoms(node.Next, nodeCopyCorrelations);
  }
}