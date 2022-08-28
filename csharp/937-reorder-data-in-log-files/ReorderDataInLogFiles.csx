public class Solution
{
    // Sorting list by keys
    // Time: O(N * log N)
    // Space: O(N)
    public string[] ReorderLogFiles(string[] logs)
    {
        var letList = new List<string>();
        var digList = new List<string>();
        foreach (var line in logs)
        {
            var parts = line.Split(' ');
            if (char.IsDigit(parts[1][0]))
            {
                digList.Add(line);
                Console.WriteLine($"digList {digList.Count - 1}:{line}");
            }
            else
            {
                letList.Add(line);
                Console.WriteLine($"letList {letList.Count - 1}:{line}");
            }
        }
        // order letter logs
        List<string> orderedList = letList
            .OrderBy(x => x.Substring(x.IndexOf(' ') + 1))
            .ThenBy(x => x.Substring(0, x.IndexOf(' '))).ToList();
        // append digit logs to the ordered letter logs
        orderedList.AddRange(digList);
        return orderedList.ToArray();
    }

    // Sorting
    // Time: O(n log n)
    // Space: O(n)
    public string[] ReorderLogFiles1(string[] logs)
    {
        var letLogs = new List<KeyValuePair<int, string[]>>();
        var digLogs = new List<int>();
        for (int i = 0; i < logs.Length; i++)
        {
            string log = logs[i];
            var spaceIndex = log.IndexOf(' ');
            if (spaceIndex == -1)
                continue;
            var id = log.Substring(0, spaceIndex);
            var content = log.Substring(spaceIndex + 1);
            if (char.IsDigit(content[0]))
                digLogs.Add(i);
            else
                letLogs.Add(new KeyValuePair<int, string[]>(i, new string[] { id, content }));
        }

        letLogs.Sort((a, b) =>
        {
            string aid = a.Value[0], acontent = a.Value[1];
            string bid = b.Value[0], bcontent = b.Value[1];
            if (acontent == bcontent)
                return string.Compare(aid, bid);
            return string.Compare(acontent, bcontent);
        });

        int m = letLogs.Count;
        int n = digLogs.Count;
        var result = new string[m + n];
        for (int i = 0; i < m; i++)
            result[i] = logs[letLogs[i].Key];
        for (int i = 0; i < n; i++)
            result[m + i] = logs[digLogs[i]];

        return result;
    }
}
