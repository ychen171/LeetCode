
class Node
{
    public Node Left { get; set; }
    public Node Right { get; set; }
    public int Value { get; set; }
    public Node(int value)
    {
        Value = value;
    }
}

class BinaryTree
{
    public Node Root { get; set; }

    public List<int> DepthFirstSearchPreorderRecursive()
    {
        return DepthFirstSearchPreorderRecursive(Root, new List<int>());
    }
    private List<int> DepthFirstSearchPreorderRecursive(Node node, List<int> list)
    {
        if (node == null) return list;
        list.Add(node.Value);
        DepthFirstSearchPreorderRecursive(node.Left, list);
        DepthFirstSearchPreorderRecursive(node.Right, list);
        return list;
    }
    public List<int> DepthFirstSearchInorderRecursive()
    {
        return DepthFirstSearchInorderRecursive(Root, new List<int>());
    }
    private List<int> DepthFirstSearchInorderRecursive(Node node, List<int> list)
    {
        if (node == null) return list;
        DepthFirstSearchInorderRecursive(node.Left, list);
        list.Add(node.Value);
        DepthFirstSearchInorderRecursive(node.Right, list);
        return list;
    }
    public List<int> DepthFirstSearchPostorderRecursive()
    {
        return DepthFirstSearchPostorderRecursive(Root, new List<int>());
    }
    private List<int> DepthFirstSearchPostorderRecursive(Node node, List<int> list)
    {
        if (node == null) return list;
        DepthFirstSearchPostorderRecursive(node.Left, list);
        DepthFirstSearchPostorderRecursive(node.Right, list);
        list.Add(node.Value);
        return list;
    }

    public List<int> DepthFirstSearchPreorderIterative()
    {
        if (Root == null) return null;
        var list = new List<int>();
        var stack = new Stack<Node>();
        var curr = Root;

        while (curr != null || stack.Count != 0)
        {
            while (curr != null)
            {
                stack.Push(curr);
                list.Add(curr.Value);
                curr = curr.Left;
            }
            curr = stack.Pop();
            curr = curr.Right;
        }

        return list;
    }
    
    public List<int> DepthFirstSearchInorderIterative()
    {
        if (Root == null) return null;
        var list = new List<int>();
        var stack = new Stack<Node>();
        var curr = Root;

        while (curr != null || stack.Count != 0)
        {
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.Left;
            }
            curr = stack.Pop();
            list.Add(curr.Value);
            curr = curr.Right;
        }

        return list;
    }
    
    public List<int> DepthFirstSearchPostorderIterative()
    {
        if (Root == null) return null;
        var list = new List<int>();
        var stack = new Stack<Node>();
        var curr = Root;

        while (curr != null || stack.Count != 0)
        {
            while (curr != null)
            {
                stack.Push(curr);
                stack.Push(curr);
                curr = curr.Left;
            }
            curr = stack.Pop();
            if (stack.Count != 0 && curr == stack.Peek())
                curr = curr.Right;
            else
            {
                list.Add(curr.Value);
                curr = null;
            }
        }

        return list;
    }

    public List<int> BreadthFirstSearchTraversalRecursive()
    {
        var queue = new Queue<Node>();
        var list = new List<int>();
        Helper(queue, list);
        return list;
    }
    private void Helper(Queue<Node> queue, List<int> list)
    {
        if (queue.Count == 0) return;
        var curr = queue.Dequeue();
        list.Add(curr.Value);
        if (curr.Left != null)
            queue.Enqueue(curr.Left);
        if (curr.Right != null)
            queue.Enqueue(curr.Right);
        Helper(queue, list);
    }
    public List<int> BreadthFirstSearchTraversalIterative()
    {
        if (Root == null) return null;
        var list = new List<int>();
        var queue = new Queue<Node>();
        var curr = Root;
        queue.Enqueue(curr);
        while (queue.Count != 0)
        {
            curr = queue.Dequeue();
            list.Add(curr.Value);
            if (curr.Left != null)
                queue.Enqueue(curr.Left);
            if (curr.Right != null)
                queue.Enqueue(curr.Right);
        }
        return list;
    }
}