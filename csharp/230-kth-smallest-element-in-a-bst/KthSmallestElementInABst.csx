
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
    // DFS Inorder Iteration
    // Time: O(n)
    // Space: O(n)
    public int KthSmallest(TreeNode root, int k)
    {
        var stack = new Stack<TreeNode>();
        TreeNode curr = root;
        int count = 0;
        while (curr != null || stack.Count != 0)
        {
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.left;
            }
            curr = stack.Pop();
            count++;
            if (count == k)
                return curr.val;
            curr = curr.right;
        }

        return 0;
    }

    // DFS Inorder Recursion
    // Time: O(n)
    // Space: O(n)
    int answer = 0;
    public int KthSmallest1(TreeNode root, int k)
    {
        var list = new List<int>();
        DFS(root, k, list);
        return list[k-1];
    }

    private void DFS(TreeNode node, int k, List<int> result)
    {
        // base case
        if (node == null) return;
        // recusive case
        DFS(node.left, k, result);
        result.Add(node.val);
        DFS(node.right, k, result);
    }
}
