
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    // DFS Postorder Traversal
    // Time: O(n)
    // Space: O(h)
    int diameter = 0;
    public int DiameterOfBinaryTree(TreeNode root)
    {
        Helper(root);
        return diameter;
    }

    private int Helper(TreeNode node)
    {
        // base case
        if (node == null)
            return 0;
        
        // recursive case
        int leftLen = Helper(node.left);
        int rightLen = Helper(node.right);
        diameter = Math.Max(diameter, leftLen + rightLen);
        return Math.Max(leftLen, rightLen) + 1;
    }
}
