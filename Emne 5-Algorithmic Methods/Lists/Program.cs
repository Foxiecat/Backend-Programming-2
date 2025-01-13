namespace Lists;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new();
        numbers.Add(4);
        numbers.Add(8);
        numbers.Add(15);
        numbers.Add(16);
        numbers.Add(23);
        numbers.Add(42);

        numbers.Remove(numbers.Last());

        foreach (int number in numbers)
        {
            Console.WriteLine(number);
            
        }
    }
}