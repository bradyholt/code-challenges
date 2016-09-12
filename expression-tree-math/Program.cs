public class ExpressionTree {
    private final Node root;

    public ExpressionTree(Node root) {
        this.root = root;
    }
    
    public String printExpression() {
        // implement    
    }
    
    public doMath(parentNode, node) {
        
        
      if (node.child1.child1 == null) {
          node.print();
      } else {
          doMath(node.child1);
           doMath(node.child1);
          Console.WriteLine(doMath(node, node.child1) + node.nalue + doMath(node, node.child2));
      }
        
        
        
        if (node.child1 == null && node.child2 == null) {
            Console.WriteLine(node.child1 + value + node.child2);
        } else {
            Console.Writr
            doMath(node.child1);
            doMath(node.child2);
        
        }
    } 
}

public class Node {
    string value;
    Node child1;
    Node child2;
    
    public String print() {
        // left
        // self
        //right
        String s = "";
        
        bool wrapInParen = false;
        
        string[] orderOfOperations = new string[] { "*", "/", "+", "-"};
        if (orderOfOperations.indexOf(value) < orderOfOperations.indexOf(child1.value)) {
           wrapInParen = true;
        }
        
        if (wrapInParen){ 
          s += "(";
        }
        s += child1.print();
        s += value;
        s += child2.print();
        
        if (wrapInParen){ 
          s += ")";
        }
        
        return s;
        
    }
}



