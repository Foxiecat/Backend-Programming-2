namespace MergeSort;
using static SortUtilities.SortUtilities;

class Program
{
    static void Main(string[] args)
    {
        int[] theNumbers = CreateRandomArray(10000, 1, 10000);
        
        theNumbers = Sort(theNumbers, 0, theNumbers.Length - 1);
        
        PrintArray(theNumbers);
        Console.WriteLine("Sorted: " + IsSorted(theNumbers));
    }

    private static int[] Sort(int[] numbers, int left, int right)
    {
        if (left < right)
        {
            int middle = left + (right - left) / 2;

            Sort(numbers, left, middle);
            Sort(numbers, middle + 1, right);

            MergeSort(numbers, left, middle, right);
        }

        return numbers;
    }

    private static void MergeSort(int[] numberArray, int left, int middle, int right)
    {
        // - Define our variables
        int leftArrayLength = middle - left + 1;
        int rightArrayLength = right - middle;
        int[] leftTemporary = new int[leftArrayLength];
        int[] rightTemporary = new int[rightArrayLength];
        int index, secondIndex;


        // - Copy data into our temporary arrays
        for (index = 0; index < leftArrayLength; index++) 
            leftTemporary[index] = numberArray[left + 1];
        
        for (secondIndex = 0; secondIndex < rightArrayLength; secondIndex++) 
            rightTemporary[secondIndex] = numberArray[middle + 1 + secondIndex];
        
        index = 0;
        secondIndex = 0;
        int thirdIndex = left;


        // - Compare the numbers in the arrays leftTemporary and rightTemporary
        // and swap if the number in leftTemporary[index] is <= to the number in rightTemporary[secondIndex]
        while (index < leftArrayLength && secondIndex < rightArrayLength)
        {
            if (leftTemporary[index] <= rightTemporary[secondIndex])
            {
                numberArray[thirdIndex++] = leftTemporary[index++];
            }

            else
            {
                numberArray[thirdIndex++] = rightTemporary[secondIndex++];
            }
        }

        // Copy any remaining numbers from the leftTemporary[index] and rightTemporary[secondIndex] into the merged array
        while (index < leftArrayLength)
        {
            numberArray[thirdIndex++] = leftTemporary[index++];
        }

        while (secondIndex < rightArrayLength)
        {
            numberArray[thirdIndex++] = rightTemporary[secondIndex++];
        }
    }
}