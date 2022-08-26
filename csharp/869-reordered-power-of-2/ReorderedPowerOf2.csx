public class Solution
{
    bool ans = false;
    // Backtracking | Permutation
    // Time: O(log n * (log n)!)
    // Space: O(log n)
    // log n is the number of digits
    public bool ReorderedPowerOf2(int n)
    {
        var digits = new List<int>();
        while (n > 0)
        {
            digits.Add(n % 10);
            n /= 10;
        }
        digits.Sort((a, b) => a - b);
        var used = new bool[digits.Count];
        var combo = new List<int>();
        Backtrack(digits, used, combo);
        return ans;
    }

    public void Backtrack(List<int> digits, bool[] used, List<int> combo)
    {
        // base case
        if (ans)
            return;
        if (combo.Count == digits.Count)
        {
            int num = 0;
            foreach (var digit in combo)
            {
                num = 10 * num + digit;
            }
            ans = PowerOf2(num);
            return;
        }

        // recursive case
        for (int i = 0; i < digits.Count; i++)
        {
            if (used[i])
                continue;
            if (i > 0 && digits[i - 1] == digits[i] && !used[i - 1])
                continue;
            if (combo.Count == 0 && digits[i] == 0)
                continue;
            int digit = digits[i];
            used[i] = true;
            combo.Add(digit);
            Backtrack(digits, used, combo);
            used[i] = false;
            combo.RemoveAt(combo.Count - 1);
        }
    }

    public bool PowerOf2(int n)
    {
        return n > 0 && (n & (n - 1)) == 0;
    }
}

var sln = new Solution();
var result = sln.ReorderedPowerOf2(10);
Console.WriteLine(result);

