
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
    // two queues
    // Time: O(n)
    // Space: O(n)
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        IList<IList<int>> list = new List<IList<int>>();
        if (root == null) return list;
        var curr = root;
        var queue1 = new Queue<TreeNode>();
        var queue2 = new Queue<TreeNode>();
        IList<int> subList = null;
        queue2.Enqueue(curr);
        while (queue1.Count != 0 || queue2.Count != 0)
        {
            if (queue1.Count == 0)
            {
                subList = new List<int>();
                list.Add(subList);
                var temp = queue1;
                queue1 = queue2;
                queue2 = temp;
            }
            curr = queue1.Dequeue();
            subList.Add(curr.val);
            if (curr.left != null)
                queue2.Enqueue(curr.left);
            if (curr.right != null)
                queue2.Enqueue(curr.right);
        }
        return list;
    }

    // Recursive
    // Time: O(n)
    // Space: O(n)
    private IList<IList<int>> result = new List<IList<int>>();
    public IList<IList<int>> LevelOrderRecursive(TreeNode root)
    {
        if (root == null) return result;
        Helper(root, 0);
        return result;
    }
    private void Helper(TreeNode node, int level)
    {
        // start a level
        if (result.Count == level)
            result.Add(new List<int>());
        // populate current level
        result[level].Add(node.val);
        // process child nodes
        if (node.left != null)
            Helper(node.left, level + 1);
        if (node.right != null)
            Helper(node.right, level + 1);
    }

    // Iterative 
    // Time: O(n)
    // Space: O(n)
    public IList<IList<int>> LevelOrderIterative(TreeNode root)
    {
        IList<IList<int>> result = new List<IList<int>>();
        if (root == null) return result;
        var queue = new Queue<TreeNode>();
        var curr = root;
        int level = 0;
        queue.Enqueue(curr);
        while (queue.Count != 0)
        {
            // start a level
            result.Add(new List<int>());
            // number of nodes in the current level
            var levelLength = queue.Count();
            // populate current level
            for (int i = 0; i < levelLength; i++)
            {
                curr = queue.Dequeue();
                result[level].Add(curr.val);
                // add child nodes of current level in the queue for next level
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









