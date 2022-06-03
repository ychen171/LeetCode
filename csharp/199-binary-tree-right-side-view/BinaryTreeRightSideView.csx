
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
    // Time: O(n), n = the number of nodes
    // Space: O(d), d = the diameter of the tree
    public IList<int> RightSideView(TreeNode root)
    {
        // BFS, starting from root node
        // at each level, starting from left to right; add the value of last node into list
        var result = new List<int>();
        if (root == null)
            return result;
        
        var queue = new Queue<TreeNode>();
        TreeNode curr = root;
        queue.Enqueue(curr);
        while (queue.Count != 0)
        {
            int levelLen = queue.Count; // the width of current level
            for (int i = 0; i < levelLen; i++)
            {
                curr = queue.Dequeue();
                if (curr.left != null)
                    queue.Enqueue(curr.left);
                if (curr.right != null)
                    queue.Enqueue(curr.right);
            }
            result.Add(curr.val);
        }

        return result;
    }
}
