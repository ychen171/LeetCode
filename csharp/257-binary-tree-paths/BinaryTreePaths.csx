
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    // DFS Recursion | Backtracking
    // Time: O(n^2)
    // Space: O(log n)
    public IList<string> BinaryTreePaths(TreeNode root)
    {
        var result = new List<string>();
        var path = new List<int>();
        Helper(root, path, result);
        return result;
    }

    private void Helper(TreeNode node, IList<int> path, IList<string> result)
    {
        // base case
        if (node == null)
            return;
        if (node.left == null && node.right == null)
        {
            path.Add(node.val);

            var sb = new StringBuilder();
            foreach (var val in path)
                sb.Append(val).Append("->");
            sb.Remove(sb.Length - 2, 2);
            result.Add(sb.ToString());

            path.RemoveAt(path.Count - 1);
            return;
        }

        // recursive case
        path.Add(node.val);
        Helper(node.left, path, result);
        Helper(node.right, path, result);
        path.RemoveAt(path.Count - 1);
    }
}
