public class Solution
{
    // DP | Recursion
    // Time: O(4^(n/3))
    // Space: O(4^(n/3))
    public string CountAndSay(int n)
    {
        return Helper(n);
    }

    private string Helper(int n)
    {
        // base case
        if (n == 1)
        {
            return "1";
        }
        // recursive case
        string subStr = Helper(n - 1);
        var sb = new StringBuilder();
        char curr = subStr[0];
        int count = 1;
        int i = 1;
        while (i <= subStr.Length)
        {
            if (i == subStr.Length)
            {
                sb.Append(count).Append(curr);
                break;
            }
            if (subStr[i] == curr)
            {
                count++;
            }
            else // !=
            {
                sb.Append(count).Append(curr);
                curr = subStr[i];
                count = 1;
            }
            i++;
        }
        return sb.ToString();
    }
}
