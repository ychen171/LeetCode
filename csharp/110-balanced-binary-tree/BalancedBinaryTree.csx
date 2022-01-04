
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
    // BFS Traversal
    // Time: O(N)
    // Space: O(N)
    public bool IsBalanced(TreeNode root)
    {
        if (root == null) return true;
        var queue = new Queue<TreeNode>();
        var curr = root;
        queue.Enqueue(curr);
        int levelLength = 1;
        bool hasLeaf = false;
        while (queue.Count != 0 && !hasLeaf)
        {
            levelLength = queue.Count;
            for (int i = 0; i < levelLength; i++)
            {
                curr = queue.Dequeue();
                if (curr.left != null) queue.Enqueue(curr.left);
                if (curr.right != null) queue.Enqueue(curr.right);
            }
            if (curr.left == null && curr.right == null)
                hasLeaf = true;
        }
        if (hasLeaf)
        {
            while (queue.Count != 0)
            {
                curr = queue.Dequeue();
                if (curr.left != null || curr.right != null)
                    return false;
            }
        }
        return true;
    }

    // Top-down recursion
    // Time: O(n log n)
    // Space: O(n)
    private int Height(TreeNode root)
    {
        // base case: an empty tree has height -1
        if (root == null) return -1;
        return 1 + Math.Max(Height(root.left), Height(root.right));
    }
    public bool IsBalanced1(TreeNode root)
    {
        if (root == null) return true;
        return Math.Abs(Height(root.left) - Height(root.right)) < 2
            && IsBalanced1(root.left) && IsBalanced1(root.right);
    }

    // Bottom-up recursion
    // Time: O(n)
    // Space: O(n)
    private TreeInfo IsBalancedTreeHelper(TreeNode root)
    {
        // return whether or not the tree at root is balanced 
        // while also storing the tree's height in a reference variable
        // base case: an empty tree is balanced and has height = -1
        if (root == null) return new TreeInfo(-1, true);
        // check subtrees to see if they are balanced
        TreeInfo left = IsBalancedTreeHelper(root.left);
        if (!left.balanced) return new TreeInfo(-1, false);
        TreeInfo right = IsBalancedTreeHelper(root.right);
        if (!right.balanced) return new TreeInfo(-1, false);
        // use the height obtained from recursive calls to 
        // determine if the current node is also balanced
        if (Math.Abs(left.height - right.height) < 2)
            return new TreeInfo(1 + Math.Max(left.height, right.height), true);
        return new TreeInfo(-1, false);
    }

    public bool IsBalanced2(TreeNode root)
    {
        return IsBalancedTreeHelper(root).balanced;
    }

    // Simplier Bottom-up recursion
    // Time: O(n)
    // Space: O(n)
    public bool IsBalanced3(TreeNode root)
    {
        return GetHeight(root) != -1;
    }
    private int GetHeight(TreeNode root)
    {
        if (root == null) return 0;

        int left = GetHeight(root.left);
        int right = GetHeight(root.right);

        if (left == -1 || right == -1 || Math.Abs(left - right) > 1) return -1;
        return 1 + Math.Max(left, right);
    }
}
class TreeInfo
{
    public int height;
    public bool balanced;
    public TreeInfo(int height, bool balanced)
    {
        this.height = height;
        this.balanced = balanced;
    }
}






