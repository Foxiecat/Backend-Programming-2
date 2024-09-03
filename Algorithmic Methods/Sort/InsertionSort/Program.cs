namespace InsertionSort;
using static SortUtilities.SortUtilities;

class Program
{
    static void Main(string[] args)
    {
        int[] theNumbers = { 15, 123, 157, 56, 4, 171, 188, 42, 219, 107, 139, 253, 91, 23, 8, 204, 72, 148, 234, 16 };
        
        PrintArray(theNumbers);

        Console.WriteLine("\n");
        theNumbers = Sort(theNumbers);
        
        PrintArray(theNumbers);
        
        Console.WriteLine("Sorted: " + IsSorted(theNumbers));
    }

    private static int[] Sort(int[] numbers)
    {
        for (int index = 0; index < numbers.Length - 1; index++)
        {
            for (int secondIndex = index + 1; secondIndex > 0; secondIndex--)
            {
                if (numbers[secondIndex - 1] > numbers[secondIndex])
                {
                    int temp = numbers[secondIndex - 1];
                    numbers[secondIndex - 1] = numbers[secondIndex];
                    numbers[secondIndex] = temp;
                }
            }
        }
        
        return numbers;
    }
}