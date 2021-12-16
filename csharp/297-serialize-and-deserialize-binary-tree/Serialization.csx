
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
        var isLast = false;
        // if it reaches the final level, stop the loop
        while (!isLast)
        {
            var levelLength = queue.Count;
            isLast = true;
            // iterate through nodes in the same level, add value as string, including null
            for (int i = 0; i < levelLength; i++)
            {
                curr = queue.Dequeue();
                // add null, but don't add child
                if (curr == null)
                {
                    sb.Append("null,");
                }
                else
                {
                    // Enqueue left child and right child even if it is null
                    queue.Enqueue(curr.left);
                    queue.Enqueue(curr.right);
                    // add value,
                    sb.Append(curr.val + ",");
                    // if there is any non-null child, this level is not the last level
                    if (curr.left != null || curr.right != null)
                        isLast = false;
                }
            }
            // reach the end of the level, remove the trailing "," and append ";"
            sb.Remove(sb.Length - 1, 1);
            sb.Append(";");
        }
        return sb.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        if (string.IsNullOrEmpty(data)) return null;
        // split data into multiple level strings
        List<string> levelStringList = data.Split(";").ToList();
        // first item in the first level string is root
        var rootLevelString = levelStringList[0];
        var items = rootLevelString.Split(",").ToList();
        if (items.Count != 1) return null;

        var queue = new Queue<TreeNode>();
        int rootVal = int.Parse(items[0]);
        TreeNode root = new TreeNode(rootVal);
        queue.Enqueue(root);
        // iterate through the rest of the level strings
        for (int i = 1; i < levelStringList.Count - 1; i++)
        {
            // split level string into multiple items at the same level
            items = levelStringList[i].Split(",").ToList();
            TreeNode parent = null;
            for (int j = 0; j < items.Count; j++)
            {
                // Dequeue one node for every two new nodes
                if (j % 2 == 0)
                    parent = queue.Dequeue();
                // new node can be null
                var node = items[j] == "null" ? null : new TreeNode(int.Parse(items[j]));
                // continue the loop if new node is null
                if (node == null) continue;
                // only Enqueue non-null new node
                queue.Enqueue(node);
                // connections
                if (j % 2 == 0)
                    parent.left = node;
                else
                    parent.right = node;
            }
        }
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

var longString = ser.serialize(node1);
Console.WriteLine(longString);
var root = deser.deserialize(longString);
var result = root;




