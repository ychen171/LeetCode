
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
    // Prefix Sum + DFS
    // Time: O(n)
    // Space: O(n)
    int ans = 0;
    Dictionary<long, int> preSumCount = new Dictionary<long, int>();
    public int PathSum(TreeNode root, int targetSum)
    {
        if (root == null)
            return 0;
        // preset
        preSumCount[0] = 1;
        // 
        Helper(root, targetSum, 0);
        return ans;
    }

    public void Helper(TreeNode node, long targetSum, long currSum)
    {
        // base case
        if (node == null)
            return;

        // recursive case
        currSum += node.val;
        ans += preSumCount.GetValueOrDefault(currSum - targetSum, 0);
        preSumCount[currSum] = preSumCount.GetValueOrDefault(currSum, 0) + 1;

        Helper(node.left, targetSum, currSum);
        Helper(node.right, targetSum, currSum);

        preSumCount[currSum]--;
        currSum -= node.val;
    }
}