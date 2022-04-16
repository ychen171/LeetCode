
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
    // Reversed Inorder Traversal | Iteration
    // Time: O(n)
    // Space: O(n)
    public TreeNode ConvertBST(TreeNode root)
    {
        if (root == null) return null;
        var stack = new Stack<TreeNode>();
        TreeNode curr = root;
        int sum = 0;
        while (curr != null || stack.Count != 0)
        {
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.right;
            }
            curr = stack.Pop();
            sum += curr.val;
            curr.val = sum;
            curr = curr.left;
        }

        return root;
    }

    int sum = 0;
    public TreeNode ConvertBST1(TreeNode root)
    {
        Helper(root);
        return root;
    }

    private void Helper(TreeNode root)
    {
        // base case
        if (root == null) return;
        // recursive case
        Helper(root.right);
        sum += root.val;
        root.val = sum;
        Helper(root.left);
    }
}

