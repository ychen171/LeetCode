public class TimeMap
{
    // Dictionary + List + Binary Search
    // Space: O(n)
    Dictionary<string, List<KeyValuePair<int, string>>> dict;
    public TimeMap()
    {
        dict = new Dictionary<string, List<KeyValuePair<int, string>>>();
    }
    // Time: O(1)
    public void Set(string key, string value, int timestamp)
    {
        if (!dict.ContainsKey(key))
            dict[key] = new List<KeyValuePair<int, string>>();
        dict[key].Add(new KeyValuePair<int, string>(timestamp, value));
    }
    // Time: O(log n)
    public string Get(string key, int timestamp)
    {
        if (!dict.ContainsKey(key))
            return string.Empty;
        var list = dict[key];
        var index = BinarySearchRB(list, timestamp);
        if (index == -1)
            return string.Empty;
        return list[index].Value;
    }

    public int BinarySearchRB(IList<KeyValuePair<int, string>> list, int target)
    {
        int n = list.Count;
        int left = 0;
        int right = n - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (list[mid].Key < target)
                left = mid + 1;
            else if (list[mid].Key > target)
                right = mid - 1;
            else // ==
                left = mid + 1;
        }
        if (right == -1) return -1;
        return right;
    }
}

/**
 * Your TimeMap object will be instantiated and called as such:
 * TimeMap obj = new TimeMap();
 * obj.Set(key,value,timestamp);
 * string param_2 = obj.Get(key,timestamp);
 */