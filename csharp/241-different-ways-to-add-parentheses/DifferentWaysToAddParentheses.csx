public class Solution
{
    // Recursion
    // Time: O(n)
    // Space: O(n)
    Dictionary<string, IList<int>> memo = new Dictionary<string, IList<int>>();
    public IList<int> DiffWaysToCompute(string expression)
    {
        if (memo.ContainsKey(expression))
            return memo[expression];
        // recursive case
        int n = expression.Length;
        var result = new List<int>();
        for (int i = 0; i < n; i++)
        {
            var c = expression[i];
            if (c == '+' || c == '-' || c == '*')
            {
                var leftExpr = expression.Substring(0, i);
                var rightExpr = expression.Substring(i + 1);
                var leftResult = DiffWaysToCompute(leftExpr);
                var rightResult = DiffWaysToCompute(rightExpr);
                foreach (var leftValue in leftResult)
                {
                    foreach (var rightValue in rightResult)
                    {
                        if (c == '+')
                            result.Add(leftValue + rightValue);
                        else if (c == '-')
                            result.Add(leftValue - rightValue);
                        else if (c == '*')
                            result.Add(leftValue * rightValue);
                    }
                }
            }
        }
        // base case
        if (result.Count == 0) // no operator, only number
            result.Add(int.Parse(expression));

        memo[expression] = result;
        return result;
    }
}
