public class Solution
{
    // Brute force
    // Time: O(n)
    // Space: O(n)
    public string ReverseWords(string s)
    {
        string[] strs = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var sb = new StringBuilder();
        for (int i = strs.Length - 1; i >= 0; i--)
        {
            sb.Append(strs[i] + ' ');
        }

        sb.Remove(sb.Length - 1, 1);

        return sb.ToString();
    }
}
