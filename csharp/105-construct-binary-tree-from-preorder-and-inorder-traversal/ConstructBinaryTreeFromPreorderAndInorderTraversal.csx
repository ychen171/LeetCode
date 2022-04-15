
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
    public TreeNode BuildTree(int[] preorder, int[] inorder) 
    {
        // preorder = [3,9,20,15,7], inorder = [9,3,15,20,7]
        // [3       9      20,15,7]    [9       3      15,20,7]
              
        // [20  15  7]                  [15 20  7]
        //      pS  pE                   iS     iE
        //  
        // preorder                         inorder
        //  root,   leftTree,   rightTree                leftTree,  root,   rightTree
        //  pS.........................pE                iS........................iE
        //          [leftLen]   [rightLen]               [leftLen]          [rightLen]
        //          pS      pE                           iS    iE
        //                      pS     pE                                   iS     iE
        
        var inorderValueIndexDict = new Dictionary<int, int>();
        for (int i = 0; i < inorder.Length; i++)
            inorderValueIndexDict[inorder[i]] = i;
        
        return Helper(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1, inorderValueIndexDict);      
    }
    
    private TreeNode Helper(int[] preorder, int preStart, int preEnd, int[] inorder, int inStart, int inEnd, Dictionary<int, int> inorderValueIndexDict)
    {
        // base case
        if (preStart > preEnd || inStart > inEnd)
            return null;
        
        // recursive case
        int rootVal = preorder[preStart];
        int rootIndex = inorderValueIndexDict[rootVal];
        int leftLen = rootIndex - inStart;
        int rightLen = inEnd - rootIndex;
        // build root using left and right
        TreeNode leftNode = Helper(preorder, preStart + 1, preStart + 1 + leftLen - 1, inorder, inStart, rootIndex - 1, inorderValueIndexDict);
        TreeNode rightNode = Helper(preorder, preEnd - rightLen + 1, preEnd, inorder, rootIndex + 1, inEnd, inorderValueIndexDict);
        TreeNode root = new TreeNode(rootVal);
        root.left = leftNode;
        root.right = rightNode;
        return root;
    }
}

