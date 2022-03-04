

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution
{
    // Recursive DFS
    // Time: O(N)
    // Space: O(N)
    TreeNode answer;
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        DFSInorder(root, p, q);
        return answer;
    }

    private bool DFSInorder(TreeNode curr, TreeNode p, TreeNode q)
    {
        // base case
        if (curr == null) return false;
        // recursive case DFS Inorder
        int mid = (curr == p || curr == q) ? 1 : 0;
        int left = DFSInorder(curr.left, p, q) ? 1 : 0;
        int right = DFSInorder(curr.right, p, q) ? 1 : 0;
        // if any two of the flags become true, store the node and return true
        int count = (left + mid + right);
        if (count >= 2) answer = curr;
        return count > 0;
    }

    // Iterative using parent pointers, dictionary, stack and set (DFS, backtracking)
    // Time: O(N)
    // Space: O(N)
    public TreeNode LowestCommonAncestor2(TreeNode root, TreeNode p, TreeNode q)
    {
        var parentDict = new Dictionary<TreeNode, TreeNode>();
        var stack = new Stack<TreeNode>();
        stack.Push(root);
        parentDict[root] = null;
        TreeNode curr = null;
        // DFS traversal
        // Stop the loop if both p and q are reached. 
        while (!(parentDict.ContainsKey(p) && parentDict.ContainsKey(q)))
        {
            curr = stack.Pop();
            if (curr.left != null)
            {
                stack.Push(curr.left);
                parentDict[curr.left] = curr;
            }
            if (curr.right != null)
            {
                stack.Push(curr.right);
                parentDict[curr.right] = curr;
            }
        }
        // backtrack p and store all ancestor into set
        var ancestorSet = new HashSet<TreeNode>();
        while (p != null)
        {
            ancestorSet.Add(p);
            p = parentDict[p];
        }
        // backtrack q until it finds the common ancestor
        while (!ancestorSet.Contains(q))
            q = parentDict[q];
        // return the lowest common ancestor
        return q;
    }
}







