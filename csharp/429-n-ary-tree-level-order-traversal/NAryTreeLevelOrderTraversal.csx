
// Definition for a Node.
public class Node
{
    public int val;
    public IList<Node> children;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, IList<Node> _children)
    {
        val = _val;
        children = _children;
    }
}


public class Solution
{
    // BFS
    // Time: O(n)
    // Space: O(n)
    public IList<IList<int>> LevelOrder(Node root)
    {
        var result = new List<IList<int>>();
        if (root == null)
            return result;

        var queue = new Queue<Node>();
        queue.Enqueue(root);
        while (queue.Count != 0)
        {
            int levelLen = queue.Count;
            var list = new List<int>();
            for (int i = 0; i < levelLen; i++)
            {
                var curr = queue.Dequeue();
                list.Add(curr.val);
                if (curr.children == null)
                    continue;
                foreach (var child in curr.children)
                {
                    if (child == null)
                        continue;
                    queue.Enqueue(child);
                }
            }
            result.Add(list);
        }

        return result;
    }
}
