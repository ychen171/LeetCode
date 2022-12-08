
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
    public bool LeafSimilar(TreeNode root1, TreeNode root2)
    {
        var leaves1 = new List<int>();
        var leaves2 = new List<int>();
        DFS(root1, leaves1);
        DFS(root2, leaves2);
        if (leaves1.Count != leaves2.Count)
            return false;
        for (int i = 0; i < leaves1.Count; i++)
        {
            if (leaves1[i] != leaves2[i])
                return false;
        }
        return true;
    }

    private void DFS(TreeNode node, List<int> leaves)
    {
        // base case
        if (node == null) return;
        if (node.left == null && node.right == null)
        {
            leaves.Add(node.val);
            return;
        }
        // recursive case
        DFS(node.left, leaves);
        DFS(node.right, leaves);
    }
}
// DFS Preorder Traversal
// Time: O(n1 + n2)
// Space: O(n1 + n2)
