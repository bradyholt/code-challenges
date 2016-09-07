using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Node node1 = new Node() { Value = "1" };
            Node node2 = new Node() { Value = "2" };
            Node node3 = new Node() { Value = "3" };
            node1.Next = node2;
            node2.Next = node3;

            Node previous = null;
            Node current = node1;

            while (current != null) {
                Node next = current.Next;
                current.Next = previous;

                previous = current;
                current = next;
            }

            current = previous;
            while (current != null) {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }
    }

    public class Node {
        public string Value {get;set;}
        public Node Next {get;set;}
    }
}