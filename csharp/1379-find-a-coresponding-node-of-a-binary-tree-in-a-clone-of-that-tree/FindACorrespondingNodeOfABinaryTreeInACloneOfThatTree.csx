
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}


public class Solution
{
    // BFS
    // Time: O(n)
    // Space: O(n)
    public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
    {
        if (original == target)
            return cloned;
        
        var queue = new Queue<TreeNode>();
        TreeNode curr = original;
        queue.Enqueue(curr);
        int targetCount = 0;
        while (queue.Count != 0)
        {
            curr = queue.Dequeue();
            targetCount++;
            if (curr == target)
                break;
            if (curr.left != null)
                queue.Enqueue(curr.left);
            if (curr.right != null)
                queue.Enqueue(curr.right);
        }

        queue.Clear();
        curr = cloned;
        queue.Enqueue(curr);
        int count = 0;
        while (queue.Count != 0)
        {
            curr = queue.Dequeue();
            count++;
            if (count == targetCount)
                return curr;
            if (curr.left != null)
                queue.Enqueue(curr.left);
            if (curr.right != null)
                queue.Enqueue(curr.right);
        }

        return curr;
    }
}
