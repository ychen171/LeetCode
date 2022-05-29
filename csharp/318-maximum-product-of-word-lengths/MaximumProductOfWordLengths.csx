public class Solution
{
    // Dictionary | Array
    // Time: O(n^2)
    // Space: O(n)
    public int MaxProduct(string[] words)
    {
        int n = words.Length;
        // array of letter count
        var countArray = new int[n][];
        for (int i = 0; i < n; i++)
        {
            string word = words[i];
            countArray[i] = new int[26];
            foreach (var letter in word)
            {
                countArray[i][letter - 'a']++;
            }
        }

        // iterate through words, find all pairs, and check if they don't share common letters
        int ans = 0;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (NoCommonLetter(countArray[i], countArray[j]))
                {
                    ans = Math.Max(ans, words[i].Length * words[j].Length);
                }
            }
        }

        return ans;
    }

    public bool NoCommonLetter(int[] count1, int[] count2)
    {
        for (int i = 0; i < 26; i++)
        {
            if (count1[i] > 0 && count2[i] > 0)
                return false;
        }

        return true;
    }
}
