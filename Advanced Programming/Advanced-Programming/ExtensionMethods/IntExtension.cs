namespace ExtensionMethods;

public static class IntExtension
{
    // Lag en metode som sjekker om en int er et par-tall
    public static bool IsEven(this int number) => number % 2 == 0;
}