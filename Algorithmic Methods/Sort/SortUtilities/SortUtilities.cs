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
}