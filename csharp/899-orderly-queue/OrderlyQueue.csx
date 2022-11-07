public class Solution
{
    // Math + Sort
    // Time: O(n^2)
    // Space: O(n)
    public string OrderlyQueue(string s, int k)
    {
        int n = s.Length;
        string result = s;
        if (k == 1)
        {
            for (int i = 0; i < n; i++)
            {
                var curr = s.Substring(i) + s.Substring(0, i);
                if (string.CompareOrdinal(curr, result) < 0)
                    result = curr;
            }
        }
        else
        {
            var cs = s.ToArray();
            Array.Sort(cs);
            result = new string(cs);
        }
        return result;
    }
}
