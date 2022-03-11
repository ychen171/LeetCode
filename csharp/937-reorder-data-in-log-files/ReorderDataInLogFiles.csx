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
                Console.WriteLine($"digList {digList.Count-1}:{line}");
            }
            else
            {
                letList.Add(line);
                Console.WriteLine($"letList {letList.Count-1}:{line}");
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
}
