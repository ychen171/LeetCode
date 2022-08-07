
// Use Dictionary and Doubly Linked List
public class LRUCacheLinkedList
{
    private Dictionary<int, LinkedListNode<int[]>> dict;
    private LinkedList<int[]> usedList;
    public int Capacity { get; set; }
    public LRUCacheLinkedList(int capacity)
    {
        Capacity = capacity;
        dict = new Dictionary<int, LinkedListNode<int[]>>();
        usedList = new LinkedList<int[]>();
    }

    public int Get(int key)
    {
        if (!dict.ContainsKey(key))
            return -1;
        
        Reorder(dict[key]);

        return dict[key].Value[1];
    }

    public void Put(int key, int value)
    {
        if (dict.ContainsKey(key))
            dict[key].Value[1] = value;
        else
        {
            if (dict.Count >= Capacity)
            {
                var keyToRemove = usedList.First.Value[0];
                usedList.RemoveFirst();
                dict.Remove(keyToRemove);
            }
            dict[key] = new LinkedListNode<int[]>(new int[]{key, value});
        }

        Reorder(dict[key]);
    }

    private void Reorder(LinkedListNode<int[]> node)
    {
        if (node.Next != null)
            usedList.Remove(node);
        
        if (usedList.Last != node)
            usedList.AddLast(node);
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */

var list = new LinkedList<int[]>();
list.AddFirst(new LinkedListNode<int[]>(new int[]{1,1}));
list.AddFirst(new LinkedListNode<int[]>(new int[]{2,2}));
Console.WriteLine(list);