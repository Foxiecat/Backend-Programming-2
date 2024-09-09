namespace Quicksort;
using static SortUtilities.SortUtilities;

class Program
{
    static void Main(string[] args)
    {
        // 10 million numbers:
        int[] theNumbers = CreateRandomArray(10000000, 1, 10000000);
        
         theNumbers = Quicksort(theNumbers);
         //PrintArray(theNumbers);

        Console.WriteLine("Sorted: " + IsSorted(theNumbers));
    }

    
    private static int[] Quicksort(int[] input)
    {
        if (input.Length <= 1)
            return input;
        
        // - Pick an element as a pivot
        int pivot = input[0];

        int[] lesser = new int[input.Length];
        int lesserCount = 0;
        int[] greater = new int[input.Length];
        int greaterCount = 0;
        
        
        // - Partition the array around the pivot
        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] <= pivot)
            {
                lesser[lesserCount] = input[i];
                lesserCount++;
            }
            else
            {
                greater[greaterCount] = input[i];
                greaterCount++;
            }
        }
        
        // - Shorten the arrays
        Array.Resize(ref lesser, lesserCount);
        Array.Resize(ref greater, greaterCount);
        
        
        // - Sorting the partitions independently
        lesser = Quicksort(lesser);
        greater = Quicksort(greater);
        
        int[] result = new int[input.Length];
        int position = 0;
        for (int i = 0; i < lesser.Length; i++)
        {
            if (lesser[i] != 0)
            {
                result[position] = lesser[i];
                position++;
            }
        }
        
        result[position] = pivot;
        position++;
        for (int i = 0; i < greater.Length; i++)
        {
            if (greater[i] != 0)
            {
                result[position] = greater[i];
                position++;
            }
        }
        
        return result;
    }
}