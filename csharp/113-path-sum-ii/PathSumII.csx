
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
    // DFS | Backtracking
    // Time: O(n^2)
    // Space: O(n)
    public IList<IList<int>> PathSum(TreeNode root, int targetSum)
    {
        var path = new List<int>();
        var result = new List<IList<int>>();
        Helper(root, targetSum, path, result);
        return result;
    }

    public void Helper(TreeNode node, int target, List<int> path, List<IList<int>> result)
    {
        // base case
        if (node == null)
            return;
        if (node.left == null && node.right == null)
        {
            if (target - node.val == 0)
            {
                path.Add(node.val);
                result.Add(new List<int>(path));
                path.RemoveAt(path.Count - 1);
            }
            return;
        }

        // recursive cases
        path.Add(node.val);
        Helper(node.left, target - node.val, path, result);
        Helper(node.right, target - node.val, path, result);
        path.RemoveAt(path.Count - 1);
    }
}
