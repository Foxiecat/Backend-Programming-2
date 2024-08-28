namespace ExtensionMethods;

public static class StringExtension
{
    public static string CharacterCount(this string str)
    {
        int count = 0;
        
        count += str.Length;
        return count.ToString();
    }
    
    public static string Reverse(this string str) => string.Join("", str.ToCharArray().Reverse());

    // Doesn't work
    public static bool IsPalindrome(this string str)
    {
        string results = str.ToLower().Replace(" ", string.Empty);
        return str.Equals(results.ToCharArray().Reverse());
    }
}