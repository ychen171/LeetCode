
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}


public class Solution
{
    // BFS Preorder traversal
    // Time: O(N)
    // Space: O(N)
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        var queue = new Queue<TreeNode>();
        var curr = root;
        queue.Enqueue(curr);
        while (queue.Count != 0)
        {
            curr = queue.Dequeue();
            if ((curr.val - p.val) * (curr.val - q.val) <=0)
                return curr;
            if (curr.left != null) queue.Enqueue(curr.left);
            if (curr.right != null) queue.Enqueue(curr.right);
        }
        return null;
    }
    // Iterative
    // Time: O(N)
    // Space: O(1)
    public TreeNode LowestCommonAncestor1(TreeNode root, TreeNode p, TreeNode q)
    {
        var curr = root;
        while (curr != null)
        {
            if (curr.val < p.val && curr.val < q.val)
                curr = curr.right;
            else if (curr.val > p.val && curr.val > q.val)
                curr = curr.left;
            else
                return curr;
        }
        return null;
    }
}








