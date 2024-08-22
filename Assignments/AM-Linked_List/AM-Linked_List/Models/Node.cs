namespace AM_Linked_List.Models;

public class Node(string value)
{
    public string Value { get; set; } = value;
    public Node? Next { get; set; }
}