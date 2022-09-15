using System.Collections;
public class SORTracker
{
    // SortedList: Represents a collection of key/value pairs that are sorted by the keys and are accessible by key and by index.
    SortedList<KeyValuePair<string, int>, KeyValuePair<string, int>> list;
    int count;
    public SORTracker()
    {
        list = new SortedList<KeyValuePair<string, int>, KeyValuePair<string, int>>(new RankComparer());
        count = 0;
    }

    // Time: O(log n)
    public void Add(string name, int score)
    {
        var pair = new KeyValuePair<string, int>(name, score);
        list.Add(pair, pair);
    }

    // Time: O(log n)
    public string Get()
    {
        count++;
        return list.Values[count-1].Key;
    }
}

public class RankComparer : IComparer<KeyValuePair<string, int>>
{
    // [name, score]
    public int Compare(KeyValuePair<string, int> a, KeyValuePair<string, int> b)
    {
        if (a.Value == b.Value)
        {
            var res = string.Compare(a.Key, b.Key);
            if (res < 0)
                return -1;
            else if (res > 0)
                return 1;
            else
                return 0;
        }
        else if (a.Value < b.Value)
            return 1;
        else
            return -1;
    }
}

/**
 * Your SORTracker object will be instantiated and called as such:
 * SORTracker obj = new SORTracker();
 * obj.Add(name,score);
 * string param_2 = obj.Get();
 */

var obj = new SORTracker();
obj.Add("bradford", 2);
obj.Add("branford", 3);
obj.Get();
obj.Add("alps", 2);
obj.Get();
obj.Add("orland", 2);
obj.Get();
obj.Add("orlando", 3);
obj.Get();
obj.Add("alpine", 2);
obj.Get();
obj.Get();