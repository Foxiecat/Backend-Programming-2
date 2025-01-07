namespace LinkedListSolution;

public class Node<T>(T data)
{
    public T Data = data;
    public Node<T>? Next;

    public override string? ToString()
    {
        return Next != null ? Data.ToString() + " " + Next.ToString() : Data.ToString();
    }
}