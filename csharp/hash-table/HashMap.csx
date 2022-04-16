public class MyHashMap
{
    int MAX_LEN = 100000; // number of buckets
    List<List<int[]>> map;
    public MyHashMap()
    {
        map = new List<List<int[]>>();
        for (int i = 0; i < MAX_LEN; i++)
            map.Add(new List<int[]>());
    }

    private int GetHashCode(int key)
    {
        return key % MAX_LEN;
    }

    private int GetPosition(int key, int hashCode)
    {
        var bucket = map[hashCode];
        for (int i = 0; i < bucket.Count; i++)
        {
            var pair = bucket[i];
            if (pair[0] == key)
                return i;
        }

        return -1;
    }

    public void Put(int key, int value)
    {
        var hashCode = GetHashCode(key);
        var position = GetPosition(key, hashCode);
        if (position == -1)
            map[hashCode].Add(new int[] { key, value });
        else
            map[hashCode][position][1] = value;
    }

    public int Get(int key)
    {
        var hashCode = GetHashCode(key);
        var position = GetPosition(key, hashCode);
        if (position == -1)
            return -1;
        
        return map[hashCode][position][1];
    }

    public void Remove(int key)
    {
        var hashCode = GetHashCode(key);
        var position = GetPosition(key, hashCode);
        if (position == -1)
            return;
        map[hashCode].RemoveAt(position);
    }
}

/**
 * Your MyHashMap object will be instantiated and called as such:
 * MyHashMap obj = new MyHashMap();
 * obj.Put(key,value);
 * int param_2 = obj.Get(key);
 * obj.Remove(key);
 */