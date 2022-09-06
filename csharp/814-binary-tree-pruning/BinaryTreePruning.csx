
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
    // Postorder Recursion
    // Time: O(n)
    // Space: O(n)
    public TreeNode PruneTree(TreeNode root)
    {
        // base case
        if (root == null)
            return null;

        // recursive case
        root.left = PruneTree(root.left);
        root.right = PruneTree(root.right);
        if (root.val == 0 && root.left == null && root.right == null)
            return null;
        return root;
    }
    
    public TreeNode PruneTree1(TreeNode root)
    {
        int result = Helper(root);
        if (result == 0)
            return null;
        return root;
    }

    public int Helper(TreeNode node)
    {
        // base case
        if (node == null)
            return 0;

        // recursive case
        int left = Helper(node.left);
        int right = Helper(node.right);
        if (left == 0)
            node.left = null;
        if (right == 0)
            node.right = null;
        int result = left + right + node.val > 0 ? 1 : 0;
        return result;
    }
}
