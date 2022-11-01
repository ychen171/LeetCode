
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Codec
{
    // Encodes a tree to a single string.
    // BFS Traversal using Queue
    public string serialize(TreeNode root)
    {
        var sb = new StringBuilder();
        if (root == null) return sb.ToString();
        var curr = root;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(curr);
        while (queue.Count != 0)
        {
            var levelLen = queue.Count;
            // iterate through nodes in the same level, add value as string, including null
            for (int i = 0; i < levelLen; i++)
            {
                curr = queue.Dequeue();
                // add null, but don't add child
                if (curr == null)
                {
                    sb.Append("null,");
                    continue;
                }
                sb.Append(curr.val).Append(',');
                // Enqueue left child and right child even if it is null
                queue.Enqueue(curr.left);
                queue.Enqueue(curr.right);
            }
        }
        return sb.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        if (string.IsNullOrEmpty(data)) return null;
        var items = data.Split(',');
        if (items[0] == "null") return null;

        var queue = new Queue<TreeNode>();
        var root = new TreeNode(int.Parse(items[0]));
        queue.Enqueue(root);
        int index = 1;
        while (index < items.Length && queue.Count != 0)
        {
            var curr = queue.Dequeue();
            string leftStr = items[index++];
            if (leftStr == "null")
                curr.left = null;
            else
            {
                var leftNode = new TreeNode(int.Parse(leftStr));
                curr.left = leftNode;
                queue.Enqueue(leftNode);
            }
            string rightStr = items[index++];
            if (rightStr == "null")
                curr.right = null;
            else
            {
                var rightNode = new TreeNode(int.Parse(rightStr));
                curr.right = rightNode;
                queue.Enqueue(rightNode);
            }
        }
        return root;
    }
}

public class CodecR
{
    // Preorder Traversal | Recursion
    // Time: O(n)
    // Space: O(h)
    // Encodes a tree to a single string.
    public string serialize(TreeNode root) 
    {
        // DFS preorder traversal
        var sb = new StringBuilder();
        SerPreorder(root, sb);
        return sb.ToString();
    }
    
    private void SerPreorder(TreeNode node, StringBuilder sb)
    {
        // base case
        if (node == null)
        {
            sb.Append("#,");
            return;
        }
        // recursive case
        sb.Append(node.val).Append(',');
        SerPreorder(node.left, sb);
        SerPreorder(node.right, sb);
    }

    // Inorder Traversal | Recursion + Queue
    // Time: O(n)
    // Space: O(n)
    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) 
    {
        var strs = data.Split(',');
        var queue = new Queue<string>(strs);
        return DesPreorder(queue);
    }
    
    private TreeNode DesPreorder(Queue<string> queue)
    {
        var str = queue.Dequeue();
        if (str == "#") return null;
        var root = new TreeNode(int.Parse(str));
        root.left = DesPreorder(queue);
        root.right = DesPreorder(queue);
        return root;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));


var node1 = new TreeNode(1);
var node2 = new TreeNode(2);
var node3 = new TreeNode(3);
var node4 = new TreeNode(4);
var node5 = new TreeNode(5);
var node6 = new TreeNode(6);
var node7 = new TreeNode(7);

node1.left = node2;
node1.right = node3;
node3.left = node4;
node3.right = node5;
node4.left = node6;
node4.right = node7;

var ser = new Codec();
var deser = new Codec();

// var longString = ser.serialize(node1);
// Console.WriteLine(longString);
// var root = deser.deserialize(longString);
// var result = root;

var codecR = new CodecR();
Console.WriteLine(codecR.serialize(node1));


