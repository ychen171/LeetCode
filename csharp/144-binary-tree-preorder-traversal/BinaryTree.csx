
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
    // Iterative
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
}





