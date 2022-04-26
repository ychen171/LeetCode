public class LFUCache
{

    Dictionary<int, int> keyFreqDict;
    Dictionary<int, LinkedList<KeyValuePair<int, int>>> freqKeyValueListDict;
    Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> keyValueNodeDict;
    int capacity;
    public LFUCache(int capacity)
    {
        this.capacity = capacity;
        keyFreqDict = new Dictionary<int, int>();
        freqKeyValueListDict = new Dictionary<int, LinkedList<KeyValuePair<int, int>>>();
        keyValueNodeDict = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>();
    }

    public int Get(int key)
    {
        if (capacity == 0)
            return -1;
        if (keyValueNodeDict.ContainsKey(key))
        {
            var node = keyValueNodeDict[key];
            var pair = node.Value;
            var freq = keyFreqDict[key];
            var newFreq = freq + 1;

            keyFreqDict[key] = newFreq;

            freqKeyValueListDict[freq].Remove(node);
            if (freqKeyValueListDict[freq].Count == 0)
                freqKeyValueListDict.Remove(freq);

            if (!freqKeyValueListDict.ContainsKey(newFreq))
                freqKeyValueListDict[newFreq] = new LinkedList<KeyValuePair<int, int>>();
            freqKeyValueListDict[newFreq].AddLast(node);
            
            return node.Value.Value;
        }
        else
        {
            return -1;
        }
    }

    public void Put(int key, int value)
    {
        if (capacity == 0)
            return;
        if (keyValueNodeDict.ContainsKey(key))
        {
            var node = keyValueNodeDict[key];
            var freq = keyFreqDict[key];
            var newFreq = freq + 1;
            var newPair = new KeyValuePair<int, int>(key, value);
            var newNode = new LinkedListNode<KeyValuePair<int, int>>(newPair);

            keyFreqDict[key] = newFreq;

            freqKeyValueListDict[freq].Remove(node);
            if (freqKeyValueListDict[freq].Count == 0)
                freqKeyValueListDict.Remove(freq);

            if (!freqKeyValueListDict.ContainsKey(newFreq))
                freqKeyValueListDict[newFreq] = new LinkedList<KeyValuePair<int, int>>();
            freqKeyValueListDict[newFreq].AddLast(newNode);

            keyValueNodeDict[key] = newNode;
        }
        else
        {
            // if it's new value, remove the least frequently used item 
            // before inserting new item
            if (keyValueNodeDict.Count == capacity)
            {
                var minFreq = freqKeyValueListDict.Keys.Min();
                var pairToRemove = freqKeyValueListDict[minFreq].First();
                var keyToRemove = pairToRemove.Key;
                
                keyFreqDict.Remove(keyToRemove);

                freqKeyValueListDict[minFreq].RemoveFirst();
                if (freqKeyValueListDict[minFreq].Count == 0)
                    freqKeyValueListDict.Remove(minFreq);

                keyValueNodeDict.Remove(keyToRemove);
            }

            var newFreq = 1;
            var newPair = new KeyValuePair<int, int>(key, value);
            var newNode = new LinkedListNode<KeyValuePair<int, int>>(newPair);

            keyFreqDict[key] = newFreq;

            if (!freqKeyValueListDict.ContainsKey(newFreq))
                freqKeyValueListDict[newFreq] = new LinkedList<KeyValuePair<int, int>>();
            freqKeyValueListDict[newFreq].AddLast(newNode);

            keyValueNodeDict[key] = newNode;


        }
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