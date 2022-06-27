public class Solution
{
    // Backtracking
    // Time: O(n * 2^n)
    // Space: O(n)
    public IList<string> GenerateAbbreviations(string word)
    {
        var result = new List<string>();
        Backtrack(word, new StringBuilder(), 0, 0, result);
        return result;
    }

    public void Backtrack(string word, StringBuilder combo, int k, int i, IList<string> result)
    {
        // base case
        if (i >= word.Length)
        {
            result.Add(combo.ToString());
            return;
        }

        // recursive case: either abbreviated or not abbreviated

        // add number | abbreviated
        if (k == 0) // last char is either letter or empty
        {
            // add new number 1
            combo.Append('1');
            Backtrack(word, combo, 1, i + 1, result);
            combo.Remove(combo.Length - 1, 1);
        }
        else // last char in combo is number
        {
            // replace the num with new number
            if (k >= 10) // two digits
                combo.Remove(combo.Length - 2, 2);
            else // one digit
                combo.Remove(combo.Length - 1, 1);
            combo.Append(k + 1);
            Backtrack(word, combo, k + 1, i + 1, result);
            if (k + 1 >= 10) // two digits
                combo.Remove(combo.Length - 2, 2);
            else // one digit
                combo.Remove(combo.Length - 1, 1);
            combo.Append(k);
        }

        // add letter | not abbreviated
        combo.Append(word[i]);
        Backtrack(word, combo, 0, i + 1, result);
        combo.Remove(combo.Length - 1, 1);
    }
}

var s = new Solution();
var word = "interaction";
var result = s.GenerateAbbreviations(word);
foreach (var item in result)
{
    Console.WriteLine(item);
}
