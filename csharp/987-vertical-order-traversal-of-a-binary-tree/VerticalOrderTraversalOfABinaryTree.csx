
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
    public IList<IList<int>> VerticalTraversal(TreeNode root)
    {
        var result = new List<IList<int>>();

        var dict = new Dictionary<int, Dictionary<int, List<int>>>();
        Helper(root, 0, 0, dict);

        var cols = dict.Keys.ToArray();
        Array.Sort(cols);
        foreach (var col in cols)
        {
            var rowDict = dict[col];
            var rows = rowDict.Keys.ToArray();
            Array.Sort(rows);
            var list = new List<int>();
            foreach (var row in rows)
            {
                var subList = dict[col][row];
                subList.Sort();
                list.AddRange(subList);
            }
            result.Add(list);
        }

        return result;
    }

    public void Helper(TreeNode node, int row, int col, Dictionary<int, Dictionary<int, List<int>>> dict)
    {
        // base case
        if (node == null)
            return;

        // recursive case
        if (!dict.ContainsKey(col))
            dict[col] = new Dictionary<int, List<int>>();
        if (!dict[col].ContainsKey(row))
            dict[col][row] = new List<int>();
        dict[col][row].Add(node.val);

        Helper(node.left, row + 1, col - 1, dict);
        Helper(node.right, row + 1, col + 1, dict);
    }
}
