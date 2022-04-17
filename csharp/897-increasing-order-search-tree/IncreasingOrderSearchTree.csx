
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
    // Inorder traversal | Iteration
    // Time: O(n)
    // Space: O(h)
    public TreeNode IncreasingBST(TreeNode root)
    {
        if (root == null) return null;
        var stack = new Stack<TreeNode>();
        TreeNode curr = root;
        TreeNode prev = null;
        TreeNode newRoot = null;
        while (curr != null || stack.Count != 0)
        {
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.left;
            }
            curr = stack.Pop();

            if (newRoot == null)
                newRoot = curr;
            if (prev != null)
            {
                prev.right = curr;
                curr.left = null;
            }
            prev = curr;
        
            curr = curr.right;
        }

        return newRoot;
    }

    // Inorder traversal | Recursion
    // Time: O(n)
    // Space: O(h)
    TreeNode curr;
    public TreeNode IncreasingBST1(TreeNode root)
    {
        if (root == null)
            return null;
        TreeNode dummy = new TreeNode(0);
        curr = dummy;
        Inorder(root);
        return dummy.right;
    }

    private void Inorder(TreeNode node)
    {
        // base case
        if (node == null) 
            return;
        // recursive case
        Inorder(node.left);
        node.left = null;
        curr.right = node;
        curr = node;
        Inorder(node.right);
    }
}


