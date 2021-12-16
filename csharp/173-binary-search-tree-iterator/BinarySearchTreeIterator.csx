
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

// DFS Inorder Iterative using Stack and Queue
// Time: O(N)
// Space: O(N)
public class BSTIterator
{
    TreeNode curr;
    Queue<TreeNode> queue;

    public BSTIterator(TreeNode root)
    {
        var stack = new Stack<TreeNode>();
        queue = new Queue<TreeNode>();
        curr = root;
        while (curr != null || stack.Count != 0)
        {
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.left;
            }
            curr = stack.Pop();
            queue.Enqueue(curr);
            curr = curr.right;
        }
    }

    public int Next()
    {
        return queue.Dequeue().val;
    }

    public bool HasNext()
    {
        return queue.Count != 0;
    }
}

// DFS Inorder Iterative using Stack only (BETTER Space)
// Time: O(N)
// Space: O(H)
public class BSTIterator2
{
    TreeNode curr;
    Stack<TreeNode> stack;

    public BSTIterator2(TreeNode root)
    {
        stack = new Stack<TreeNode>();
        curr = root;
        while (curr != null)
        {
            stack.Push(curr);
            curr = curr.left;
        }
    }

    public int Next()
    {
        int result = -1;
        if (stack.Count != 0)
        {
            curr = stack.Pop();
            result = curr.val;
            curr = curr.right;
        }
        while (curr != null)
        {
            stack.Push(curr);
            curr = curr.left;
        }
        return result;
    }

    public bool HasNext()
    {
        return stack.Count != 0;
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */







