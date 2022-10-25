public class Solution
{
    // String
    // Time: O(n)
    // Space: O(n)
    public bool ArrayStringsAreEqual(string[] word1, string[] word2)
    {
        var sb1 = new StringBuilder();
        var sb2 = new StringBuilder();
        foreach (var w1 in word1)
            sb1.Append(w1);
        foreach (var w2 in word2)
            sb2.Append(w2);
        if (sb1.Length != sb2.Length)
            return false;
        for (int i = 0; i < sb1.Length; i++)
        {
            if (sb1[i] != sb2[i])
                return false;
        }
        return true;
    }
}
