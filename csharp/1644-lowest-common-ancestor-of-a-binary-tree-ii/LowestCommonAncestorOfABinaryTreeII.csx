
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution
{
    // Recursion
    // Time: O(n)
    // Spaece: O(n)
    bool foundP = false;
    bool foundQ = false;
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        var ans = LCA(root, p, q);
        return foundP && foundQ ? ans : null;
    }

    private TreeNode LCA(TreeNode root, TreeNode p, TreeNode q)
    {
        // base case
        if (root == null)
            return null;

        // recursive case
        var left = LCA(root.left, p, q);
        var right = LCA(root.right, p, q);
        if (left != null && right != null)
            return root;
        if (root.val == p.val || root.val == q.val)
        {
            if (root.val == p.val)
                foundP = true;
            else
                foundQ = true;
            
            return root;
        }

        return left ?? right;
    }
}
