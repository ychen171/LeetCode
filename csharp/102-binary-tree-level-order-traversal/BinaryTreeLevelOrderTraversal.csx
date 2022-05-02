
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
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var ans = new List<IList<int>>();
        if (root == null) return ans;

        var queue = new Queue<TreeNode>();
        TreeNode curr = root;
        queue.Enqueue(curr);
        int level = 0;
        while (queue.Count != 0)
        {
            int levelLen = queue.Count;
            ans.Add(new List<int>());
            for (int i = 0; i < levelLen; i++)
            {
                curr = queue.Dequeue();
                ans[level].Add(curr.val);
                if (curr.left != null)
                    queue.Enqueue(curr.left);
                if (curr.right != null)
                    queue.Enqueue(curr.right);
            }
            level++;
        }

        return ans;
    }
}

