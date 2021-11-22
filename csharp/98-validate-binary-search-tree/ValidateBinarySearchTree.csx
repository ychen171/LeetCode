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
    // Depth first search Inorder
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

// public bool IsValidBST2(TreeNode root)
// {
//     // Breadth first search
//     var currNode = root;
//     if (currNode == null) return true;
//     var primaryQueue = new Queue<TreeNode>();
//     var secondaryQueue = new Queue<TreeNode>();
//     primaryQueue.Enqueue(currNode);
//     while (primaryQueue.Count > 0 || secondaryQueue.Count > 0)
//     {
//         while (primaryQueue.Count > 0)
//         {
//             currNode = primaryQueue.Dequeue();
//             if (currNode.left != null)
//             {
//                 if (currNode.left.val >= currNode.val)
//                     return false;
//                 else
//                     secondaryQueue.Enqueue(currNode.left);
//             }
//             if (currNode.right != null)
//             {
//                 if (currNode.right.val <= currNode.val)
//                     return false;
//                 else
//                     secondaryQueue.Enqueue(currNode.right);
//             }
//         }
//         var temp = secondaryQueue;
//         secondaryQueue = primaryQueue;
//         primaryQueue = temp;
//     }
//     return true;
// }
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