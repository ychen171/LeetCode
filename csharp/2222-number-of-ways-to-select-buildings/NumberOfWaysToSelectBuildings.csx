public class Solution
{
    public long NumberOfWays(string s)
    {
        /*
            0, 1, 10, 01, 101, 010
        */
        var count = new Dictionary<string, long>()
        {
            ["0"] = 0,
            ["10"] = 0,
            ["010"] = 0,
            ["1"] = 0,
            ["01"] = 0,
            ["101"] = 0,
        };
        foreach (var c in s)
        {
            if (c == '0')
            {
                count["0"]++;
                count["10"] += count["1"];
                count["010"] += count["01"];
            }
            if (c == '1')
            {
                count["1"]++;
                count["01"] += count["0"];
                count["101"] += count["10"];
            }
        }
        return count["010"] + count["101"];
    }
}
// DP
// Time: O(n)
// Space: O(1)