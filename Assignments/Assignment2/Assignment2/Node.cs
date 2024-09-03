namespace Assignment2;

public class Node<T>
{
    private T _value;
    private List<Node<T>> _children = [];
    public Node(T value)
    {
        _value = value;
    }

    public void AddChild(Node<T> item)
    {
        _children.Add(item);
    }
    
    public void AddChildren(List<Node<T>> items)
    {
        foreach (Node<T> item in items)
        {
            _children.Add(item);
        }
    }

    public override string ToString()
    {
        return $"Node of value: {_value}";
    }
    
    public static Node<int>? BreadthFirstSearch(Node<int> start, int target)
    {
        Queue<Node<int>> bfsQ = new();
        bfsQ.Enqueue(start);
        int step = 1;
        while (bfsQ.Count > 0)
        {
            Node<int> current = bfsQ.Dequeue();
            Console.WriteLine($"Step {step}: Dequeued {current._value}");
            step++;
            if (current._value == target)
            {
                // Exit if target is found
                return current;
            }

            foreach (Node<int> child in current._children)
            {
                bfsQ.Enqueue(child);
            }
        }
        return null;
    }

    public static Node<int>? DepthFirstSearch(Node<int> start, int target)
    {
        Stack<Node<int>> depthFirstSearchQuery = new();
        depthFirstSearchQuery.Push(start);
        int step = 1;

        while (depthFirstSearchQuery.Count > 0)
        {
            Node<int> current = depthFirstSearchQuery.Pop();
            Console.WriteLine($"Step {step}: Popped {current._value}");
            step++;

            if (current._value == target)
            {
                // Exit if target is found
                return current;
            }
            
            for (int index = current._children.Count - 1; index >= 0; index--)
            {
                depthFirstSearchQuery.Push(current._children[index]);
            }
        }
        
        return null;
    }
}