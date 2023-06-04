using System.Text;

namespace task1;

internal static class Task1
{
    public static void Main()
    {
        var hashModulo = Convert.ToInt32(Console.ReadLine());
        var values = Console.ReadLine()?.Split(' ');
        
        var hashTable = new HashTable(values!.Length, hashModulo);
        
        foreach (var val in values)
        {
            hashTable.Insert(int.Parse(val));
        }
        
        Console.WriteLine(hashTable.ToString());
        
    }
}
internal class HashTable
{
    private int size; 
    private int hashModulo;

    private ListNode<int>[] values;

    public HashTable(int size, int hashModulo)
    {
        this.size = size;
        this.hashModulo = hashModulo;
        values = new ListNode<int>[size];
    }

    public void Insert(int newValue)
    {
        var position = newValue % hashModulo;
        
        if (values[position] == null)
        {
            values[position] = new ListNode<int>(newValue);
        }
        else
        {
            values[position].Insert(newValue);
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        
        for (var i = 0; i < hashModulo; i++)
        {
            sb.Append($"{i}: ");

            if (values[i] != null)
            {
                sb.Append(values[i]);   
            }

            sb.Append('\n');
        }
        
        return sb.ToString();
    }
}

internal class ListNode<T>
{
    private T value;

    private ListNode<T>? next;

    public ListNode()
    {
    }

    public ListNode(T value)
    {
        this.value = value;
        next = null;
    }

    public void Insert(T newValue)
    {
        if (next == null)
            next = new ListNode<T>(newValue);
        else
            next.Insert(newValue);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.Append($"{value} ");
        var currentNode = next;
        while (currentNode != null)
        {
            sb.Append(currentNode.value + " ");
            currentNode = currentNode.next;
        }

        return sb.ToString();
    }
}