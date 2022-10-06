public class TimeMap
{
    // Dictionary + Sorted List
    // Space: O(n)
    Dictionary<string, SortedList<int, string>> dict;
    public TimeMap()
    {
        dict = new Dictionary<string, SortedList<int, string>>();
    }

    // Time: O(1)
    public void Set(string key, string value, int timestamp)
    {
        if (!dict.ContainsKey(key))
            dict[key] = new SortedList<int, string>();

        dict[key][timestamp] = value;
    }

    // Time: O(log n)
    public string Get(string key, int timestamp)
    {
        if (!dict.ContainsKey(key))
            return string.Empty;

        var timeValueList = dict[key];
        for (int i = timestamp; i >= 1; i--)
        {
            if (timeValueList.ContainsKey(i))
                return timeValueList[i];
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
