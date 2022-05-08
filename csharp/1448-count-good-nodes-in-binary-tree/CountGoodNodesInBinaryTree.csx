
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
    int count = 0;
    // DFS preorder traversal
    // Time: O(n)
    // Space: O(n)
    public int GoodNodes(TreeNode root)
    {
        Helper(root, int.MinValue);
        return count;
    }

    private void Helper(TreeNode root, int max)
    {
        // base case
        if (root == null)
            return;
        // recursive case
        if (root.val >= max)
        {
            count++;
            max = root.val;
        }

        Helper(root.left, max);
        Helper(root.right, max);
    }
}
