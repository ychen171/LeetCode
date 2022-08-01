
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
    // Recursion
    // Time: O(4^n/n^(1/2))    ???
    // Space: O(4^n/n^(1/2))   ???
    public IList<TreeNode> GenerateTrees(int n)
    {
        return Helper(1, n);
    }
    public List<TreeNode> Helper(int start, int end)
    {
        var allNodes = new List<TreeNode>();
        if (start > end)
        {
            allNodes.Add(null);
            return allNodes;
        }
        // pick up a root
        for (int i = start; i <= end; i++)
        {
            // all possible left subtrees if i is choosen to be a root
            var leftNodes = Helper(start, i - 1);
            var rightNodes = Helper(i + 1, end);
            // connect left and right trees to the root i
            foreach (var leftNode in leftNodes)
            {
                foreach (var rightNode in rightNodes)
                {
                    var currNode = new TreeNode(i);
                    currNode.left = leftNode;
                    currNode.right = rightNode;
                    allNodes.Add(currNode);
                }
            }
        }
        return allNodes;
    }

    // DP | Memoization | Recursion
    // Time: O(n^2)
    // Space: O(n^2)
    List<TreeNode>[][] memo;
    public IList<TreeNode> GenerateTrees2(int n)
    {
        memo = new List<TreeNode>[n + 1][];
        for (int i = 0; i < n + 1; i++)
            memo[i] = new List<TreeNode>[n + 1];
        return GenerateTreesMemo(1, n);
    }
    public List<TreeNode> GenerateTreesMemo(int start, int end)
    {
        // base case
        if (start > end)
        {
            return new List<TreeNode>() { null };
        }

        if (memo[start][end] != null)
            return memo[start][end];

        // recursive case
        var allNodes = new List<TreeNode>();
        for (int i = start; i <= end; i++)
        {
            // all possible left subtrees if i is choosen to be a root
            var leftNodes = GenerateTreesMemo(start, i - 1);
            var rightNodes = GenerateTreesMemo(i + 1, end);
            // connect left and right trees to the root i
            foreach (var leftNode in leftNodes)
            {
                foreach (var rightNode in rightNodes)
                {
                    var currNode = new TreeNode(i);
                    currNode.left = leftNode;
                    currNode.right = rightNode;
                    allNodes.Add(currNode);
                }
            }
        }
        memo[start][end] = allNodes;
        return allNodes;
    }
}






