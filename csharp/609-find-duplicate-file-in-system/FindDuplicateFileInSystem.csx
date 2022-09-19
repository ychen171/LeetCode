public class Solution
{
    // Dictionary
    // Time: O(n * m)
    // Space: O(n * m)
    // n strings of average length m is parsed
    Dictionary<string, List<string>> contentToPath;
    public IList<IList<string>> FindDuplicate(string[] paths)
    {
        contentToPath = new Dictionary<string, List<string>>();
        var result = new List<IList<string>>();
        foreach (var path in paths)
        {
            // dir file1(content1) file2(content2)...
            var parts = path.Split(' ');
            if (parts.Length < 2)
                continue;
            var dir = parts[0];
            for (int i = 1; i < parts.Length; i++)
            {
                var part = parts[i];
                int index = part.IndexOf("(");
                if (index == -1)
                    continue;
                var file = part.Substring(0, index);
                var content = part.Substring(index + 1);
                if (!contentToPath.ContainsKey(content))
                    contentToPath[content] = new List<string>();
                contentToPath[content].Add($"{dir}/{file}");
            }
        }
        foreach (var dirFileList in contentToPath.Values)
        {
            var list = new List<string>();
            foreach (var dirFile in dirFileList)
            {
                list.Add(dirFile);
            }
            if (list.Count > 1)
                result.Add(list);
        }

        return result;
    }
}
