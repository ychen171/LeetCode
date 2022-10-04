public class Solution
{
    // BFS to build tree + DFS to compute
    // Time: O(n)
    // Space: O(n)
    int result;
    public int PathSum(int[] nums)
    {
        /*
            level order traversal
            curr = i
            left = 2 * i - 1, right = 2 * i
            
        */
        int n = nums.Length;
        if (n == 0)
            return 0;
        // BFS to create tree
        var dict = new Dictionary<int, TreeNode>(); // depth position -> node
        foreach (var num in nums)
        {
            var key = num / 10;
            var val = num % 10;
            dict[key] = new TreeNode(val);
        }
        var queue = new Queue<int>(); // depth position
        var rootKey = nums[0] / 10;
        var root = dict[rootKey];
        queue.Enqueue(rootKey);
        while (queue.Count != 0)
        {
            var curr = queue.Dequeue();
            var currDepth = curr / 10;
            var currPosition = curr % 10;
            var currNode = dict[curr];
            // left child
            var left = (currDepth + 1) * 10 + (2 * currPosition - 1);
            if (dict.ContainsKey(left))
            {
                currNode.left = dict[left];
                queue.Enqueue(left);
            }
            // right child
            var right = (currDepth + 1) * 10 + (2 * currPosition);
            if (dict.ContainsKey(right))
            {
                currNode.right = dict[right];
                queue.Enqueue(right);
            }
        }

        // DFS to calculate sum
        Helper(root, 0);
        return result;
    }

    public void Helper(TreeNode node, int currSum)
    {
        // base case
        if (node == null)
            return;
        if (node.left == null && node.right == null)
        {
            result += currSum + node.val;
            return;
        }
        // recursive case
        currSum += node.val;
        Helper(node.left, currSum);
        Helper(node.right, currSum);
        currSum -= node.val;
    }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
