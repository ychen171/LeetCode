public class Solution
{
    // Time: Hash Table | HashSet
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
}
