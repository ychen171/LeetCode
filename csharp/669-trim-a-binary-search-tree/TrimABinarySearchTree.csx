
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
    // Recursion
    // Time: O(n)
    // Space: O(n)
    public TreeNode TrimBST(TreeNode root, int low, int high)
    {
        return Helper(root, low, high);
    }

    public TreeNode Helper(TreeNode node, int low, int high)
    {
        // base case
        if (node == null)
            return null;

        // recursive case
        if (node.val < low)
        {
            node = Helper(node.right, low, high);
        }
        else if (node.val > high)
        {
            node = Helper(node.left, low, high);
        }
        else
        {
            node.left = Helper(node.left, low, high);
            node.right = Helper(node.right, low, high);
        }
        return node;
    }
}
