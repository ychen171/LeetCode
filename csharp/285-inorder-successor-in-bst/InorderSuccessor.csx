
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution
{
    // DFS Inorder traversal Iterative
    // Time: O(N)
    // Space: O(N)
    public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
    {
        if (root == null) return null;
        var stack = new Stack<TreeNode>();
        TreeNode curr = root;
        TreeNode prev = null;
        while (curr != null || stack.Count != 0)
        {
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.left;
            }
            curr = stack.Pop();
            if (prev != null && prev.val == p.val && p.val < curr.val)
                return curr;
            prev = curr;
            curr = curr.right;
        }
        return null;
    }
    // DFS Inorder traversal Recursive
    // Time: O(N)
    // Space: O(N)
    private TreeNode successor = null;
    private TreeNode prev = null;
    public TreeNode InorderSuccessorRecursive(TreeNode root, TreeNode p)
    {
        DFSInorder(root, p);
        return successor;
    }
    private void DFSInorder(TreeNode node, TreeNode p)
    {
        if (node == null) return;

        DFSInorder(node.left, p);
        if (prev == p && successor == null)
        {
            successor = node;
            return;
        }
        prev = node;
        DFSInorder(node.right, p);
    }

    // Using BST properties (left subtree < root < right subtree)
    // Time: O(N)
    // Space: O(1)
    public TreeNode InorderSuccessor2(TreeNode root, TreeNode p)
    {
        TreeNode successor = null;
        var curr = root;
        while (curr != null)
        {
            if (curr.val <= p.val)
                curr = curr.right;
            else
            {
                successor = curr;
                curr = curr.left;
            }
        }
        return successor;
    }
}








