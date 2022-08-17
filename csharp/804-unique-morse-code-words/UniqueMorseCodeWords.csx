public class Solution
{
    // Dictionary + HashSet
    // Time: O(n)
    // Space: O(n)
    public int UniqueMorseRepresentations(string[] words)
    {
        var codeArray = new string[26] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
        var transformationSet = new HashSet<string>();
        foreach (var word in words)
        {
            var sb = new StringBuilder();
            foreach (var c in word)
                sb.Append(codeArray[c - 'a']);
            transformationSet.Add(sb.ToString());
        }

        return transformationSet.Count;
    }
}
