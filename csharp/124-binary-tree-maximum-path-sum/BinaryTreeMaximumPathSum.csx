
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
    public int DFS(TreeNode root)
    {
        // base case
        if (root == null) return 0;
        // get answer from subproblems
        int left = DFS(root.left);
        int right = DFS(root.right);
        left = Math.Max(left, 0);
        right = Math.Max(right, 0);
        // calculate the answer for current problem
        int currMax = Math.Max(left,  right) + root.val;
        globalMax = Math.Max(globalMax, left + right + root.val);
        // return answer to parent
        return currMax;
    }
}

var s = new Solution();
