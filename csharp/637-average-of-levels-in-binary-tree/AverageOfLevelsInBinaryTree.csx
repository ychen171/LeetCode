
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
    // BFS
    // Time: O(n)
    // Space: O(n)
    public IList<double> AverageOfLevels(TreeNode root)
    {
        var result = new List<double>();
        if (root == null)
            return result;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count != 0)
        {
            int levelLen = queue.Count;
            double levelSum = 0;
            for (int i = 0; i < levelLen; i++)
            {
                var curr = queue.Dequeue();
                levelSum += curr.val;
                if (curr.left != null)
                    queue.Enqueue(curr.left);
                if (curr.right != null)
                    queue.Enqueue(curr.right);
            }
            result.Add(levelSum / levelLen);
        }

        return result;
    }
}
