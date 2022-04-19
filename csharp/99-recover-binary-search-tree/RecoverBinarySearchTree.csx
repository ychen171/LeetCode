
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
    // Inorder Traversal + Sort
    // Time: O(n log n)
    // Space: O(n)
    public void RecoverTree(TreeNode root)
    {
        // 3 2 1 ----> 1 2 3
        // 1 3 2 4 ----> 1 2 3 4
        // inorder traversal
        var stack = new Stack<TreeNode>();
        TreeNode curr = root;
        var valueList = new List<int>();
        var nodeList = new List<TreeNode>();
        while (curr != null || stack.Count != 0)
        {
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.left;
            }
            curr = stack.Pop();
            valueList.Add(curr.val);
            nodeList.Add(curr);
            curr = curr.right;
        }
        // sort
        valueList.Sort();
        // iterate again and fix the values
        for (int i = 0; i < valueList.Count; i++)
        {
            nodeList[i].val = valueList[i];
        }
    }

    // Inorder traversal + two pointers
    public void RecoverTree1(TreeNode root)
    {
        var stack = new Stack<TreeNode>();
        TreeNode curr = root;
        TreeNode prev = null;
        TreeNode nodeA = null;
        TreeNode nodeB = null;
        while (curr != null || stack.Count != 0)
        {
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.left;
            }
            curr = stack.Pop();
            // find and swap
            if (prev != null && prev.val > curr.val)
            {
                nodeB = curr;
                if (nodeA == null)
                    nodeA = prev;
                else
                    break;
            }
            
            prev = curr;
            curr = curr.right;
        }
        
        Swap(nodeA, nodeB);
    }

    private void Swap(TreeNode a, TreeNode b)
    {
        int temp = a.val;
        a.val = b.val;
        b.val = temp;
    }
}
