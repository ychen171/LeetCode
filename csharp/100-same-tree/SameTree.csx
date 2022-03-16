
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
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        // base case
        if (p == null && q == null) return true;
        if ((p == null && q != null) || (p != null && q == null)) return false;
        if (p.val != q.val) return false;
        // recursive case
        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }

    // BFS Iteration
    // Time: O(n)
    // Space: O(n)
    public bool IsSameTree2(TreeNode p, TreeNode q)
    {
        var pQueue = new Queue<TreeNode>();
        var qQueue = new Queue<TreeNode>();
        pQueue.Enqueue(p);
        qQueue.Enqueue(q);
        TreeNode currP = null;
        TreeNode currQ = null;
        while (pQueue.Count != 0 && qQueue.Count != 0)
        {
            currP = pQueue.Dequeue();
            currQ = qQueue.Dequeue();
            if (currP != null && currQ != null)
            {
                if (currP.val != currQ.val) return false;
                pQueue.Enqueue(currP.left);
                qQueue.Enqueue(currQ.left);
                pQueue.Enqueue(currP.right);
                qQueue.Enqueue(currQ.right);
            }
            else if (currP == null && currQ != null || (currP != null && currQ == null))
            {
                return false;
            }
        }
        return pQueue.Count == 0 && qQueue.Count == 0;
    }
}
