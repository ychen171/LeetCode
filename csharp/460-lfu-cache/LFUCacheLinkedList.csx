public class LFUCache
{

    Dictionary<int, int> keyToFreq;
    Dictionary<int, LinkedList<KeyValuePair<int, int>>> freqToList;
    Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> keyToListNode;
    int capacity;
    public LFUCache(int capacity)
    {
        keyToFreq = new Dictionary<int, int>();
        freqToList = new Dictionary<int, LinkedList<KeyValuePair<int, int>>>();
        keyToListNode = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>();
        this.capacity = capacity;
    }

    public int Get(int key)
    {
        if (capacity <= 0)
            return -1;
        if (!keyToListNode.ContainsKey(key))
            return -1;

        IncreaseFreq(key);
        return keyToListNode[key].Value.Value;
    }

    public void Put(int key, int value)
    {
        if (capacity <= 0)
            return;
        if (keyToFreq.ContainsKey(key))
        {
            ModifyValue(key, value);
            IncreaseFreq(key);
            return;
        }

        if (keyToListNode.Count == capacity)
        {
            RemoveLeastFreq();
        }
        AddLeastFreq(key, value);
    }

    private void IncreaseFreq(int key)
    {
        var freq = keyToFreq[key];
        var node = keyToListNode[key];
        var newFreq = freq + 1;
        keyToFreq[key] = newFreq;
        freqToList[freq].Remove(node);
        if (freqToList[freq].Count == 0)
            freqToList.Remove(freq);
        if (!freqToList.ContainsKey(newFreq))
            freqToList[newFreq] = new LinkedList<KeyValuePair<int, int>>();
        freqToList[newFreq].AddLast(node);
    }

    private void ModifyValue(int key, int value)
    {
        var freq = keyToFreq[key];
        var node = keyToListNode[key];
        var newPair = new KeyValuePair<int, int>(key, value);
        var newNode = new LinkedListNode<KeyValuePair<int, int>>(newPair);
        freqToList[freq].Remove(node);
        freqToList[freq].AddLast(newNode);
        keyToListNode[key] = newNode;
    }

    private void AddLeastFreq(int key, int value)
    {
        var pair = new KeyValuePair<int, int>(key, value);
        var node = new LinkedListNode<KeyValuePair<int, int>>(pair);
        keyToFreq[key] = 1;
        if (!freqToList.ContainsKey(1))
            freqToList[1] = new LinkedList<KeyValuePair<int, int>>();
        freqToList[1].AddLast(node);
        keyToListNode[key] = node;
    }

    private void RemoveLeastFreq()
    {
        var minFreq = freqToList.Keys.Min();
        var node = freqToList[minFreq].First;
        var key = node.Value.Key;
        keyToFreq.Remove(key);
        freqToList[minFreq].RemoveFirst();
        if (freqToList[minFreq].Count == 0)
            freqToList.Remove(minFreq);
        keyToListNode.Remove(key);
    }
}

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */

var obj = new LFUCache(2);
obj.Put(1, 1);
obj.Put(2, 2);
obj.Get(1);
obj.Put(3, 3);
obj.Get(2);
obj.Get(3);
obj.Put(4, 4);
obj.Get(1);
obj.Get(3);
obj.Get(4);