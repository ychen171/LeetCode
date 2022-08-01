
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution
{
    // Time: O(n)
    // Space: O(h)
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode[] nodes)
    {
        var nodeSet = nodes.ToHashSet();
        return LCA(root, nodeSet);
    }

    private TreeNode LCA(TreeNode root, HashSet<TreeNode> nodeSet)
    {
        // base case
        if (root == null)
            return null;
        if (nodeSet.Contains(root))
            return root;

        // recursive case
        var left = LCA(root.left, nodeSet);
        var right = LCA(root.right, nodeSet);
        if (left != null && right != null)
            return root;

        return left ?? right;
    }
}
