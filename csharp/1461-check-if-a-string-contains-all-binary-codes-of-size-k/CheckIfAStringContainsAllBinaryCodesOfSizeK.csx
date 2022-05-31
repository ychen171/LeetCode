public class Solution
{
    // HashSet
    // Time: O(n)
    // Space: O(n)
    public bool HasAllCodes(string s, int k)
    {
        // corner case
        int n = s.Length;
        if (n < k)
            return false;
        // find all substrings in s with length == k
        var strSet = new HashSet<string>();
        for (int i = 0; i < n - k + 1; i++)
        {
            strSet.Add(s.Substring(i, k));
        }
        
        return strSet.Count == Math.Pow(2, k);
    }
}
