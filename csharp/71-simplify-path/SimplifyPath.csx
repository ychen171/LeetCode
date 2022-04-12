public class Solution
{
    // Time: O(n)
    // Space: O(n)
    public string SimplifyPath(string path)
    {
        // /home/
        // [home]
        // /home
        
        // /../
        // [..]
        // /

        // /home//foo/
        // [home, foo]
        // /home/foo

        string[] dirs = path.Split(new char[]{'/'}, StringSplitOptions.RemoveEmptyEntries);
        var stack = new Stack<string>();
        foreach (var dir in dirs)
        {
            switch (dir)
            {
                case ".":
                    break;
                case "..":
                    if (stack.Count != 0)
                        stack.Pop();
                    break;
                default:
                    stack.Push(dir);
                    break;
            }
        }

        var newDirs = stack.Reverse();
        var sb = new StringBuilder();
        sb.Append('/');
        foreach (var newDir in newDirs)
        {
            sb.Append(newDir);
            sb.Append('/');
        }
        if (sb.Length > 1)
            sb.Remove(sb.Length - 1, 1);

        return sb.ToString();
    }
}
