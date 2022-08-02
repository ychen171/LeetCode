
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
    // Space: O(h)
    public int CountNodes(TreeNode root)
    {
        // base case
        if (root == null)
            return 0;
        // recursive case
        int left = CountNodes(root.left);
        int right = CountNodes(root.right);
        return left + right + 1;
    }

    // Time: O(log n * log n)
    // Space: O(h)
    public int CountNodes1(TreeNode root)
    {
        // base case
        if (root == null)
            return 0;
        // recursive case
        int lh = 0, rh = 0;
        TreeNode l = root, r = root;
        while (l != null)
        {
            l = l.left;
            lh++;
        }
        while (r != null)
        {
            r = r.right;
            rh++;
        }
        if (lh == rh)
            return (int)Math.Pow(2, lh) - 1;

        return 1 + CountNodes1(root.left) + CountNodes1(root.right);
    }
}