public class Solution
{
    // String
    // Time: O(n)
    // Space: O(n)
    public string Convert(string s, int numRows)
    {
        if (numRows == 1) return s;
        var sbList = new List<StringBuilder>();
        int r;
        for (r = 0; r < numRows; r++)
            sbList.Add(new StringBuilder());
        // populate sb list
        r = 0;
        bool down = true;
        for (int i = 0; i < s.Length; i++)
        {
            sbList[r].Append(s[i]);
            if (down && r == numRows - 1) // down to the last row
                down = false;
            if (!down && r == 0) // up to the first row
                down = true;
            r += down ? 1 : -1;
        }
        // read line by line
        var finalSB = new StringBuilder();
        foreach (var sb in sbList)
            finalSB.Append(sb);
        return finalSB.ToString();
    }
}
