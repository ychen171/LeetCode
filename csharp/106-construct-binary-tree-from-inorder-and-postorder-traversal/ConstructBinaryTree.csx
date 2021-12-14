
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
    // Recursive using HashMap/Dictionary
    // Time: O(N)
    // Space: O(N)
    private int[] inorder;
    private int[] postorder;
    private int postorderIndex;
    private Dictionary<int, int> inorderValueIndexDict = new Dictionary<int, int>();
    public TreeNode BuildTree1(int[] inorder, int[] postorder)
    {
        this.inorder = inorder;
        this.postorder = postorder;
        // start form the last postorder element
        postorderIndex = postorder.Length - 1;
        // build dictionary value -> index
        for (int i = 0; i < inorder.Length; i++)
            inorderValueIndexDict[inorder[i]] = i;

        return Helper(0, inorder.Length - 1);
    }
    private TreeNode Helper(int leftIndex, int rightIndex)
    {
        // base case
        if (leftIndex > rightIndex) return null;
        // select element from the end of postorder as root
        var rootVal = postorder[postorderIndex];
        // create new root
        var root = new TreeNode(rootVal);
        // root splits inorder list into left and right subtrees
        int inorderIndex = inorderValueIndexDict[rootVal];
        // recursion
        postorderIndex--;

        // build right subtree
        root.right = Helper(inorderIndex + 1, rightIndex);
        // build left subtree
        root.left = Helper(leftIndex, inorderIndex - 1);

        return root;
    }

    // Recursive using HashMap/Dictionary
    // Time: O(N)
    // Space: O(N)
    private Dictionary<int, int> inorderValToIdxDict = new Dictionary<int, int>();
    public TreeNode BuildTree2(int[] inorder, int[] postorder)
    {
        // build dictionary value -> index for inorder
        for (int i = 0; i < inorder.Length; i++)
            inorderValToIdxDict[inorder[i]] = i;
        // start recursion
        return Build(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1);
    }
    private TreeNode Build(int[] inorder, int inStart, int inEnd, int[] postorder, int postStart, int postEnd)
    {
        // base case
        if (inStart > inEnd || postStart > postEnd) return null;
        // recursive case
        var root = new TreeNode(postorder[postEnd]);
        var rootIndex = inorderValToIdxDict[root.val];
        // root.left = Build(inorderList, leftSubtreeStartIndex, leftSubtreeEndIndex, postorderList, leftSubtreeStartIndex, leftSubtreeEndIndex)
        // root.right = Build(inorderList, rightSubtreeStartIndex, rightSubtreeEndIndex, postorderList, rightSubtreeStartIndex, rightSubtreeEndIndex)
        root.left = Build(inorder, inStart, rootIndex - 1, postorder, postStart, postStart + rootIndex - 1 - inStart);
        root.right = Build(inorder, rootIndex + 1, inEnd, postorder, postStart + rootIndex - inStart, postEnd - 1);
        return root;
    }
}













