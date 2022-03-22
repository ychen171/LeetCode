
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
    // DFS | Top-down | Preorder | Recursion
    // Time: O(n)
    // Space: O(n)
    int sum = 0;
    public int SumNumbers(TreeNode root)
    {
        DFS(root, 0);
        return sum;
    }
    public void DFS(TreeNode node, int currNum)
    {
        // base case
        if (node == null) return;
        // calcuate value based on parent
        var newNum = currNum * 10 + node.val;
        if (node.left == null && node.right == null)
        {
            sum += newNum;
        }
        // pass value to subproblems
        DFS(node.left, newNum);
        DFS(node.right, newNum);
    }

    // DFS | Top-down | Preorder | Iteration
    // Time: O(n)
    // Space: O(1)
    public int SumNumbers1(TreeNode root)
    {
        var stack = new Stack<Tuple<TreeNode, int>>();
        TreeNode curr = root;
        int currNum = 0;
        int sum = 0;
        while (curr != null || stack.Count != 0)
        {
            while (curr != null)
            {
                currNum = currNum * 10 + curr.val;
                stack.Push(new Tuple<TreeNode, int>(curr, currNum));
                curr = curr.left;
            }
            var tuple = stack.Pop();
            curr = tuple.Item1;
            currNum = tuple.Item2;
            if (curr.left == null && curr.right == null)
                sum += currNum;
            curr = curr.right;
        }

        return sum;
    }
}
