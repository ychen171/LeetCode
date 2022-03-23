
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
    // DFS | Bottom-up | Postorder | Recursion
    // Time: O(n)
    // Space: O(n)
    public string GetDirections(TreeNode root, int startValue, int destValue)
    {
        TreeNode lca = LCA(root, startValue, destValue);
        var upBuilder = new StringBuilder();
        var downBuilder = new StringBuilder();
        DFS(lca, startValue, true, upBuilder);
        DFS(lca, destValue, false, downBuilder);
        var upString = upBuilder.ToString();
        var downString = new string(downBuilder.ToString().Reverse().ToArray());
        return upString + downString;
    }

    private TreeNode LCA(TreeNode root, int startValue, int destValue)
    {
        if (root == null) return root;
        if (root.val == startValue || root.val == destValue) return root;

        TreeNode left = LCA(root.left, startValue, destValue);
        TreeNode right = LCA(root.right, startValue, destValue);
        if (left != null && right != null)
            return root;
        else if (left != null)
            return left;
        else if (right != null)
            return right;
        else
            return null;
    }

    private bool DFS(TreeNode root, int stopValue, bool isUp, StringBuilder pathBuilder)
    {
        if (root == null) return false;
        if (root.val == stopValue) return true;

        bool left = DFS(root.left, stopValue, isUp, pathBuilder);
        bool right = DFS(root.right, stopValue, isUp, pathBuilder);
        if (left)
        {
            if (isUp)
                pathBuilder.Append('U');
            else
                pathBuilder.Append('L');
            return true;
        }
        else if (right)
        {
            if (isUp)
                pathBuilder.Append('U');
            else
                pathBuilder.Append('R');
            return true;
        }
        else
            return false;
    }


    TreeNode globalLCA;
    StringBuilder upPath = new StringBuilder();
    StringBuilder downPath = new StringBuilder();
    public string GetDirections1(TreeNode root, int startValue, int destValue)
    {
        Helper(root, startValue, destValue);
        return upPath.ToString() + downPath.ToString();
    }

    private TreeNode Helper(TreeNode curr, int startValue, int destValue)
    {
        // base case
        if (curr == null) return null;
        // if (curr.val == startValue || curr.val == destValue) return curr;
        // get values from subproblems
        TreeNode left = Helper(curr.left, startValue, destValue);
        TreeNode right = Helper(curr.right, startValue, destValue);
        // calculate answer for current problem
        // return the answer to parent
        bool hasLeft = left != null;
        bool hasRight = right != null;
        bool hasMid = curr.val == startValue || curr.val == destValue;

        if (hasLeft && hasMid && !hasRight)
        {
            globalLCA = curr;
            if (left.val == startValue)
                upPath.Append("U");
            else
                downPath.Insert(0, "L");
            return curr;
        }
        else if (hasRight && hasMid && !hasLeft)
        {
            globalLCA = curr;
            if (right.val == startValue)
                upPath.Append("U");
            else
                downPath.Insert(0, "R");
            return curr;
        }
        else if (hasLeft && !hasRight && !hasMid)
        {
            if (left.val == startValue)
                upPath.Append("U");
            else
                downPath.Insert(0, "L");
            return left;
        }
        else if (hasRight && !hasLeft && !hasMid)
        {
            if (right.val == startValue)
                upPath.Append("U");
            else
                downPath.Insert(0, "R");
            return right;
        }
        else if (hasMid && !hasLeft && !hasRight)
        {
            return curr;
        }
        else if (hasLeft && hasRight && !hasMid)
        {
            globalLCA = curr;
            upPath.Append("U");
            if (left.val == destValue)
                downPath.Insert(0, "L");
            else
                downPath.Insert(0, "R");
            return curr;
        }
        else
        {
            return null;
        }
    }



    // trick
    public string GetDirections2(TreeNode root, int startValue, int destValue)
    {
        var startPath = new StringBuilder();
        var destPath = new StringBuilder();
        Find(root, startValue, startPath);
        Find(root, destValue, destPath);
        var s = startPath.ToString();
        var d = destPath.ToString();
        int i = 0, max_i = Math.Min(s.Length, d.Length);
        while (i < max_i && s[s.Length - i - 1] == d[d.Length - i - 1])
        {
            i++;
        }
        var reversedChars = d.Reverse().ToArray();
        return new string('U', s.Length - i) + new string(reversedChars, i, reversedChars.Length - i);
    }

    private bool Find(TreeNode node, int stopValue, StringBuilder pathBuilder)
    {
        if (node == null) return false;
        if (node.val == stopValue) return true;
        if (node.left != null && Find(node.left, stopValue, pathBuilder))
            pathBuilder.Append('L');
        else if (node.right != null && Find(node.right, stopValue, pathBuilder))
            pathBuilder.Append('R');
        return pathBuilder.Length > 0;
    }
}
