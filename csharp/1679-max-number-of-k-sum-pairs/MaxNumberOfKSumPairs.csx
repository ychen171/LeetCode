public class Solution
{
    // Dictionary | Two Pass
    // Time: O(n)
    // Space: O(n)
    public int MaxOperations(int[] nums, int k)
    {
        var numCountDict = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            numCountDict[num] = numCountDict.GetValueOrDefault(num, 0) + 1;
        }
        int ans = 0;
        while (numCountDict.Count > 0)
        {
            var copyDict = new Dictionary<int, int>(numCountDict);
            foreach (var kv in copyDict)
            {
                var num = kv.Key;
                var count = kv.Value;
                if (num < k)
                {
                    var comp = k - num;
                    if (comp != num)
                    {
                        if (numCountDict.ContainsKey(comp) && numCountDict.ContainsKey(num))
                        {
                            numCountDict[comp]--;
                            numCountDict[num]--;

                            if (numCountDict[comp] == 0)
                                numCountDict.Remove(comp);
                            if (numCountDict[num] == 0)
                                numCountDict.Remove(num);
                            Console.WriteLine($"{comp}, {num}");
                            ans++;
                        }
                    }
                    else
                    {
                        if (numCountDict.ContainsKey(comp) && numCountDict[comp] >= 2)
                        {
                            numCountDict[comp] -= 2;

                            if (numCountDict[comp] == 0)
                                numCountDict.Remove(comp);
                            Console.WriteLine($"{comp}, {num}");
                            ans++;
                        }
                    }
                }
            }

            if (AreEqual(copyDict, numCountDict))
                break;
        }

        return ans;
    }

    private bool AreEqual(Dictionary<int, int> d1, Dictionary<int, int> d2)
    {
        if (d1.Count != d2.Count)
            return false;
        foreach (var kv1 in d1)
        {
            var key1 = kv1.Key;
            var val1 = kv1.Value;
            if (!d2.ContainsKey(key1))
                return false;
            if (d2[key1] != val1)
                return false;
        }

        return true;
    }

    // Dictionary | One Pass
    // Time: O(n)
    // Space: O(n)
    public int MaxOperations1(int[] nums, int k)
    {
        var numCountDict = new Dictionary<int, int>();
        int ans = 0;
        
        for (int i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            var comp = k - num;
            if (numCountDict.ContainsKey(comp))
            {
                numCountDict[comp]--;
                if (numCountDict[comp] == 0)
                    numCountDict.Remove(comp);
                ans++;
            }
            else
            {
                numCountDict[num] = numCountDict.GetValueOrDefault(num, 0) + 1;
            }
        }

        return ans;
    }
    
}
