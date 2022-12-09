
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
    public int MaxAncestorDiff(TreeNode root)
    {
        DFS(root);
        return ans;
    }

    // return [min, max]
    private int[] DFS(TreeNode node)
    {
        // base case
        if (node == null)
            return new int[] { int.MaxValue, int.MinValue };

        // recursive case
        var leftSub = DFS(node.left);
        var rightSub = DFS(node.right);
        var min = Math.Min(node.val, Math.Min(leftSub[0], rightSub[0]));
        var max = Math.Max(node.val, Math.Max(leftSub[1], rightSub[1]));
        ans = Math.Max(ans, node.val - min);
        ans = Math.Max(ans, max - node.val);
        return new int[] { min, max };
    }
}
// DFS Postorder Traversal
// Time: O(n)
// Space: O(n)
