

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution
{
    // DFS | Postorder | Bottom up | Recursion
    // Time: O(N)
    // Space: O(N)
    TreeNode lca;
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        DFS(root, p, q);
        return lca;
    }

    private bool DFS(TreeNode curr, TreeNode p, TreeNode q)
    {
        // base case
        if (curr == null) return false;
        // get answers from subproblems
        int left = DFS(curr.left, p, q) ? 1 : 0;
        int right = DFS(curr.right, p, q) ? 1 : 0;
        // use the answers to come up with the answer for current call
        int mid = (curr == p || curr == q) ? 1 : 0;
        int count = (left + right + mid);
        if (count >= 2) lca = curr;
        // return answer to parent
        return count > 0;
    }

    public TreeNode LowestCommonAncestor1(TreeNode root, TreeNode p, TreeNode q)
    {
        Helper(root, p, q);
        return lca;
    }

    private TreeNode Helper(TreeNode curr, TreeNode p, TreeNode q)
    {
        // base case
        if (curr == null) return null;
        // get answers from subproblems
        TreeNode left = Helper(curr.left, p, q);
        TreeNode right = Helper(curr.right, p, q);
        // use the answers to come up with the answer for current call
        // return the answer to parent
        bool hasLeft = left != null;
        bool hasRight = right != null;
        bool hasMid = curr == p || curr == q;
        int leftCount = hasLeft ? 1 : 0;
        int rightCount = hasRight ? 1 : 0;
        int midCound = hasMid ? 1 : 0;
        int count = leftCount + rightCount + midCound;
        if (count >= 2) lca = curr;
        return hasMid ? curr : hasLeft ? left : hasRight ? right : null;
    }

    public TreeNode LowestCommonAncestor2(TreeNode root, TreeNode p, TreeNode q)
    {
        // base case 
        if (root == null)
            return null;
        if (root.val == p.val || root.val == q.val)
            return root;

        // recursive case
        var left = LowestCommonAncestor2(root.left, p, q);
        var right = LowestCommonAncestor2(root.right, p, q);
        if (left != null && right != null)
            return root;
        return left ?? right;
    }

    // Iterative using parent pointers, dictionary, stack and set (DFS, backtracking)
    // Time: O(N)
    // Space: O(N)
    public TreeNode LowestCommonAncestor3(TreeNode root, TreeNode p, TreeNode q)
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

    // Recursive using parent pointers, dictionary, and set
    // Time: O(n)
    // Space: O(n)
    public TreeNode LowestCommonAncestor4(TreeNode root, TreeNode p, TreeNode q)
    {
        var parentDict = new Dictionary<TreeNode, TreeNode>();
        TreeNode curr = root;
        parentDict[curr] = null;

        DFS(curr, parentDict);

        var qSet = new HashSet<TreeNode>();
        curr = q;
        while (curr != null)
        {
            qSet.Add(curr);
            curr = parentDict[curr];
        }

        curr = p;
        while (curr != null)
        {
            if (qSet.Contains(curr))
                return curr;

            curr = parentDict[curr];
        }

        return curr;
    }

    private void DFS(TreeNode curr, Dictionary<TreeNode, TreeNode> parentDict)
    {
        // base case
        if (curr == null)
            return;

        // recursive case
        if (curr.left != null)
            parentDict[curr.left] = curr;
        if (curr.right != null)
            parentDict[curr.right] = curr;
        DFS(curr.left, parentDict);
        DFS(curr.right, parentDict);
    }
}







