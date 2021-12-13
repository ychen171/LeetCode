
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
    // BFS traversal
    // Time: O(n)
    // Space: O(n)
    // public int CountUnivalSubtrees(TreeNode root)
    // {
    //     if (root == null) return 0;
    //     var queue = new Queue<TreeNode>();
    //     var curr = root;
    //     var target = root.val;
    //     int count = 0;
    //     queue.Enqueue(curr);
    //     while (queue.Count != 0)
    //     {
    //         curr = queue.Dequeue();
    //         if (curr.left != null && curr.right == null)
    //         {
    //             queue.Enqueue(curr.left);
    //             if (curr.val == target && curr.left.val == target) count++;
    //         }
    //         else if (curr.left == null && curr.right != null)
    //         {
    //             queue.Enqueue(curr.right);
    //             if (curr.val == target && curr.right.val == target) count++;
    //         }
    //         else if (curr.left != null && curr.right != null)
    //         {
    //             queue.Enqueue(curr.left);
    //             queue.Enqueue(curr.right);
    //             if (curr.val == target && curr.left.val == target && curr.right.val == target) count++;
    //         }
    //         else
    //         {
    //             if (curr.val == target) count++;
    //         }
    //     }
    //     return count;
    // }

    // Recursive DFS
    // Time: O(N)
    // Space: O(H)
    private int count = 0;
    public int CountUnivalSubtrees1(TreeNode root)
    {
        if (root == null) return 0;
        IsUnival(root, 0);
        return count;
    }

    private bool IsUnival(TreeNode node, int target)
    {
        // base case
        if (node == null) return true;
        // recursive case
        if (IsUnival(node.left, node.val) & IsUnival(node.right, node.val))
        {
            count++;
            return node.val == target;
        }
        return false;
    }

    // Recursive DFS
    // Time: O(N)
    // Space: O(H)
    public int CountUnivalSubtrees2(TreeNode root)
    {
        if (root == null) return 0;
        IsUnivalSubtrees(root);
        return count;
    }

    private bool IsUnivalSubtrees(TreeNode node)
    {
        // base case
        if (node.left == null && node.right == null)
        {
            count++;
            return true;
        }
        // recursive case
        bool isUnival = true;
        if (node.left != null)
            isUnival = IsUnivalSubtrees(node.left) && isUnival && node.left.val == node.val;
        if (node.right != null)
            isUnival = IsUnivalSubtrees(node.right) && isUnival && node.right.val == node.val;

        if (isUnival)
        {
            count++;
            return true;
        }
        return false;
    }
}







