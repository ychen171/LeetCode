public class Solution
{
    // Bit Manipulation
    // Time: O(N log W)
    // Space: O(N log W)
    public int SubarrayBitwiseORs(int[] arr)
    {
        var currSet = new HashSet<int>();
        var resultSet = new HashSet<int>();
        currSet.Add(0);
        foreach (var num in arr)
        {
            var nextSet = new HashSet<int>();
            nextSet.Add(num);
            foreach (var curr in currSet)
            {
                nextSet.Add(curr | num);
            }
            foreach (var nv in nextSet)
                resultSet.Add(nv);
            currSet = nextSet;
        }

        return resultSet.Count;
    }
}
