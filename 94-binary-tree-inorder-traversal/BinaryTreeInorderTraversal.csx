
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
    // DFS Inorder traversal
    // Time: O(n)
    // Space: O(h)
    public IList<int> InorderTraversal(TreeNode root)
    {
        var stack = new Stack<TreeNode>();
        var ans = new List<int>();
        TreeNode curr = root;

        while (curr != null || stack.Count != 0)
        {
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.left;
            }
            curr = stack.Pop();
            // do something
            ans.Add(curr.val);
            curr = curr.right;
        }

        return ans;
    }
}

