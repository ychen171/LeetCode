
// Sort + Two Pointers
// Time: O(n log n)
// Space: O(n)
public class TwoSum
{
    // Space: O(n)
    List<int> numList;
    public TwoSum()
    {
        numList = new List<int>();
    }
    // Time: O(1)
    public void Add(int number)
    {
        numList.Add(number);
    }
    // Time: O(n log n)
    public bool Find(int value)
    {
        numList.Sort();
        int i = 0;
        int j = numList.Count - 1;
        while (i < j)
        {
            var sum = numList[i] + numList[j];
            if (sum == value)
                return true;
            else if (sum < value)
                i++;
            else
                j--;
        }

        return false;
    }
}

/**
 * Your TwoSum object will be instantiated and called as such:
 * TwoSum obj = new TwoSum();
 * obj.Add(number);
 * bool param_2 = obj.Find(value);
 */

// Hash Table | Dictionary
// Time: O(n)
// Space: O(n)
public class TwoSum1
{
    // Space: O(n)
    Dictionary<int, int> numCountDict;
    public TwoSum1()
    {
        numCountDict = new Dictionary<int, int>();
    }
    // Time: O(1)
    public void Add(int number)
    {
        numCountDict[number] = numCountDict.GetValueOrDefault(number, 0) + 1;
    }
    // Time: O(n)
    public bool Find(int value)
    {
        foreach (var kv in numCountDict)
        {
            var num = kv.Key;
            var count = kv.Value;
            var comp = value - num;
            if (comp == num && numCountDict.ContainsKey(comp) && count >= 2)
                return true;
            if (comp != num && numCountDict.ContainsKey(comp))
                return true;
        }

        return false;
    }
}