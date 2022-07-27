
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
    // Recursion
    // Time: O(n)
    // Space: O(n)
    public void Flatten(TreeNode root)
    {
        Helper(root);
    }

    public TreeNode Helper(TreeNode node)
    {
        // return tail after flatten
        // base case
        if (node == null)
            return null;

        // recursive case
        var leftTail = Helper(node.left);
        var rightTail = Helper(node.right);

        if (leftTail != null)
        {
            leftTail.right = node.right;
            node.right = node.left;
            node.left = null;
        }

        return rightTail ?? leftTail ?? node;
    }

    // Recursion
    // Time: O(n)
    // Space: O(n)
    public void Flatten1(TreeNode root)
    {
        // base case
        if (root == null)
            return;

        // recursive case
        Flatten1(root.left);
        Flatten1(root.right);
        
        var leftNode = root.left;
        var rightNode = root.right;

        root.right = leftNode;
        root.left = null;

        TreeNode p = root;
        while (p.right != null)
            p = p.right;
        
        p.right = rightNode;
    }

    // Reverse Inorder Traversal
    // Time: O(n)
    // Space: O(n)
    TreeNode head;
    public void Flatten2(TreeNode root)
    {
        // base case 
        if (root == null)
            return;

        // recursive case
        Flatten2(root.right);
        Flatten2(root.left);
        root.right = head;
        root.left = null;
        head = root;
    }

    // Iteration
    // Time: O(n)
    // Space: O(1)
    public void FlattenI(TreeNode root)
    {
        if (root == null)
            return;
        
        TreeNode curr = root;

        while (curr != null)
        {
            if (curr.left != null)
            {
                TreeNode rightMost = curr.left;
                while (rightMost.right != null)
                {
                    rightMost = rightMost.right;
                }
                rightMost.right = curr.right;
                curr.right = curr.left;
                curr.left = null;
            }
            curr = curr.right;
        }
    }
}
