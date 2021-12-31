
// Priority Queue | Heap
// Time: O(N*log(N) + M*log(K))
// Space: O(N)
public class KthLargest
{
    private int k;
    private Queue<int> heap; // PriorityQueue
    public KthLargest(int k, int[] nums)
    {
        this.k = k;
        heap = new Queue<int>();
        foreach (var num in nums)
        {
            heap.Enqueue(num);
        }
        while (heap.Count > k)
        {
            heap.Dequeue();
        }
    }
    public int Add(int val)
    {
        heap.Enqueue(val);
        if (heap.Count > k)
        {
            heap.Dequeue();
        }
        return heap.Peek();
    }
}

// Iterative
// Time: 
// Space: 
public class KthLargest1
{
    public TreeNode root;
    public int k;
    public KthLargest1(int k, int[] nums)
    {
        this.k = k;
        if (nums.Length == 0) return;
        for (int i = 0; i < nums.Length; i++)
            Insert(nums[i]);
    }
    public int Add(int val)
    {
        Insert(val);
        return FindK();
    }
    public void Insert(int val)
    {
        if (root == null)
        {
            root = new TreeNode(val);
            return;
        }
        TreeNode parent = null;
        TreeNode curr = root;
        while (curr != null)
        {
            parent = curr;
            curr.count++;
            if (curr.val == val)
                break;
            else if (curr.val < val)
                curr = curr.right;
            else
                curr = curr.left;
        }
        if (curr != null && curr.val == val)
            return;
        if (parent.val < val)
            parent.right = new TreeNode(val);
        else
            parent.left = new TreeNode(val);
    }
    public int FindK()
    {
        TreeNode parent = null;
        TreeNode curr = root;
        var remainder = k;
        while (curr != null && remainder > 0)
        {
            parent = curr;
            if (curr.right == null)
            {
                remainder -= 1;
                curr = curr.left;
            }
            else
            {
                if (remainder > curr.right.count)
                {
                    remainder -= curr.right.count + 1;
                    curr = curr.left;
                }
                else
                {
                    curr = curr.right;
                }
            }
        }
        return parent.val;
    }
}

// Recursive
// Time: O(N * H): O(N log(N)) in average, O(N^2) in worst
// Space: 
public class KthLargest2
{
    private TreeNode root;
    private int k;
    public KthLargest2(int k, int[] nums)
    {
        this.k = k;
        root = null;
        for (int i = 0; i < nums.Length; i++)
            root = InsertNode(root, nums[i]);
    }
    public int Add(int val)
    {
        root = InsertNode(root, val);
        return SearchKth(root, k);
    }
    private TreeNode InsertNode(TreeNode root, int num)
    {
        if (root == null) return new TreeNode(num, 1);
        if (root.val < num)
            root.right = InsertNode(root.right, num);
        else
            root.left = InsertNode(root.left, num);
        root.count++;
        return root;
    }
    private int SearchKth(TreeNode root, int k)
    {
        // m = the size of right subtree
        int m = root.right != null ? root.right.count : 0;
        // root is the m+1 largest node in the BST
        if (k == m + 1)
            return root.val;
        if (k <= m)
            return SearchKth(root.right, k);
        else
            return SearchKth(root.left, k - m - 1);
    }
}

public class TreeNode
{
    public int val;
    public int count;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, int count = 1, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.count = count;
        this.left = left;
        this.right = right;
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */


var k = new KthLargest1(2, new int[] { 0 });
Console.WriteLine(k.Add(-1));
Console.WriteLine(k.Add(1));
Console.WriteLine(k.Add(-2));
Console.WriteLine(k.Add(-4));
Console.WriteLine(k.Add(3));




