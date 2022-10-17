public class Solution
{
    // HashSet
    // Time: O(n)
    // Space: O(1)
    public bool CheckIfPangram(string sentence)
    {
        var letterSet = new HashSet<char>();
        foreach (var c in sentence)
        {
            letterSet.Add(c);
            if (letterSet.Count == 26)
                return true;
        }
        return false;
    }
}
