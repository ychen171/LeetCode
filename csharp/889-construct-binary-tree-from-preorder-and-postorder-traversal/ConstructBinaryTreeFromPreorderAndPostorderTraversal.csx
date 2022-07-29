
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
    // Recursion + Dictionary
    // Time: O(n)
    // Space: O(n)
    Dictionary<int, int> postValToIdx;
    public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
    {
        /*
            preorder:   [rt, l, r]
            postorder:  [l, r, rt]
        */
        int n = preorder.Length;
        postValToIdx = new Dictionary<int, int>();
        for (int i = 0; i < n; i++)
            postValToIdx[postorder[i]] = i;
        return Helper(preorder, 0, n - 1, postorder, 0, n - 1);
    }

    public TreeNode Helper(int[] preorder, int preS, int preE, int[] postorder, int postS, int postE)
    {
        // base case
        if (preS > preE)
            return null;
        if (preS == preE)
            return new TreeNode(preorder[preS]);

        // recursive case
        int rootVal = preorder[preS];
        var root = new TreeNode(rootVal);
        var leftVal = preorder[preS + 1];
        var index = postValToIdx[leftVal];
        var leftLen = index - postS + 1;
        root.left = Helper(preorder, preS + 1, preS + leftLen, postorder, postS, index);
        root.right = Helper(preorder, preS + leftLen + 1, preE, postorder, index + 1, postE - 1);

        return root;
    }
}
