using AM_Linked_List.Control;

CustomLinkedList<object> aLinkedList = new()
{
    "First Node",
    "Second Node",
    "Third Node",
    "Fourth Node",
    "Fifth Node",
    20,
};

aLinkedList.Add('a');
aLinkedList.Add(true);

Console.WriteLine($"\nNumbers of items: {aLinkedList.Count}");
foreach (object item in aLinkedList)
{
    Console.WriteLine(item);
}

aLinkedList.Remove("Fifth Node");
Console.WriteLine($"\nNumbers of items: {aLinkedList.Count}");
foreach (object item in aLinkedList)
{
    Console.WriteLine(item);
}

aLinkedList.Add("Second Node");