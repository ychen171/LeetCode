public class Solution
{
    // Hash Table | HashSet
    // Time: O(n)
    // Space: O(n)
    public int SingleNumber(int[] nums)
    {
        var set = new HashSet<int>();
        foreach (var num in nums)
        {
            if (set.Add(num))
                continue;
            set.Remove(num);
        }

        return set.First();
    }

    // Bit Manipulation
    // Time: O(n)
    // Space: O(1)
    public int SingleNumber1(int[] nums)
    {
        int ans = 0;
        foreach (var num in nums)
        {
            ans ^= num;
        }

        return ans;
    }
}
