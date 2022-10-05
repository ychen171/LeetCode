
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
    // DFS Recursion
    // Time: O(n)
    // Space: O(n)
    int val;
    int depth;
    public TreeNode AddOneRow(TreeNode root, int val, int depth)
    {
        this.val = val;
        this.depth = depth;
        // edge case
        if (depth == 1)
        {
            var node = new TreeNode(val, root, null);
            return node;
        }
        // DFS
        Helper(root, 1);
        return root;
    }

    private void Helper(TreeNode node, int level)
    {
        // base case
        if (node == null)
            return;
        if (level == depth)
            return;

        if (level == depth - 1)
        {
            var leftNew = new TreeNode(val);
            var rightNew = new TreeNode(val);
            leftNew.left = node.left;
            rightNew.right = node.right;
            node.left = leftNew;
            node.right = rightNew;
            return;
        }
        // recursive case
        Helper(node.left, level + 1);
        Helper(node.right, level + 1);
    }

    // BFS Iteration
    // Time: O(n)
    // Space: O(n)
    public TreeNode AddOneRow1(TreeNode root, int val, int depth)
    {
        this.val = val;
        this.depth = depth;
        // edge case
        if (depth == 1)
        {
            var node = new TreeNode(val, root, null);
            return node;
        }
        // BFS
        var queue = new Queue<TreeNode>();
        var parentQueue = new Queue<TreeNode>();
        var curr = root;
        queue.Enqueue(curr);
        int level = 1;
        while (queue.Count != 0)
        {
            int levelLen = queue.Count;
            for (int i = 0; i < levelLen; i++)
            {
                curr = queue.Dequeue();
                // keep the nodes from depth - 1
                if (level == depth - 1)
                    parentQueue.Enqueue(curr);
                if (curr.left != null)
                    queue.Enqueue(curr.left);
                if (curr.right != null)
                    queue.Enqueue(curr.right);
            }
            level++;
            if (level == depth)
                break;
        }
        while (parentQueue.Count != 0)
        {
            curr = parentQueue.Dequeue();
            var leftNew = new TreeNode(val);
            var rightNew = new TreeNode(val);
            leftNew.left = curr.left;
            rightNew.right = curr.right;
            curr.left = leftNew;
            curr.right = rightNew;
        }

        return root;
    }
}
