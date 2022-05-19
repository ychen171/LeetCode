
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
    // DFS | Bottom-up | Recursion
    // Time: O(n)
    // Space: O(h)
    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null)
            return null;
        
        DFS(root);
        return root;
    }

    private TreeNode DFS(TreeNode node)
    {
        // base case
        if (node == null)
            return node;
        
        // recursive case
        var leftChild = DFS(node.right);
        var rightChild = DFS(node.left);
        node.left = leftChild;
        node.right = rightChild;
        return node;
    }
}
