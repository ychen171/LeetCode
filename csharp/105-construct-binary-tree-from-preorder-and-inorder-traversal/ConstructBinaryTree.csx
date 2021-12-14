
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
    // Recursion using Dictionary
    // Time: O(N)
    // Space: O(N)
    private Dictionary<int, int> inorderValToIdxDict = new Dictionary<int, int>();
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        // build dictionary value -> index for inorder
        for (int i = 0; i < inorder.Length; i++)
            inorderValToIdxDict[inorder[i]] = i;
        // start recursion
        return Build(inorder, 0, inorder.Length - 1, preorder, 0, preorder.Length - 1);
    }
    private TreeNode Build(int[] inorder, int inStart, int inEnd, int[] preorder, int preStart, int preEnd)
    {
        // base case
        if (inStart > inEnd || preStart > preEnd) return null;
        // recursive case
        var rootVal = preorder[preStart];
        var root = new TreeNode(rootVal);
        var rootIndex = inorderValToIdxDict[rootVal];
        root.left = Build(inorder, inStart, rootIndex - 1, preorder, preStart + 1, preStart + rootIndex - inStart);
        root.right = Build(inorder, rootIndex + 1, inEnd, preorder, preStart + rootIndex - inStart + 1, preEnd);
        return root;
    }
}





