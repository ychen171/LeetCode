
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
    // DP | Memoization Recursion
    // Time: O(n)
    // Space: O(n)
    Dictionary<TreeNode, int> memo;
    public int Rob(TreeNode root)
    {
        memo = new Dictionary<TreeNode, int>();
        return Helper(root);
    }

    public int Helper(TreeNode root)
    {
        // base case
        if (root == null)
            return 0;

        if (memo.ContainsKey(root))
            return memo[root];

        // recursive case
        int rootRobbed = root.val
            + (root.left == null ? 0 : Helper(root.left.left) + Helper(root.left.right))
            + (root.right == null ? 0 : Helper(root.right.left) + Helper(root.right.right));
        int rootNotRobbed = Helper(root.left) + Helper(root.right);

        int ans = Math.Max(rootRobbed, rootNotRobbed);
        memo[root] = ans;
        return ans;
    }

    // DFS | Postorder | Recursion
    // Time: O(n)
    // Spaec: O(n)
    public int Rob1(TreeNode root)
    {
        return HelperOptimized(root).Max();
    }

    public int[] HelperOptimized(TreeNode root)
    {
        // return [rootNotRobbed, rootRobbed]
        // base case
        if (root == null)
            return new int[2];

        // recursive case
        int[] leftResult = HelperOptimized(root.left);
        int[] rightResult = HelperOptimized(root.right);
        int rootNotRobbed = leftResult.Max() + rightResult.Max();
        int rootRobbed = root.val + leftResult[0] + rightResult[0];

        var rootResult = new int[] { rootNotRobbed, rootRobbed };
        return rootResult;
    }

    // DP | Tabulation
    public int RobTabulation(TreeNode root)
    {
        /*
            h: tree height/level
            states: dp[i][s], i: level index [0, h - 1], s: 0 unrobbed, 1 robbed
            options: rob, skip
            goal: Math.Max(dp[n-1][0], dp[n-1][1])

            dp[i][0] = Math.Max(dp[i-1][1], dp[i-1][0])
            dp[i][1] = Math.Max(dp[i-1][1], dp[i-1][0] + levelSum[i])

            base case:
            dp[-1][0] = 0
            dp[-1][1] = int.MinValue
        */

        if (root == null)
            return 0;

        var dp = new List<int[]>();

        var queue = new Queue<TreeNode>();
        TreeNode curr = root;
        queue.Enqueue(curr);
        int i = 0;
        while (queue.Count != 0)
        {
            int levelLen = queue.Count;
            int levelSum = 0;
            for (int k = 0; k < levelLen; k++)
            {
                curr = queue.Dequeue();
                levelSum += curr.val;
                if (curr.left != null)
                    queue.Enqueue(curr.left);
                if (curr.right != null)
                    queue.Enqueue(curr.right);
            }

            dp.Add(new int[2]);
            if (i - 1 == -1)
            {
                dp[i][0] = 0;
                dp[i][1] = levelSum;
            }
            else
            {
                dp[i][0] = Math.Max(dp[i - 1][1], dp[i - 1][0]);
                dp[i][1] = Math.Max(dp[i - 1][1], dp[i - 1][0] + levelSum);
            }
            i++;
        }

        return dp[dp.Count - 1].Max();
    }
}

