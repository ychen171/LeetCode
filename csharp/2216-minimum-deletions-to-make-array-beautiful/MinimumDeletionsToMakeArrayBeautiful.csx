public class Solution
{
    // Array | List
    // Time: O(n)
    // Space: O(n)
    public int MinDeletion(int[] nums)
    {
        // 1 1 2 3 5
        // l r
        // l   r

        // 1 1 2 2 3 3
        // 1
        // 1 2
        // 1 2 2
        // 1 2 2 3
        // 1 2 2 3 3
        // edge case
        int n = nums.Length;
        if (n == 0 || n == 1)
            return n;

        // n >= 2
        var list = new List<int>();
        foreach (var num in nums)
        {
            int i = list.Count;
            if (i % 2 == 0)
            {
                list.Add(num);
            }
            else
            {
                if (list.Last() == num)
                    continue;
                list.Add(num);
            }
        }
        // if list count is not even, remove the last item
        if (list.Count % 2 != 0)
            list.RemoveAt(list.Count - 1);

        return n - list.Count;
    }
}
