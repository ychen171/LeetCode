
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
    // Postorder Bottom-up Recursion + Dcitionary + Key Serialization
    // Time: O(n^2)
    // Space: O()
    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
    {
        // postorder traversal
        var countDict = new Dictionary<string, int>();
        var result = new List<TreeNode>();
        Helper(root, countDict, result);
        return result;
    }

    private string Helper(TreeNode root, Dictionary<string, int> countDict, IList<TreeNode> result)
    {
        if (root == null)
            return "_";
        string leftKey = Helper(root.left, countDict, result);
        string rightKey = Helper(root.right, countDict, result);
        string key = $"{leftKey},{rightKey},{root.val}";
        countDict[key] = countDict.GetValueOrDefault(key, 0) + 1;
        if (countDict[key] == 2)
        {
            result.Add(root);
        }

        return key;
    }
}

