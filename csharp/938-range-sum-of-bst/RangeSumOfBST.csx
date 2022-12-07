
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
    int ans;
    public int RangeSumBST(TreeNode root, int low, int high)
    {
        DFS(root, low, high);
        return ans;
    }

    private void DFS(TreeNode node, int low, int high)
    {
        // base case
        if (node == null) return;
        // recursive case
        if (node.val < low)
            DFS(node.right, low, high);
        else if (node.val > high)
            DFS(node.left, low, high);
        else // low <= node.val <= high
        {
            ans += node.val;
            DFS(node.left, low, high);
            DFS(node.right, low, high);
        }
    }
}
// DFS Preorder Traversal
// Time: O(n)
// Space: O(n)
