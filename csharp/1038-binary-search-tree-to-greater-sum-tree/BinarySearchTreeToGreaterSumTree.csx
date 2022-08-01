
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
    int sum = 0;
    public TreeNode BstToGst(TreeNode root)
    {
        Helper(root);
        return root;
    }

    // Time: O(n)
    // Space: O(h)
    public void Helper(TreeNode node)
    {
        // base case
        if (node == null)
            return;

        // recursive case
        Helper(node.right);
        sum += node.val;
        node.val = sum;
        Helper(node.left);
    }
}
