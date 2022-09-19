
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
    public TreeNode ReverseOddLevels(TreeNode root)
    {
        var queue = new Queue<TreeNode>();
        TreeNode curr = root;
        queue.Enqueue(curr);
        int level = 0;
        Queue<TreeNode> oddLevelQueue = null;
        List<int> oddLevelVals = null;
        while (queue.Count != 0)
        {
            int levelLen = queue.Count;
            if (level % 2 != 0)
            {
                oddLevelQueue = new Queue<TreeNode>();
                oddLevelVals = new List<int>();
            }

            for (int i = 0; i < levelLen; i++)
            {
                curr = queue.Dequeue();
                if (curr.left != null)
                    queue.Enqueue(curr.left);
                if (curr.right != null)
                    queue.Enqueue(curr.right);

                if (level % 2 != 0)
                {
                    oddLevelQueue.Enqueue(curr);
                    oddLevelVals.Add(curr.val);
                }
            }

            if (level % 2 != 0)
            {
                for (int i = levelLen - 1; i >= 0; i--)
                {
                    curr = oddLevelQueue.Dequeue();
                    curr.val = oddLevelVals[i];
                }
            }
            level++;
        }

        return root;
    }
}
