namespace KthToLast;

public class Program
{
    static void Main(string[] args)
    {

        LinkedList<int> linkedList = new LinkedList<int>();

        linkedList.AddLast(1);
        linkedList.AddLast(1);
        linkedList.AddLast(2);
        linkedList.AddLast(3);
        linkedList.AddLast(5);
        linkedList.AddLast(8);
        linkedList.AddLast(13);
        linkedList.AddLast(21);
        linkedList.AddLast(34);

        linkedList.KthToLastSinglyLinked(3);

        Console.WriteLine( linkedList.KthToLastDoublyLinked(4) );

    }



}

