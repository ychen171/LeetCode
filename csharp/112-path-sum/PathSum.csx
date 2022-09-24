
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
    // Recursive
    // Time: O(n)
    // Space: O(n)
    public bool HasPathSum(TreeNode root, int targetSum)
    {
        // base case
        if (root == null)
            return false;
        if (root.left == null && root.right == null)
            return root.val == targetSum;

        // recursive case
        return HasPathSum(root.left, targetSum - root.val) || HasPathSum(root.right, targetSum - root.val);
    }

    // Iterative (DFS)
    // Time: O(n)
    // Space: O(n) in worst, O(log(n)) in best
    public bool HasPathSumIterative(TreeNode root, int targetSum)
    {
        if (root == null) return false;
        var nodeStack = new Stack<TreeNode>();
        var sumStack = new Stack<int>();
        nodeStack.Push(root);
        sumStack.Push(targetSum - root.val);
        while (nodeStack.Count != 0)
        {
            var node = nodeStack.Pop();
            var sum = sumStack.Pop();
            if (node.left == null && node.right == null && sum == 0)
                return true;
            if (node.left != null)
            {
                nodeStack.Push(node.left);
                sumStack.Push(sum - node.left.val);
            }
            if (node.right != null)
            {
                nodeStack.Push(node.right);
                sumStack.Push(sum - node.right.val);
            }
        }
        return false;
    }
}



