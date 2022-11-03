/**
 * This is the interface for the expression tree Node.
 * You should not remove it, and you can define some classes to implement it.
 */

public abstract class Node 
{
    public abstract int evaluate();
    // define your fields here
    public string val;
    public Node left;
    public Node right;
};

public class TreeNode : Node
{
    public TreeNode(string val)
    {
        this.val = val;
    }
    public override int evaluate()
    {
        if (int.TryParse(val, out var num))
            return num;
        switch (val)
        {
            case "+":
                return this.left.evaluate() + this.right.evaluate();
            case "-":
                return this.left.evaluate() - this.right.evaluate();
            case "*":
                return this.left.evaluate() * this.right.evaluate();
            case "/":
                return this.left.evaluate() / this.right.evaluate();
            default:
                return 0;
        }
    }
};


/**
 * This is the TreeBuilder class.
 * You can treat it as the driver code that takes the postinfix input 
 * and returns the expression tree represnting it as a Node.
 */

public class TreeBuilder 
{
    // postorder traversal
    public Node buildTree(string[] postfix) 
    {
        var stack = new Stack<Node>();
        Node curr = null;
        foreach (var str in postfix)
        {
            curr = new TreeNode(str);
            if (!int.TryParse(str, out var num))
            {
                curr.right = stack.Pop();
                curr.left = stack.Pop();
            }
            stack.Push(curr);
        }
        return curr;
    }
}


/**
 * Your TreeBuilder object will be instantiated and called as such:
 * TreeBuilder obj = new TreeBuilder();
 * Node expTree = obj.buildTree(postfix);
 * int ans = expTree.evaluate();
 */