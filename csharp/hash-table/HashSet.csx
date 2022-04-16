
public class MyHashSet
{
    int MAX_LEN = 100000; // number of buckets
    List<List<int>> set;
    public MyHashSet()
    {
        set = new List<List<int>>();
        for (int i = 0; i < MAX_LEN; i++)
            set.Add(new List<int>());
    }

    private int GetHashCode(int key)
    {
        return key % MAX_LEN;
    }

    private int GetPosition(int key, int hashCode)
    {
        var bucket = set[hashCode];
        for (int i = 0; i < bucket.Count; i++)
        {
            if (bucket[i] == key)
                return i;
        }

        return -1;
    }

    public void Add(int key)
    {
        var hashCode = GetHashCode(key);
        var position = GetPosition(key, hashCode);
        if (position == -1)
            set[hashCode].Add(key);
    }

    public void Remove(int key)
    {
        var hashCode = GetHashCode(key);
        var position = GetPosition(key, hashCode);
        if (position == -1)
            return;
        set[hashCode].RemoveAt(position);
    }

    public bool Contains(int key)
    {
        var hashCode = GetHashCode(key);
        var position = GetPosition(key, hashCode);
        return position != -1;
    }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */