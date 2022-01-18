
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

    // Memoizied Recursion
    // Time:
    // Space: 
    public IList<TreeNode> GenerateTrees2(int n)
    {
        return GenerateTreesMemo(1, n, new Dictionary<string, List<TreeNode>>());
    }
    public List<TreeNode> GenerateTreesMemo(int start, int end, Dictionary<string, List<TreeNode>> memo)
    {
        var key = $"{start},{end}";
        if (memo.ContainsKey(key)) return memo[key];

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
            var leftNodes = GenerateTreesMemo(start, i - 1, memo);
            var rightNodes = GenerateTreesMemo(i + 1, end, memo);
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
        memo[key] = allNodes;
        return allNodes;
    }
}






