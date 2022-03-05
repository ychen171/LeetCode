using System.Collections.Specialized;

// Use Dictionary and OrderedDictionary
public class LRUCacheUsingOrderedDictionary
{
    private Dictionary<int, int> keyValueMap;
    private OrderedDictionary usedMap;
    public int Capacity { get; set; }
    public LRUCacheUsingOrderedDictionary(int capacity)
    {
        Capacity = capacity;
        keyValueMap = new Dictionary<int, int>();
        usedMap = new OrderedDictionary();
    }

    public int Get(int key)
    {
        if (keyValueMap.ContainsKey(key))
        {
            usedMap.Remove(key);
            var val = keyValueMap[key];
            usedMap.Add(key, val);
            return val;
        }
        else
            return -1;
    }

    public void Put(int key, int value)
    {
        if (keyValueMap.ContainsKey(key))
        {
            usedMap.Remove(key);
            keyValueMap[key] = value;
            usedMap.Add(key, value);
        }
        else
        {
            usedMap.Add(key, value);
            keyValueMap[key] = value;
            if (keyValueMap.Count > Capacity)
            {
                var keys = new int[usedMap.Count];
                usedMap.Keys.CopyTo(keys, 0);
                var keyToRemove = keys[0];
                usedMap.Remove(keyToRemove);
                keyValueMap.Remove(keyToRemove);
            }
        }
    }
}

// Use Dictionary and Doubly Linked List
public class LRUCache
{
    private Dictionary<int, LinkedListNode<int[]>> dict;
    private LinkedList<int[]> usedList;
    public int Capacity { get; set; }
    public LRUCache(int capacity)
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