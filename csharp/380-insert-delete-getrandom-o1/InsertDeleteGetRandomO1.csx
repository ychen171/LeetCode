using System.Collections.Specialized;

public class RandomizedSet
{
    OrderedDictionary orderedDict;

    public RandomizedSet()
    {
        orderedDict = new OrderedDictionary();
    }

    public bool Insert(int val)
    {
        var hashCode = val.GetHashCode();
        if (orderedDict.Contains(hashCode))
            return false;
        orderedDict.Add(hashCode, val);
        return true;
    }

    public bool Remove(int val)
    {
        var hashCode = val.GetHashCode();
        if (orderedDict.Contains(hashCode))
        {
            orderedDict.Remove(hashCode);
            return true;
        }
        else
            return false;
    }

    public int GetRandom()
    {
        int n = orderedDict.Keys.Count;
        var r = new Random();
        int rIndex = r.Next() % n;
        int[] values = new int[n];
        orderedDict.Values.CopyTo(values, 0);
        return values[rIndex];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */


public class RandomizedSet1
{
    // {[0]= 0, [1] = 1}, [0, 1]
    // remove 0, i = 0, {[0]= 0, [1] = 1}, lastElement = 1, [1, 1], {[0]= 0, [1] = 0}
    // [1], {[1] = 0}
    // insert 2, {[1] = 0, [2] = 1}, [1, 2]
    Dictionary<int, int> dict;
    List<int> list;

    public RandomizedSet1()
    {
        dict = new Dictionary<int, int>();
        list = new List<int>();
    }

    public bool Insert(int val)
    {
        if (dict.ContainsKey(val))
            return false;
        dict[val] = list.Count;
        list.Add(val);
        Console.WriteLine($"Insert -- list.Count: {list.Count}");
        return true;
    }

    public bool Remove(int val)
    {
        if (!dict.ContainsKey(val))
            return false;
        
        int i = dict[val];
        list[i] = list[list.Count - 1];
        dict[list[i]] = i;

        dict.Remove(val);
        list.RemoveAt(list.Count - 1);
        Console.WriteLine($"Remove -- list.Count: {list.Count}");
        return true;
    }

    public int GetRandom()
    {
        var rand = new Random();
        return list[rand.Next() % list.Count];
    }
}