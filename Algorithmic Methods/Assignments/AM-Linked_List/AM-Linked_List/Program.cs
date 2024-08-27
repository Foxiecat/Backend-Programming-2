using AM_Linked_List.Control;
using AM_Linked_List.Models;

CustomLinkedList<object> aLinkedList = new()
{
    "First Node",
    "Second Node",
    "Third Node",
    "Fourth Node",
    "Fifth Node",
    20
};

aLinkedList.Add('a');
aLinkedList.Add(true);

Node<string> aNodeString = new("Sixth Node");
aLinkedList.Add(aNodeString);


Console.WriteLine($"\nNumbers of items: {aLinkedList.Count}");
foreach (object item in aLinkedList)
{
    Console.WriteLine(item);
}

// Removing the first and last item, removing a specified item and an item at a specified index
aLinkedList.RemoveHead();
aLinkedList.RemoveTail();
aLinkedList.Remove("Fifth Node");
aLinkedList.RemoveAt(2);

aLinkedList.AddToHead("First Node 2");

Console.WriteLine($"\nNumbers of items: {aLinkedList.Count}");
foreach (object item in aLinkedList)
{
    Console.WriteLine(item);
}

// Cannot add duplicates
aLinkedList.Add("Second Node");