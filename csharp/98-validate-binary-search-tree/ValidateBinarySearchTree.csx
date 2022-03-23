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

public bool IsValidBST(TreeNode root)
{
    // DFS Inorder Iteration
    // Time: O(n)
    // Space: O(n)
    var currNode = root;
    if (currNode == null) return true;
    var stack = new Stack<TreeNode>();
    TreeNode prevNode = null;
    while (currNode != null || stack.Count > 0)
    {
        while (currNode != null)
        {
            stack.Push(currNode);
            currNode = currNode.left;
        }
        currNode = stack.Pop();
        if (prevNode != null && prevNode.val >= currNode.val)
            return false;
        prevNode = currNode;
        currNode = currNode.right;
    }
    return true;
}

// DFS Recursion | Top-down
// Time: O(n)
// Space: O(n)
public bool IsValidBSTRecursive(TreeNode root)
{
    return IsValidBSTRecursive(root, null, null);
}
public bool IsValidBSTRecursive(TreeNode node, int? min, int? max)
{
    if (node == null) 
        return true;
    if ((min != null && node.val <= min.Value) || (max != null && node.val >= max.Value))
        return false;
    return IsValidBSTRecursive(node.left, min, node.val) && IsValidBSTRecursive(node.right, node.val, max);
}

public bool IsValidBST2(TreeNode root)
{
    return Helper(root, null, null);
}
public bool Helper(TreeNode node, int? min, int? max)
{
    // base case
    if (node == null) return true;
    if ((min.HasValue && node.val <= min) || (max.HasValue && node.val >= max)) return false;
    // divide
    int? leftMax = max.HasValue ? Math.Min(node.val, max.Value) : node.val;
    int? rightMin = min.HasValue ? Math.Max(node.val, min.Value) : node.val;
    // conquer
    var isLeftValid = Helper(node.left, min, leftMax);
    var isRightValid = Helper(node.right, rightMin, max);
    // combine
    return isLeftValid && isRightValid;
}

public List<int> BreadthFirstSearch(TreeNode node)
{
    if (node == null)
        return null;
    
    var currNode = node;
    var queue = new Queue<TreeNode>();
    var result = new List<int>();
    queue.Enqueue(currNode);

    while (queue.Count > 0)
    {
        currNode = queue.Dequeue();
        result.Add(currNode.val);
        if (currNode.left != null)
            queue.Enqueue(currNode.left);
        if (currNode.right != null)
            queue.Enqueue(currNode.right);
    }

    return result;
}

public List<int> DepthFirstSearchInorder(TreeNode root)
{
    return DepthFirstSearchInorder(root, new List<int>());
}
public List<int> DepthFirstSearchInorder(TreeNode node, List<int> list)
{
    if (node == null)
        return list;
    DepthFirstSearchInorder(node.left, list);
    list.Add(node.val);
    DepthFirstSearchInorder(node.right, list);
    return list;
}

public List<int> DepthFirstSearchInorderIterative(TreeNode root)
{
    var currNode = root;
    if (currNode == null) return null;
    var list = new List<int>();
    var stack = new Stack<TreeNode>();
    
    while (currNode != null || stack.Count > 0)
    {
        while (currNode != null)
        {
            stack.Push(currNode);
            currNode = currNode.left;
        }
        currNode = stack.Pop();
        list.Add(currNode.val);
        currNode = currNode.right;
    }

    return list;
}