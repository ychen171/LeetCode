
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
    public IList<int> InorderTraversal(TreeNode root)
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
    // Morris Traversal
    // Time: O(n)
    // Space: O(1)
    public IList<int> InorderMorrisTraversal(TreeNode root)
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
                while (pred.right != null)
                    pred = pred.right;

                pred.right = curr; // put curr node after pred node
                var temp = curr;   // store curr node
                curr = curr.left;  // move to left subtree
                temp.left = null;  // original curr left to be null to avoid infinite loop
            }
            else
            {
                list.Add(curr.val);
                curr = curr.right; // move to right node
            }
        }
        return list;
    }
}








