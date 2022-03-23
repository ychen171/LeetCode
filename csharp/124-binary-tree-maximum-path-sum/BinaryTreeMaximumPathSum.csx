
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
    // DFS | Bottom-up
    // Time: O(n)
    // Space: O(n)
    int globalMax = int.MinValue;
    public int MaxPathSum(TreeNode root)
    {
        DFS(root);
        return globalMax;
    }

    private int DFS(TreeNode node)
    {
        // base case
        if (node == null) return 0;
        // get answers from subproblems
        var left = Math.Max(DFS(node.left), 0);
        var right = Math.Max(DFS(node.right), 0);
        // calculate answer for current problem based on the given answers
        var maxPath = Math.Max(left, right) + node.val;
        var currMax = left + right + node.val;
        globalMax = Math.Max(globalMax, currMax);
        // return current answer to parent
        return maxPath;
    }
}

var s = new Solution();
