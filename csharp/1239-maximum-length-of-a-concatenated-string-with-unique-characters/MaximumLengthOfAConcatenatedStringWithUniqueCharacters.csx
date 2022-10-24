public class Solution
{
    // DFS | Recursion | Backtracking
    // Time: O(2^n)
    // Space: O(n)
    public int MaxLength(IList<string> arr)
    {
        return Helper(arr, new int[26], 0);
    }

    public int Helper(IList<string> arr, int[] currSeq, int start)
    {
        int n = arr.Count;
        // base case
        foreach (var count in currSeq)
        {
            if (count > 1)
                return 0;
        }
        // recursive case
        int result = currSeq.Sum();
        for (int i = start; i < n; i++)
        {
            string candidate = arr[i];
            var nextSeq = new int[26];
            for (int k = 0; k < 26; k++)
                nextSeq[k] = currSeq[k];
            foreach (var c in candidate)
            {
                nextSeq[c - 'a']++;
            }
            var subResult = Helper(arr, nextSeq, i + 1);
            result = Math.Max(result, subResult);
        }
        return result;
    }
}
