
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

        return Helper1(0, inorder.Length - 1);
    }
    private TreeNode Helper1(int leftIndex, int rightIndex)
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
        root.right = Helper1(inorderIndex + 1, rightIndex);
        // build left subtree
        root.left = Helper1(leftIndex, inorderIndex - 1);

        return root;
    }

    // Recursive using HashMap/Dictionary
    // Time: O(N)
    // Space: O(N)
    public TreeNode BuildTree(int[] inorder, int[] postorder) 
    {
        // inorder = [9,3,15,20,7], postorder = [9,15,7,20,3]
        //  9       3       15      20      7    
        //  lfTree       root            rtTree             
        //  lfTree      rtTree             root
        
        //  iS           rootIndex          iE
        //  [   leftLen ]         [  rightLen]
        //  pS                              pE
        //  go left
        //  iS=iS      iE = rootIndex - 1
        //  pS=pS      pE = pS + leftLen - 1
        //  go right
        //                     iS=rootIndex + 1 iE=iE
        //                     pS=pS+leftLen pE=pE-1
        var inorderValueIndexDict = new Dictionary<int, int>();
        for (int i = 0; i < inorder.Length; i++)
            inorderValueIndexDict[inorder[i]] = i;
        return Helper(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1, inorderValueIndexDict);
    }
    
    private TreeNode Helper(int[] inorder, int inStart, int inEnd, int[] postorder, int postStart, int postEnd, Dictionary<int, int> inorderValueIndexDict)
    {
        // base case
        if (inStart > inEnd || postStart > postEnd)
            return null;
        
        // recursive case
        int rootVal = postorder[postEnd];
        int rootIndex = inorderValueIndexDict[rootVal];
        int leftLen = rootIndex - inStart;
        // build node
        TreeNode root = new TreeNode(rootVal);
        root.left = Helper(inorder, inStart, rootIndex - 1, postorder, postStart, postStart + leftLen - 1, inorderValueIndexDict);
        root.right = Helper(inorder, rootIndex + 1 , inEnd, postorder, postStart + leftLen, postEnd - 1, inorderValueIndexDict);
        
        return root;
    }
}
