namespace Assignment2;

public class Node<T>
{
    public T value;
    public List<Node<T>> children = new List<Node<T>>();
    public Node(T value)
    {
        this.value = value;
    }

    public void AddChild(Node<T> item)
    {
        children.Add(item);
    }
    
    public void AddChildren(List<Node<T>> items)
    {
        foreach (Node<T> item in items)
        {
            children.Add(item);
        }
    }

    public override string ToString()
    {
        return $"Node of value: {value}";
    }
    
    public static Node<int>? BFS(Node<int> start, int target)
    {
        Queue<Node<int>> BFS_Q = new Queue<Node<int>>();
        BFS_Q.Enqueue(start);
        int step = 1;
        while (BFS_Q.Count > 0)
        {
            Node<int> current = BFS_Q.Dequeue();
            Console.WriteLine($"Step {step}: Dequeued {current.value}");
            step++;
            if (current.value == target)
            {
                //exit if found
                return current;
            }

            foreach (Node<int> child in current.children)
            {
                BFS_Q.Enqueue(child);
            }
        }
        return null;
    }

    public static Node<int>? DFS(Node<int> start, int target)
    {
        // https://youtu.be/s3C4h6nSNis
        return null;
    }
}