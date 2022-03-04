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
}

var s = new Solution();
Console.WriteLine(s.LetterCombinations("23"));

