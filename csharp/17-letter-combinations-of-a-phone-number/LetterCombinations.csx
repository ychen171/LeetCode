public class Solution
{
    // two instances of string list | brute force
    // Time: (4^n)
    // Space: O(n)
    public IList<string> LetterCombinations(string digits)
    {
        var digitLetterDict = new Dictionary<int, string>()
        {
            ['2'] = "abc",
            ['3'] = "def",
            ['4'] = "ghi",
            ['5'] = "jkl",
            ['6'] = "mno",
            ['7'] = "pqrs",
            ['8'] = "tuv",
            ['9'] = "wxyz"
        };
        var result = new List<string>();
        if (digits == null || digits.Length == 0) return result;
        List<string> original;
        foreach (var digit in digits)
        {
            var letters = digitLetterDict[digit];
            original = result.Count == 0 ? new List<string>() { string.Empty } : result;
            result = new List<string>();
            for (int i = 0; i < letters.Length; i++)
            {
                var modified = new List<string>(original);
                for (int j = 0; j < modified.Count; j++)
                {
                    modified[j] += letters[i];
                }
                result.AddRange(modified);
            }
        }

        return result;
    }

    // Backtracking
    // Time: O(4^N * N)
    // Space: O(N)
    public IList<string> LetterCombinations1(string digits)
    {
        var digitLetterDict = new Dictionary<char, string>()
        {
            ['2'] = "abc",
            ['3'] = "def",
            ['4'] = "ghi",
            ['5'] = "jkl",
            ['6'] = "mno",
            ['7'] = "pqrs",
            ['8'] = "tuv",
            ['9'] = "wxyz"
        };

        StringBuilder comb = new StringBuilder();
        IList<string> result = new List<string>();
        if (digits.Length == 0) return result;
        Backtrack(digits, digitLetterDict, comb, 0, result);
        return result;
    }
    private void Backtrack(string digits, Dictionary<char, string> dict, StringBuilder comb, int nextStart, IList<string> result)
    {
        if (comb.Length == digits.Length)
        {
            result.Add(comb.ToString());
            return;
        }
        char[] candidates = dict[digits[nextStart]].ToCharArray();
        for (int i = 0; i < candidates.Length; i++)
        {
            comb.Append(candidates[i]);
            Backtrack(digits, dict, comb, nextStart + 1, result);
            comb.Remove(comb.Length - 1, 1);
        }
    }
}

var s = new Solution();
Console.WriteLine(s.LetterCombinations("23"));
var result1 = s.LetterCombinations1("23");
Console.WriteLine(result1);

