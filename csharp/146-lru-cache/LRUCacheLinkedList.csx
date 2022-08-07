
// Use Dictionary and Doubly Linked List
public class LRUCacheLinkedList
{
    private Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> dict;
    private LinkedList<KeyValuePair<int, int>> list;
    public int Capacity { get; set; }
    public LRUCacheLinkedList(int capacity)
    {
        Capacity = capacity;
        dict = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>();
        list = new LinkedList<KeyValuePair<int, int>>();
    }

    // Time: O(1)
    public int Get(int key)
    {
        if (!dict.ContainsKey(key))
            return -1;

        MakeMostRecently(key);
        return dict[key].Value.Value;
    }

    // Time: O(1)
    public void Put(int key, int value)
    {
        if (dict.ContainsKey(key))
        {
            RemoveKey(key);
            AddMostRecently(key, value);
            return;
        }
        if (dict.Count == Capacity)
        {
            RemoveLeastRecently();
        }
        AddMostRecently(key, value);
    }

    private void MakeMostRecently(int key)
    {
        var node = dict[key];
        list.Remove(node);
        list.AddLast(node);
    }

    private void AddMostRecently(int key, int val)
    {
        var pair = new KeyValuePair<int, int>(key, val);
        var node = new LinkedListNode<KeyValuePair<int, int>>(pair);
        list.AddLast(node);
        dict[key] = node;
    }

    private void RemoveKey(int key)
    {
        var node = dict[key];
        list.Remove(node);
        dict.Remove(key);
    }

    private void RemoveLeastRecently()
    {
        var node = list.First;
        var keyToRemove = node.Value.Key;
        list.RemoveFirst();
        dict.Remove(keyToRemove);
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */

var list = new LinkedList<int[]>();
list.AddFirst(new LinkedListNode<int[]>(new int[] { 1, 1 }));
list.AddFirst(new LinkedListNode<int[]>(new int[] { 2, 2 }));
Console.WriteLine(list);
