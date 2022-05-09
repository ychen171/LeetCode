
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}


// Preorder serialize using Stack
// Preorder deserialize using Queue
// Time: o(n)
// Space: O(n)
public class Codec
{
    // Encodes a tree to a single string.
    public string serialize(TreeNode root)
    {
        var sb = new StringBuilder();
        // DFS Inorder
        Preorder(root, sb);
        return sb.ToString();
    }

    // Top-down | Preorder
    private void Preorder(TreeNode root, StringBuilder sb)
    {
        // base case
        if (root == null)
            return;
        // recursive case
        sb.Append(root.val);
        sb.Append(' ');
        Preorder(root.left, sb);
        Preorder(root.right, sb);
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        if (string.IsNullOrEmpty(data))
            return null;
        
        var numQueue = new Queue<int>();
        string[] parts = data.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
        foreach (var str in parts)
        {
            numQueue.Enqueue(int.Parse(str));
        }

        return Preorder(int.MinValue, int.MaxValue, numQueue);
    }

    // Top-down | Preorder
    private TreeNode Preorder(int lower, int upper, Queue<int> numQueue)
    {
        // base case
        if (numQueue.Count == 0)
            return null;

        if (numQueue.Peek() < lower || numQueue.Peek() > upper)
            return null;
        // recursive case
        int val = numQueue.Dequeue();
        TreeNode root = new TreeNode(val);
        root.left = Preorder(lower, val, numQueue);
        root.right = Preorder(val, upper, numQueue);
     
        return root;
    }
}


// Postorder serialize using Stack
// Preorder deserialize using Stack
// Time: O(n)
// Space: O(n)
public class Codec1
{
    // Encodes a tree to a single string.
    public string serialize(TreeNode root)
    {
        var sb = new StringBuilder();
        // DFS postorder
        Postorder(root, sb);
        return sb.ToString();
    }

    // Bottom-up | Postorder
    private void Postorder(TreeNode root, StringBuilder sb)
    {
        // base case
        if (root == null)
            return;
        // recursive case
        Postorder(root.left, sb);
        Postorder(root.right, sb);
        sb.Append(root.val);
        sb.Append(' ');
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        if (string.IsNullOrEmpty(data))
            return null;
        
        var numStack = new Stack<int>();
        string[] parts = data.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
        foreach (var str in parts)
        {
            numStack.Push(int.Parse(str));
        }

        return Preorder(int.MinValue, int.MaxValue, numStack);
    }

    // Top-down | Preorder
    private TreeNode Preorder(int lower, int upper, Stack<int> numStack)
    {
        // base case
        if (numStack.Count == 0)
            return null;

        if (numStack.Peek() < lower || numStack.Peek() > upper)
            return null;
        // recursive case
        int val = numStack.Pop();
        TreeNode root = new TreeNode(val);
        root.right = Preorder(val, upper, numStack);
        root.left = Preorder(lower, val, numStack);
     
        return root;
    }
}












// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// String tree = ser.serialize(root);
// TreeNode ans = deser.deserialize(tree);
// return ans;
