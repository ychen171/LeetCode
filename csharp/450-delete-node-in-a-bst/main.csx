
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
    // Time: O(H): O(log N) in average, O(N) in worst
    // Space: O(1)
    public TreeNode DeleteNodeR(TreeNode root, int key)
    {
        // base case
        if (root == null)
            return null;
        // recursive case
        if (root.val == key) // delete
        {
            // case 1: it is leaf node
            // case 2: it has one child
            // case 3: it has two children
            if (root.left == null && root.right == null)
                root = null;
            else if (root.left == null)
                root = root.right;
            else if (root.right == null)
                root = root.left;
            else
            {
                // find successor
                var successor = FindSuccessor(root);
                // delete successor
                root.right = DeleteNodeR(root.right, successor.val);
                // replace it using successor
                successor.left = root.left;
                successor.right = root.right;
                root = successor;
            }
        }
        else if (root.val > key)
        {
            root.left = DeleteNodeR(root.left, key);
        }
        else
        {
            root.right = DeleteNodeR(root.right, key);
        }

        return root;
    }
    private TreeNode FindSuccessor(TreeNode root)
    {
        if (root == null) return null;
        TreeNode successor = root.right;
        while (successor.left != null)
            successor = successor.left;
        return successor;
    }

    public TreeNode DeleteNode(TreeNode root, int key)
    {
        if (root == null) return null;
        // search for the node whose value matches the key
        var curr = root;
        TreeNode parent = null;
        TreeNode nodeToDelete = null;
        while (curr != null)
        {
            if (curr.val < key)
            {
                parent = curr;
                curr = curr.right;
            }
            else if (curr.val > key)
            {
                parent = curr;
                curr = curr.left;
            }
            else
            {
                nodeToDelete = curr;
                break;
            }
        }
        // if found, delete the node
        if (nodeToDelete != null)
        {
            // the node to delete has no child
            if (curr.left == null && curr.right == null)
            {
                if (parent == null) root = null;
                else if (parent.left == curr) parent.left = null;
                else parent.right = null;
            }
            // the node to delete has one child
            else if (curr.left != null && curr.right == null)
            {
                if (parent == null) root = curr.left;
                else if (parent.left == curr) parent.left = curr.left;
                else parent.right = curr.left;
            }
            else if (curr.left == null && curr.right != null)
            {
                if (parent == null) root = curr.right;
                else if (parent.left == curr) parent.left = curr.right;
                else parent.right = curr.right;
            }
            // the node to delete has two children
            else
            {
                // go to the right subtree and find the leftmost node
                parent = curr;
                curr = curr.right;
                while (curr.left != null)
                {
                    parent = curr;
                    curr = curr.left;
                }
                // replace nodeToDelete with the leftmost node in the right subtree
                nodeToDelete.val = curr.val;
                // min node in the right subtree may have a right child
                // update min node's parent to hold min node's right child
                if (parent.left == curr)
                    parent.left = curr.right;
                else
                    parent.right = curr.right;
            }
        }
        return root;
    }
    private TreeNode FindMin(TreeNode node)
    {
        if (node == null) return null;
        else if (node.left == null) return node;
        else return FindMin(node.left);
    }
    private TreeNode FindMax(TreeNode node)
    {
        if (node == null) return null;
        else if (node.right == null) return node;
        else return FindMax(node.right);
    }
    private TreeNode Predecessor(TreeNode root, TreeNode node)
    {
        // it has left subtree, FindMax() in the left subtree
        if (node != null && node.left != null)
            return FindMax(node.left);
        // otherwise, traverse ancestors until find the "Left Turn"
        else
        {
            var curr = root;
            TreeNode predecessor = null;
            while (curr != null && curr.val != node.val)
            {
                if (curr.val < node.val)
                {
                    predecessor = curr;
                    curr = curr.right;
                }
                else
                    curr = curr.left;
            }
            return predecessor;
        }

    }
    private TreeNode Successor(TreeNode root, TreeNode node)
    {
        // it has right subtree, FindMin() in the right subtree
        if (node != null && node.right != null)
            return FindMin(node.right);
        // otherwise, traverse ancestors until find the "Right Turn"
        else
        {
            var curr = root;
            TreeNode successor = null;
            while (curr != null && curr.val != node.val)
            {
                if (curr.val > node.val)
                {
                    successor = curr;
                    curr = curr.left;
                }
                else
                    curr = curr.right;
            }
            return successor;
        }
    }
}

var node1 = new TreeNode(1);
var node2 = new TreeNode(2);
node1.right = node2;
var root = node1;
var s = new Solution();
var result = s.DeleteNode(root, 1);
Console.WriteLine(result);




