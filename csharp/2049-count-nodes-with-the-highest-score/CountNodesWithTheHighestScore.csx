public class Solution
{
    // DFS
    // Time: O(n)
    // Space: O(n)
    int n;
    Dictionary<long, int> scoreCount;
    public int CountHighestScoreNodes(int[] parents)
    {
        // build binary tree
        this.n = parents.Length;
        var nodes = new TreeNode[n];
        for (int i = 0; i < n; i++)
            nodes[i] = new TreeNode(i);

        var root = nodes[0];
        for (int i = 1; i < n; i++)
        {
            var currNode = nodes[i];
            var parentNode = nodes[parents[i]];
            if (parentNode.left == null)
                parentNode.left = currNode;
            else
                parentNode.right = currNode;
        }

        // DFS to compute size ans score
        scoreCount = new Dictionary<long, int>();
        GetSize(root);
        long maxScore = 0;
        int result = 0;
        foreach (var score in scoreCount.Keys)
        {
            if (score > maxScore)
            {
                maxScore = score;
                result = scoreCount[maxScore];
            }
        }
        return result;
    }

    private int GetSize(TreeNode node)
    {
        // base case 
        if (node == null)
            return 0;

        // recursive case
        var left = GetSize(node.left);
        var right = GetSize(node.right);
        var result = 1 + left + right;
        long l = left == 0 ? 1 : left;
        long r = right == 0 ? 1 : right;
        long p = n - result == 0 ? 1 : n - result;
        long score = l * r * p;
        scoreCount[score] = scoreCount.GetValueOrDefault(score, 0) + 1;
        return result;
    }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
