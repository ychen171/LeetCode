public class Solution
{
    public int CalculateTime(string keyboard, string word)
    {
        var keyPosMap = new Dictionary<char, int>();
        for (int i = 0; i < keyboard.Length; i++)
            keyPosMap[keyboard[i]] = i;
        int curr = 0;
        int result = 0;
        for (int i = 0; i < word.Length; i++)
        {
            char c = word[i];
            int p = keyPosMap[c];
            result += Math.Abs(curr - p);
            curr = p;
        }
        return result;
    }
}
// Dictionary
// Time: O(n)
// Space: O(1)
