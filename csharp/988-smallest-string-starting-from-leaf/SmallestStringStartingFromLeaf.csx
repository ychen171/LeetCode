
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
    // Time: O(n log n)
    // Space: O(log n)
    string result;
    public string SmallestFromLeaf(TreeNode root)
    {
        result = null;
        Helper(root, new StringBuilder());
        return result;
    }

    private void Helper(TreeNode node, StringBuilder path)
    {
        // base case
        if (node == null)
            return;
        if (node.left == null && node.right == null)
        {
            path.Append((char)(node.val + 'a'));
            var str = new string(path.ToString().Reverse().ToArray());
            result = result == null ? str : string.Compare(str, result) < 0 ? str : result;
            path.Remove(path.Length - 1, 1);
        }
        // recursive case
        path.Append((char)(node.val + 'a'));
        Helper(node.left, path);
        Helper(node.right, path);
        path.Remove(path.Length - 1, 1);
    }
}
