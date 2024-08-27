using System.Collections;

namespace StackExample;

class Program
{
    static void Main(string[] args)
    {
        Stack<int> stack = new();
        stack.Push(4);
        stack.Push(8);
        stack.Push(15);
        stack.Push(42);
        stack.Push(23);
        stack.Push(16);

        Queue<int> queue = new();
        queue.Enqueue(4);
        queue.Enqueue(8);
        queue.Enqueue(15);
        queue.Enqueue(42);
        queue.Enqueue(23);
        queue.Enqueue(16);
        
        HashSet<int> hashSet =
        [
            4,
            8,
            15,
            42,
            23,
            16
        ];

        hashSet.Contains(17);


    }
}