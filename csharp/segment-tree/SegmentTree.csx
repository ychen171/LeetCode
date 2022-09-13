/*
    array size: n = 4, tree size: 2*n = 8
                                1:[0,4)
            2:[0,2)                             3:[2,4)
    4:0               5:1               6:2               7:3
*/

public class SegmentTree
{
    int n; // array size
    int[] tree;

    public SegmentTree(int n)
    {
        this.n = n;
        tree = new int[2 * n];
    }

    public SegmentTree(int[] arr)
    {
        this.n = arr.Length;
        tree = new int[2 * n];
        for (int i = 0; i < n; i++)
        {
            tree[n + i] = arr[i];
        }
    }

    public void Build()
    {
        for (int i = n - 1; i > 0; i--)
        {
            // tree[i] = tree[i << 1] + tree[i << 1 | 1];
            tree[i] = tree[2 * i] + tree[2 * i + 1];
        }
    }

    public void Modify(int p, int value) // set value at position p
    {
        // for (tree[p += n] = value; p > 1; p >>= 1)
        // {
        //     // tree[p / 2] = tree[p] + tree[p + 1], (p is left child, p % 2 == 0)
        //     // tree[p / 2] = tree[p - 1] + tree[p], (p is right child, p % 2 == 1)
        //     tree[p >> 1] = tree[p] + tree[p ^ 1];
        // }

        p += n;
        tree[p] = value;
        while (p > 1)
        {
            p >>= 1;
            tree[p] = Math.Max(tree[2 * p], tree[2 * p + 1]);
        }
    }

    public int Query(int l, int r) // sum of interval [l, r)
    {
        int result = 0;
        for (l += n, r += n; l < r; l >>= 1, r >>= 1)
        {
            if (l % 2 == 1) // l is right child
                result += tree[l++];
            if (r % 2 == 1) // r is left child
                result += tree[--r];
        }

        return result;
    }

}

var tree = new SegmentTree(16);
tree.Build();
tree.Modify(0, 1);
var result = tree.Query(0, 11);
Console.WriteLine(result);
