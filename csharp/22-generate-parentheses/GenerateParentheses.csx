public class Solution
{
    // Backtracking
    // Time: O(4^n / sqrt(n))
    // Space: O(4^n / sqrt(n))
    public IList<string> GenerateParenthesis(int n)
    {
        var comb = new List<char>();
        var result = new List<string>();
        Backtrack(n, comb, 0, 0, result);
        return result;
    }
    public void Backtrack(int n, List<char> comb, int open, int close, IList<string> result)
    {
        if (comb.Count == n * 2)
        {
            var sb = new StringBuilder();
            foreach (var c in comb)
                sb.Append(c);
            var answer = sb.ToString();
            result.Add(answer);
            return;
        }
        if (open < n)
        {
            comb.Add('(');
            Backtrack(n, comb, open + 1, close, result);
            comb.RemoveAt(comb.Count - 1);
        }
        if (close < open)
        {
            comb.Add(')');
            Backtrack(n, comb, open, close + 1, result);
            comb.RemoveAt(comb.Count - 1);
        }
    }
    // public bool IsWellFormated(List<char> comb)
    // {
    //     int sum = 0;
    //     foreach (var c in comb)
    //     {
    //         if (c == '(')
    //             sum--;
    //         else if (c == ')')
    //             sum++;
    //         if (sum > 0)
    //             return false;
    //     }
    //     return sum == 0;
    // }
}
