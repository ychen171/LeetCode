public class Solution
{
    // Diff
    // Time: O(n)
    // Space: O(n)
    public int[] GetModifiedArray(int length, int[][] updates)
    {
        // create diff array
        var diff = new int[length];
        // update the diff array
        foreach (var update in updates)
        {
            int start = update[0];
            int end = update[1];
            int increment = update[2];
            diff[start] += increment;
            if (end + 1 < length)
                diff[end + 1] -= increment;
        }
        // construct final array
        var result = new int[length];
        result[0] = diff[0];
        for (int i = 1; i < length; i++)
            result[i] = result[i - 1] + diff[i];
        
        return result;
    }
}
