
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
    int ans = 0;
    public int PseudoPalindromicPaths(TreeNode root)
    {
        if (root == null)
            return 0;
        var path = new HashSet<int>() { root.val };
        Helper(root, path);
        return ans;
    }

    public void Helper(TreeNode node, HashSet<int> path)
    {
        // base case
        if (node.left == null && node.right == null)
        {
            if (path.Count <= 1)
            {
                ans++;
            }
            return;
        }

        // recursive case
        // left
        if (node.left != null)
        {
            if (path.Contains(node.left.val))
                path.Remove(node.left.val);
            else
                path.Add(node.left.val);
            Helper(node.left, path);
            if (path.Contains(node.left.val))
                path.Remove(node.left.val);
            else
                path.Add(node.left.val);
        }
        // right
        if (node.right != null)
        {
            if (path.Contains(node.right.val))
                path.Remove(node.right.val);
            else
                path.Add(node.right.val);
            Helper(node.right, path);
            if (path.Contains(node.right.val))
                path.Remove(node.right.val);
            else
                path.Add(node.right.val);
        }
    }
}
