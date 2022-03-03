
using System.Linq;
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
        IList<IList<int>> result = new List<IList<int>>();
        if (root == null) return result;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int level = 0;
        TreeNode curr;
        while (queue.Count != 0)
        {
            result.Add(new List<int>());
            var length = queue.Count;
            for (int i=0; i<length; i++)
            {
                curr = queue.Dequeue();
                if (level % 2 == 0)
                    result[level].Add(curr.val);
                else
                    result[level].Insert(0, curr.val);
                if (curr.left != null)
                    queue.Enqueue(curr.left);
                if (curr.right != null)
                    queue.Enqueue(curr.right);
            }
            level++;
        }

        return result;
    }
}

