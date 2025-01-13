namespace QueuesAndStacks;

class Program
{
    static void Main(string[] args)
    {
        // Stacks
        Stack<string> cars = new();
        
        cars.Push("Ford");
        cars.Push("Toyota");
        cars.Push("Fiat");
        cars.Push("Nissan");
        cars.Push("Tesla");

        while (cars.Count > 2)
        {
            string car = cars.Pop();
            Console.WriteLine(car);
        }
        
        cars.Push("BMW");
        while (cars.Count > 0)
        {
            string car = cars.Pop();
            Console.WriteLine(car);
        }

        
        // Queues
        Queue<string> rema = new();
        Queue<string> wm = new();
        
        rema.Enqueue("Milk");
        rema.Enqueue("Sugar");
        rema.Enqueue("Wine");
        rema.Enqueue("Bread");
        rema.Enqueue("Frozen Pizza");

        while (rema.Count > 0)
        {
            if (rema.Peek() != "Wine")
            {
                Console.WriteLine(rema.Dequeue());
            }
            else wm.Enqueue(rema.Dequeue());
        }

        Console.WriteLine("wines: " + wm.Count);
    }
}