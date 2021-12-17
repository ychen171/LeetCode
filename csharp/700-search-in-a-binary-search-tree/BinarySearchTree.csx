
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
    // Iterative
    // Time: O(N)
    // Space: O(1)
    public TreeNode SearchBST(TreeNode root, int val)
    {
        while (root != null && root.val != val)
            root = root.val > val ? root.left : root.right;
        return root;
    }

    // Recursive
    // Time: O(N)
    // Space: O(N)
    public TreeNode SearchBSTRecursive(TreeNode root, int val)
    {
        if (root == null || root.val == val) return root;
        return root.val > val ? SearchBSTRecursive(root.left, val) : SearchBSTRecursive(root.right, val);
    }

}








