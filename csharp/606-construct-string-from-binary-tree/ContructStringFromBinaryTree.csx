
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
    // Postorder Recursion
    // Time: O(n)
    // Space: O(n)
    public string Tree2str(TreeNode root)
    {
        var sb = Helper(root);
        return sb.ToString();
    }

    public StringBuilder Helper(TreeNode node)
    {
        // base case
        if (node == null)
        {
            return new StringBuilder();
        }

        // recursive case
        var leftSB = Helper(node.left);
        var rightSB = Helper(node.right);
        var sb = new StringBuilder();
        sb.Append(node.val);
        if (node.left != null && node.right == null)
            return sb.Append('(').Append(leftSB).Append(')');
        if (node.left == null && node.right != null)
            return sb.Append("()").Append('(').Append(rightSB).Append(')');
        if (node.left == null && node.right == null)
            return sb;
        return sb.Append('(').Append(leftSB).Append(')').Append('(').Append(rightSB).Append(')');
    }

    // Postorder Recursion
    // Time: O(n)
    // Space: O(n)
    public string Tree2str1(TreeNode root)
    {
        // base case
        if (root == null)
            return string.Empty;
        if (root.left == null && root.right == null)
            return root.val.ToString();

        var leftStr = Tree2str1(root.left);
        var rightStr = Tree2str1(root.right);

        if (root.left != null && root.right == null)
            return $"{root.val}({leftStr})";
        if (root.left == null && root.right == null)
            return $"{root.val}()({rightStr})";

        return $"{root.val}({leftStr})({rightStr})";
    }
}

// "1(2(4()())())(3()())"
// "1(2()(4()()))(3()())"