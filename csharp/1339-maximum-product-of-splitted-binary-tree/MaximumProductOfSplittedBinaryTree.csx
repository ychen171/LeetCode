
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
    // DFS | Postorder traversal | Recursion
    // One Pass
    // Time: O(n)
    // Space: O(n)
    List<long> sumList;
    public int MaxProduct(TreeNode root)
    {
        // DFS to compute root sum
        sumList = new List<long>();
        var rootSum = TreeSum(root);
        // compute max product for each node
        long ans = 0;
        foreach (var sum in sumList)
        {
            ans = Math.Max(ans, (rootSum - sum) * sum);
        }
        return (int)(ans % 1000000007);
    }

    // return sum for of curr subtree
    public long TreeSum(TreeNode node)
    {
        // base case
        if (node == null)
            return 0;

        // recursive case
        var sub1 = TreeSum(node.left);
        var sub2 = TreeSum(node.right);
        var result = node.val + sub1 + sub2;
        sumList.Add(result);
        return result;
    }
}
