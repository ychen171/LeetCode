public class Solution
{
    // Dictionary
    // Time: O(n)
    // Space: O(n)
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        // [1, 2, 3, 1]        k = 3
        // ij
        //  i     j
        //  i        j
        var numIndexDict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            if (numIndexDict.ContainsKey(num))
            {
                if (Math.Abs(numIndexDict[num] - i) <= k)
                {
                    return true;
                }
            }
            numIndexDict[num] = i;
        }

        return false;
    }

    // HashSet
    // Time: O(n)
    // Space: O(k)
    public bool ContainsNearbyDuplicate1(int[] nums, int k)
    {
        var set = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!set.Add(nums[i]))
                return true;
            if (set.Count > k)
                set.Remove(nums[i - k]);
        }

        return false;
    }
}
