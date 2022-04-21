public class MyHashSet 
{
    int MAX_LEN = 100000;
    List<List<int>> buckets;
    public MyHashSet() 
    {
        buckets = new List<List<int>>();
        for (int i = 0; i < MAX_LEN; i++)
        {
            buckets.Add(new List<int>());
        }
    }
    
    public void Add(int key) 
    {
        var hashCode = this.GetHashCode(key);
        var position = this.GetPosition(key, hashCode);
        if (position == -1)
            buckets[hashCode].Add(key);
    }
    
    public void Remove(int key) 
    {
        var hashCode = this.GetHashCode(key);
        var position = this.GetPosition(key, hashCode);
        if (position != -1)
            buckets[hashCode].RemoveAt(position);
    }
    
    public bool Contains(int key) 
    {
        int hashCode = this.GetHashCode(key);
        int position = this.GetPosition(key, hashCode);
        return position != -1;
    }
    
    private int GetHashCode(int key)
    {
        return key % MAX_LEN;
    }
    
    private int GetPosition(int key, int hashCode)
    {
        var bucket = buckets[hashCode];
        for (int i = 0; i < bucket.Count; i++)
        {
            if (bucket[i] == key)
                return i;
        }
        
        return -1;
    }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */