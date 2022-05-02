
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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        var ans = new List<IList<int>>();
        if (root == null) return ans;

        int level = 0;
        TreeNode curr = root;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(curr);

        while (queue.Count != 0)
        {
            int levelLen = queue.Count;
            var levelList = new List<int>();
            for (int i = 0; i < levelLen; i++)
            {
                curr = queue.Dequeue();
                levelList.Add(curr.val);

                if (curr.left != null)
                    queue.Enqueue(curr.left);
                if (curr.right != null)
                    queue.Enqueue(curr.right);
            }
            if (level % 2 != 0)
                levelList.Reverse();
            ans.Add(levelList);
            level++;
        }

        return ans;
    }
}
