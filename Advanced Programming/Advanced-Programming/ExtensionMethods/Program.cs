using ExtensionMethods;

int x = 55;
int y = 40;

string z = "Hello World";
string za = "Nurses run";

Console.WriteLine($"string variable z has {z.CharacterCount()} characters in it");
Console.WriteLine($"{z} reversed is {z.Reverse()}");
Console.WriteLine($"{za} is a palindrome: {za.IsPalindrome()}");

Console.WriteLine($"{x} er partall: {x.IsEven()}");