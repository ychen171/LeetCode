public class FileSystem
{
    Dir root;
    public FileSystem()
    {
        root = new Dir();
    }

    // Time: O(m + n + k log k)
    // m is the length of the input string
    // n is the number of parts / levels
    // k is the number of files and dirs for the given dir / level
    // Space: O(m + n)
    public IList<string> Ls(string path)
    {
        var result = new List<string>();
        Dir curr = root;

        // try to find the last dir
        if (path != "/")
        {
            // nagivate to the one before the last part
            string[] parts = path.Split(new char[] { '/' });
            // skip the first empty one
            for (int i = 1; i < parts.Length - 1; i++)
            {
                curr = curr.Dirs[parts[i]];
            }
            // return early if the last one is file
            string lastPart = parts[parts.Length - 1];
            if (curr.Files.ContainsKey(lastPart))
            {
                result.Add(lastPart);
                return result;
            }
            else // nagivate to the last dir
            {
                curr = curr.Dirs[lastPart];
            }
        }

        result.AddRange(curr.Dirs.Keys); // add all dirs in the current dir to result
        result.AddRange(curr.Files.Keys); // add all files in the current dir to result
        result.Sort();
        return result;
    }

    public void Mkdir(string path)
    {
        Dir curr = root;
        string[] parts = path.Split(new char[] { '/' });
        for (int i = 1; i < parts.Length; i++)
        {
            var part = parts[i];
            if (!curr.Dirs.ContainsKey(part))
                curr.Dirs[part] = new Dir();
            curr = curr.Dirs[part];
        }
    }

    public void AddContentToFile(string filePath, string content)
    {
        Dir curr = root;
        string[] parts = filePath.Split(new char[] { '/' });
        for (int i = 1; i < parts.Length - 1; i++)
        {
            var part = parts[i];
            curr = curr.Dirs[part];
        }
        string lastPart = parts[parts.Length - 1];
        if (!curr.Files.ContainsKey(lastPart))
            curr.Files[lastPart] = string.Empty;
        curr.Files[lastPart] += content;
    }

    public string ReadContentFromFile(string filePath)
    {
        Dir curr = root;
        string[] parts = filePath.Split(new char[] { '/' });
        for (int i = 1; i < parts.Length - 1; i++)
        {
            var part = parts[i];
            curr = curr.Dirs[part];
        }
        string lastPart = parts[parts.Length - 1];
        return curr.Files.GetValueOrDefault(lastPart, string.Empty);
    }
}

public class Dir
{
    public Dictionary<string, Dir> Dirs { get; set; }
    public Dictionary<string, string> Files { get; set; }
    public Dir()
    {
        Dirs = new Dictionary<string, Dir>();
        Files = new Dictionary<string, string>();
    }
}

/**
 * Your FileSystem object will be instantiated and called as such:
 * FileSystem obj = new FileSystem();
 * IList<string> param_1 = obj.Ls(path);
 * obj.Mkdir(path);
 * obj.AddContentToFile(filePath,content);
 * string param_4 = obj.ReadContentFromFile(filePath);
 */
