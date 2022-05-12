
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
    // Bottom-up | Recursion
    // Time: O(n)
    // Space: O(n)
    int globalMax = 0;
    public int LongestConsecutive(TreeNode root)
    {
        Helper(root);
        return globalMax;
    }

    public int Helper(TreeNode node)
    {
        // base case
        if (node == null)
            return 0;

        // recursive case
        int left = Helper(node.left);
        if (node.left != null && node.left.val != node.val + 1)
            left = 0;
        
        int right = Helper(node.right);
        if (node.right != null && node.right.val != node.val + 1)
            right = 0;
        
        int currMax = Math.Max(left, right) + 1;
        globalMax = Math.Max(globalMax, currMax);

        return currMax;
    }
}
