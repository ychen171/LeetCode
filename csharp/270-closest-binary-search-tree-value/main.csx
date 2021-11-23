// Definition for a binary tree node.
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
    // Binary Search, O(h) time
    public int ClosestValue(TreeNode root, double target)
    {
        if (root.left == null && root.right == null) return root.val;

        var closestValue = root.val;
        while (root != null)
        {
            closestValue = Math.Abs(root.val - target) < Math.Abs(closestValue - target) ? root.val : closestValue;
            root = root.val < target ? root.right : root.left;
        }
        return closestValue;
    }

    // Recursive Inorder + Linear Search, O(n) time
    public int ClosestValueRecursiveInorder(TreeNode root, double target)
    {
        var list = DFSTraverseInorder(root, new List<int>());
        for (int i = 0; i < list.Count - 1; i++)
        {
            if (Math.Abs(list[i] - target) < Math.Abs(list[i + 1] - target))
                return list[i];
        }
        return list[list.Count - 1];
    }
    public List<int> DFSTraverseInorder(TreeNode root, List<int> list)
    {
        if (root == null) return list;
        DFSTraverseInorder(root.left, list);
        list.Add(root.val);
        DFSTraverseInorder(root.right, list);
        return list;
    }

    // Iterative Inorder, O(k) time
    public int ClosestValueIterativeInorder(TreeNode root, double target)
    {
        var closestValue = int.MinValue;
        var stack = new Stack<TreeNode>();
        while (root != null || stack.Count > 0)
        {
            while (root != null)
            {
                stack.Push(root);
                root = root.left;
            }
            root = stack.Pop();
            if (Math.Abs(closestValue - target) < Math.Abs(root.val - target))
                return closestValue;
            closestValue = root.val;
            root = root.right;
        }

        return closestValue;
    }
}





