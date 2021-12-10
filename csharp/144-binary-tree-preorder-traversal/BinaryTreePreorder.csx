
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
    // Stack Iterative 
    // Time: O(n)
    // Space: O(n)
    public IList<int> PreorderTraversal(TreeNode root)
    {
        var list = new List<int>();
        var stack = new Stack<TreeNode>();
        var curr = root;
        while (curr != null || stack.Count != 0)
        {
            while (curr != null)
            {
                stack.Push(curr);
                list.Add(curr.val);
                curr = curr.left;
            }
            curr = stack.Pop();
            curr = curr.right;
        }
        return list;
    }

    // Morris traversal
    // Time: O(n)
    // Space: O(1)
    public IList<int> PreorderMorrisTraversal(TreeNode root)
    {
        var list = new List<int>();
        TreeNode curr = root;
        TreeNode pred = null;
        while (curr != null)
        {
            if (curr.left != null) // has a left subtree
            {
                // find the predecessor
                pred = curr.left;
                while (pred.right != null && pred.right != curr)
                    pred = pred.right;

                if (pred.right == null) // the predecessor has not been visited
                {
                    list.Add(curr.val); // add parent value to list
                    pred.right = curr;  // link predecessor to curr node
                    curr = curr.left;   // move to left subtree
                }
                else // the predecessor has been visited
                {
                    pred.right = null; // reset
                    curr = curr.right; // move to right subtree
                }
            }
            else // has no left subtree
            {
                list.Add(curr.val);
                curr = curr.right; // move curr to its successor
            }
        }
        return list;
    }
}





