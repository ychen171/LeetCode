using System.Collections.Specialized;

// Use Dictionary and OrderedDictionary
public class LRUCacheOrderedDictionary
{
    private Dictionary<int, int> keyValueMap;
    private OrderedDictionary usedMap;
    public int Capacity { get; set; }
    public LRUCacheOrderedDictionary(int capacity)
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
