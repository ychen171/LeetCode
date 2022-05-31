
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
    IList<IList<int>> ans = new List<IList<int>>();
    public IList<IList<int>> FindLeaves(TreeNode root)
    {
        GetHeight(root);
        return ans;
    }

    // DFS | Bottom-up
    // Time: O(n)
    // Space: O(n)
    public int GetHeight(TreeNode node)
    {
        // base case
        if (node == null)
            return -1;

        // recursive case
        int leftHeight = GetHeight(node.left);
        int rightHeight = GetHeight(node.right);
        int currHeight = 1 + Math.Max(leftHeight, rightHeight);

        if (currHeight == ans.Count)
            ans.Add(new List<int>());
        ans[currHeight].Add(node.val);

        return currHeight;
    }
}
