public class FileSystem
{
    Dir root;
    public FileSystem()
    {
        root = new Dir("");
    }

    // Time: O(m + n + k log k)
    // m is the length of the input string
    // n is the number of parts / levels
    // k is the number of files and dirs for the given dir / level
    // Space: O(m + n)
    public IList<string> Ls(string path)
    {
        var result = new List<string>();
        if (path == "/")
        {
            result.AddRange(root.Dirs.Keys);
            result.AddRange(root.Files.Keys);
        }
        else
        {
            var lastDir = ToLastDir(path);
            var lastStr = path.Substring(path.LastIndexOf("/") + 1);
            if (lastDir.Name == lastStr)
            {
                result.AddRange(lastDir.Dirs.Keys);
                result.AddRange(lastDir.Files.Keys);
            }
            else
            {
                result.Add(lastStr);
            }
        }
        result.Sort();
        return result;
    }

    public void Mkdir(string path)
    {
        ToLastDir(path);
    }

    public void AddContentToFile(string filePath, string content)
    {
        var lastDir = ToLastDir(filePath);
        var lastStr = filePath.Substring(filePath.LastIndexOf("/") + 1);
        lastDir.Files[lastStr] = lastDir.Files.GetValueOrDefault(lastStr, "") + content;
    }

    public string ReadContentFromFile(string filePath)
    {
        var lastDir = ToLastDir(filePath);
        var lastStr = filePath.Substring(filePath.LastIndexOf("/") + 1);
        return lastDir.Files.GetValueOrDefault(lastStr, "");
    }

    private Dir ToLastDir(string path)
    {
        if (path == "/") return root;
        Dir curr = root;
        var strs = path.Split("/");
        for (int i = 1; i < strs.Length - 1; i++)
        {
            var str = strs[i];
            curr.Dirs[str] = curr.Dirs.GetValueOrDefault(str, new Dir(str));
            curr = curr.Dirs[str];
        }
        // handle last str
        var lastStr = strs[strs.Length - 1];
        if (curr.Files.ContainsKey(lastStr))
            return curr;
        curr.Dirs[lastStr] = curr.Dirs.GetValueOrDefault(lastStr, new Dir(lastStr));
        curr = curr.Dirs[lastStr];
        return curr;
    }
}

public class Dir
{
    public string Name { get; set; }
    public Dictionary<string, Dir> Dirs { get; set; }
    public Dictionary<string, string> Files { get; set; }
    public Dir(string name)
    {
        Name = name;
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
