
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
    // Time: O(n)
    // Space: O(h)
    public bool IsValidBST(TreeNode root)
    {
        TreeNode curr = root;
        TreeNode prev = null;
        var stack = new Stack<TreeNode>();

        while (curr != null || stack.Count != 0)
        {
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.left;
            }
            curr = stack.Pop();
            if (prev != null && prev.val >= curr.val)
                return false;
            prev = curr;
            curr = curr.right;
        }

        return true;
    }

    // Time: O(n)
    // Space: O(h)
    public bool IsValidBST1(TreeNode root)
    {
        return DFS(root, null, null);
    }

    private bool DFS(TreeNode node, int? min, int? max)
    {
        // base case
        if (node == null)
            return true;
        if ((min.HasValue && min.Value >= node.val) || (max.HasValue && max.Value <= node.val))
            return false;

        // recursive case
        return DFS(node.left, min, node.val) && DFS(node.right, node.val, max);
    }
}
