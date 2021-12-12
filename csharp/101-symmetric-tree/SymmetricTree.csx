
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
    // Doesn't work!!!
    // DFS inorder traversal
    // Time: O(n)
    // Space: O(n)
    public bool IsSymmetric(TreeNode root)
    {
        // Inorder traverse and store value in list
        var list = TraverseInorder(root);
        // iterate item from the beginning and the end at the same time and compare the value
        for (int i = 0; i < list.Count / 2; i++)
        {
            var left = list[i];
            var right = list[list.Count - 1 - i];
            if (left != right)
                return false;
        }
        return true;
    }
    private List<int> TraverseInorder(TreeNode root)
    {
        var list = new List<int>();
        var stack = new Stack<TreeNode>();
        var curr = root;
        while (curr != null || stack.Count != 0)
        {
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.left;
            }
            curr = stack.Pop();
            list.Add(curr.val);
            curr = curr.right;
        }
        return list;
    }

    // Recrusive (Top-down)
    // Time: O(n)
    // Space: O(n)
    public bool IsSymmetric2(TreeNode root)
    {
        return IsMirror(root, root);
    }
    private bool IsMirror(TreeNode node1, TreeNode node2)
    {
        if (node1 == null && node2 == null) return true;
        if (node1 == null || node2 == null) return false;
        return (node1.val == node2.val) && IsMirror(node1.right, node2.left) && IsMirror(node1.left, node2.right);
    }
    
    // Iterative BFS
    // Time: O(n)
    // Space: O(n)
    public bool IsSymmetric3(TreeNode root)
    {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        queue.Enqueue(root);
        while (queue.Count != 0)
        {
            var node1 = queue.Dequeue();
            var node2 = queue.Dequeue();
            if (node1 == null && node2 == null) continue;
            if (node1 == null || node2 == null) return false;
            if (node1.val != node2.val) return false;
            queue.Enqueue(node1.left);
            queue.Enqueue(node2.right);
            queue.Enqueue(node1.right);
            queue.Enqueue(node2.left);
        }
        return true;
    }
}





