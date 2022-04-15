
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
    // Recursion | Bottom-up | Two Pointers 
    // Time: O(n^2)
    // Space: O(n)
    public TreeNode ConstructMaximumBinaryTree(int[] nums)
    {
        return Helper(nums, 0, nums.Length - 1);
    }

    private TreeNode Helper(int[] nums, int start, int end)
    {
        // base case
        if (start > end)
            return null;

        // recursive case
        // find root val / maximum and root index
        int rootVal = nums[start];
        int rootIndex = start;
        int i = start + 1;
        while (i <= end)
        {
            if (nums[i] > rootVal)
            {
                rootVal = nums[i];
                rootIndex = i;
            }
            i++;
        }
        // build root node
        TreeNode root = new TreeNode(rootVal);
        root.left = Helper(nums, start, rootIndex - 1);
        root.right = Helper(nums, rootIndex + 1, end);

        return root;
    }
}
