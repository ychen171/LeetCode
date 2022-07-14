
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
    // BFS
    // Time: O(n)
    // Space: O(n)
    public int MinDepth(TreeNode root)
    {
        if (root == null)
            return 0;

        var queue = new Queue<TreeNode>();
        TreeNode curr = root;
        queue.Enqueue(curr);
        int level = 1;
        while (queue.Count != 0)
        {
            int levelLen = queue.Count;
            for (int i = 0; i < levelLen; i++)
            {
                curr = queue.Dequeue();
                if (curr.left == null && curr.right == null)
                    return level;
                if (curr.left != null)
                    queue.Enqueue(curr.left);
                if (curr.right != null)
                    queue.Enqueue(curr.right);
            }
            level++;
        }

        return -1;
    }

    // DFS
    // Time: O(n)
    // Space: O(n)
    public int MinDepth1(TreeNode root)
    {
        if (root == null)
            return 0;
        return Helper(root);
    }

    public int Helper(TreeNode node)
    {
        // base case
        if (node == null)
            return int.MaxValue;
        if (node.left == null && node.right == null)
            return 1;

        // recursive case
        int leftChild = Helper(node.left);
        int rightChild = Helper(node.right);
        return Math.Min(leftChild, rightChild) + 1;
    }
}
