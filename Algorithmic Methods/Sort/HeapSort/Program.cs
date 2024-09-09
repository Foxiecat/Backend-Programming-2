namespace HeapSort;
using static SortUtilities.SortUtilities;


class Program
{
    static void Main(string[] args)
    {
        // 2 000 000 numbers in an array cause why not? xD
        int[] theNumbers = CreateRandomArray(2000000, 1, 2000000);
        
        theNumbers = Sort(theNumbers);
        
        PrintArray(theNumbers);
        Console.WriteLine("Sorted: " + IsSorted(theNumbers));
    }

    private static int[] Sort(int[] numbers)
    {
        if (numbers.Length <= 1)
            return numbers;

        for (int index = numbers.Length / 2 - 1; index >= 0; index--)
        {
            Heapify(numbers, numbers.Length, index);
        }

        for (int index = numbers.Length - 1; index >= 0; index--)
        {
            (numbers[0], numbers[index]) = (numbers[index], numbers[0]);
            Heapify(numbers, index, 0);
        }
        
        return numbers;
    }

    static void Heapify(int[] numbers, int size, int index)
    {
        int largestIndex = index;
        int leftChild = 2 * index + 1;
        int rightChild = 2 * index + 2;
        
        
        if(leftChild < size && numbers[leftChild] > numbers[largestIndex])
            largestIndex = leftChild;

        if (rightChild < size && numbers[rightChild] > numbers[largestIndex])
            largestIndex = rightChild;

        
        if (largestIndex != index)
        {
            (numbers[index], numbers[largestIndex]) = (numbers[largestIndex], numbers[index]);
            Heapify(numbers, size, largestIndex);
        }
    }
}