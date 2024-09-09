namespace SortUtilities;

public static class SortUtilities
{
    public static bool IsSorted(int[] input)
    {
        for (int index = 0; index < input.Length - 1; index++)
        {
            if (input[index] > input[index + 1])
                return false;
        }

        return true;
    }

    public static void PrintArray(int[] input)
    {
        foreach (int number in input)
        {
            Console.Write(number + " ");
        }
    }
    
    /// <summary>
    /// Creates an array used to test the average-case time complexity scenario
    /// </summary>
    public static int[] CreateRandomArray(int size, int lower, int upper)
    {
        int[] array = new int[size];
        Random random = new Random();

        for (int index = 0; index < size; index++)
            array[index] = random.Next(lower, upper);

        return array;
    }
}