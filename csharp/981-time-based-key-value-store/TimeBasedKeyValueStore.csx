public class TimeMap
{
    // Space: O(n)
    Dictionary<string, SortedDictionary<int, string>> dict;
    public TimeMap()
    {
        dict = new Dictionary<string, SortedDictionary<int, string>>();
    }

    // Time: O(1)
    public void Set(string key, string value, int timestamp)
    {
        if (!dict.ContainsKey(key))
            dict[key] = new SortedDictionary<int, string>();
        
        dict[key][timestamp] = value;
    }

    // Time: O(log n)
    public string Get(string key, int timestamp)
    {
        if (!dict.ContainsKey(key))
            return string.Empty;
        
        var timeValueDict = dict[key];
        for (int i = timestamp; i >= 1; i--)
        {
            if (timeValueDict.ContainsKey(i))
                return timeValueDict[i];
        }

        return string.Empty;
    }
}

/**
 * Your TimeMap object will be instantiated and called as such:
 * TimeMap obj = new TimeMap();
 * obj.Set(key,value,timestamp);
 * string param_2 = obj.Get(key,timestamp);
 */
