namespace Assignment2;

class Program
{
    static void Main(string[] args)
    {
        Node<int> n4 = new Node<int>(4); 
        Node<int> n8 = new Node<int>(8); 
        Node<int> n15 = new Node<int>(15); 
        Node<int> n16 = new Node<int>(16); 
        Node<int> n23 = new Node<int>(23); 
        Node<int> n42 = new Node<int>(42); 
        Node<int> n56 = new Node<int>(56); 
        Node<int> n72 = new Node<int>(72); 
        Node<int> n91 = new Node<int>(91); 
        Node<int> n107 = new Node<int>(107); 
        Node<int> n123 = new Node<int>(123); 
        Node<int> n139 = new Node<int>(139); 
        Node<int> n148 = new Node<int>(148); 
        Node<int> n157 = new Node<int>(157); 
        Node<int> n171 = new Node<int>(171); 
        Node<int> n188 = new Node<int>(188); 
        Node<int> n204 = new Node<int>(204); 
        Node<int> n219 = new Node<int>(219); 
        Node<int> n234 = new Node<int>(234); 
        Node<int> n253 = new Node<int>(253);

        n107.AddChild(n42);
        n107.AddChild(n157);

        n42.AddChild(n16);
        n42.AddChild(n72);

        n157.AddChild(n139);
        n157.AddChild(n204);

        n16.AddChild(n8);
        n16.AddChild(n23);

        n72.AddChild(n56);
        n72.AddChild(n91);

        n139.AddChild(n123);
        n139.AddChild(n148);

        n204.AddChild(n188);
        n204.AddChild(n234);

        n8.AddChild(n4);
        n8.AddChild(n15);

        n188.AddChild(n171);

        n234.AddChild(n219);
        n234.AddChild(n253);
        
        Console.WriteLine("Tree has been built...");

        Console.WriteLine("\nBreadth First Search:");
        Console.WriteLine(Node<int>.BFS(n107, 72));
        
        Console.WriteLine("\nDepth First Search:");
        Console.WriteLine(Node<int>.DFS(n107, 72));
    }
}