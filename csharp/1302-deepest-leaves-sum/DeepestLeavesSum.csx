
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
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
    public int DeepestLeavesSum(TreeNode root)
    {
        int sum = 0;
        var queue = new Queue<TreeNode>();
        TreeNode curr = root;
        queue.Enqueue(curr);

        while (queue.Count != 0)
        {
            int levelLen = queue.Count;
            sum = 0;
            for (int i = 0; i < levelLen; i++)
            {
                curr = queue.Dequeue();
                sum += curr.val;
                if (curr.left != null)
                    queue.Enqueue(curr.left);
                if (curr.right != null)
                    queue.Enqueue(curr.right);
            }
        }

        return sum;
    }
}
