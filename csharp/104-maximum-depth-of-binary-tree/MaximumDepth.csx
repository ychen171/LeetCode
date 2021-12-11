
using System;
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
    // Bottom-up Recursion | DFS Postorder
    // Time: O(n)
    // Space: O(n) in worst, O(log(n)) in best
    public int MaxDepth1(TreeNode root)
    {
        if (root == null) return 0;
        int left = MaxDepth1(root.left);
        int right = MaxDepth1(root.right);
        return Math.Max(left, right) + 1;
    }

    // Taill Recursion | BFS
    // Time: O(n)
    // Space: O(n) in worst, O(log(n)) in best
    private Queue<Tuple<TreeNode, int>> queue;
    int depth = 0;
    public int MaxDepth2(TreeNode root)
    {
        if (root == null) return 0;
        queue.Enqueue(new Tuple<TreeNode, int>(root, 0));
        return NextMaxDepth();
    }
    private int NextMaxDepth()
    {
        if (queue.Count == 0)
            return depth;
        var tuple = queue.Dequeue();
        var curr = tuple.Item1;
        var nextLevel = tuple.Item2 + 1;
        depth = Math.Max(depth, nextLevel);
        if (curr.left != null)
            queue.Enqueue(new Tuple<TreeNode, int>(curr.left, nextLevel));
        if (curr.right != null)
            queue.Enqueue(new Tuple<TreeNode, int>(curr.right, nextLevel));
        // the last action should be the ONLY recursive call
        // in the tail recursion
        return NextMaxDepth();
    }

    // Iteration
    // Time: O(n)
    // Space: O(n) in worst, O(log(n)) in best
    public int MaxDepth3(TreeNode root)
    {
        var nodeStack = new Stack<TreeNode>();
        var depthStack = new Stack<int>();
        if (root == null) return 0;

        TreeNode curr = root;
        int currDepth = 1;
        int maxDepth = 0;
        nodeStack.Push(curr);
        depthStack.Push(currDepth);
        while (nodeStack.Count != 0)
        {
            curr = nodeStack.Pop();
            currDepth = depthStack.Pop();
            maxDepth = Math.Max(maxDepth, currDepth);
            if (curr.left != null)
            {
                nodeStack.Push(curr.left);
                depthStack.Push(currDepth + 1);
            }
            if (curr.right != null)
            {
                nodeStack.Push(curr.right);
                depthStack.Push(currDepth + 1);
            }
        }
        return maxDepth;
    }
}




