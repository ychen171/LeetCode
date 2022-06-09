
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
    // DFS Inorder + Two Pointers
    // Time: O(n)
    // Space: O(n)
    public bool FindTarget(TreeNode root, int k)
    {
        // Inorder DFS to get the sorted list of nums
        var sortedList = new List<int>();
        var stack = new Stack<TreeNode>();
        var curr = root;
        while (stack.Count != 0 || curr != null)
        {
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.left;
            }
            curr = stack.Pop();
            sortedList.Add(curr.val);
            curr = curr.right;
        }

        // two pointers to find two nums where sum == k
        int left = 0;
        int right = sortedList.Count - 1;
        while (left < right)
        {
            var sum = sortedList[left] + sortedList[right];
            if (sum == k)
                return true;
            else if (sum < k)
                left++;
            else
                right--;
        }

        return false;
    }
}
