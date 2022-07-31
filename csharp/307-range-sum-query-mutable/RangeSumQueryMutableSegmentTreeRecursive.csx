public class NumArray
{
    int[] tree;
    int[] nums;
    int n;
    // Time: O(n)
    // Space: O(n)
    public NumArray(int[] nums)
    {
        this.n = nums.Length;
        this.nums = nums;
        this.tree = new int[4 * n];
        // build tree
        BuildTree(0, 0, n - 1);
    }

    private void BuildTree(int treeIndex, int lo, int hi)
    {
        // base case
        if (lo >= hi)
        {
            tree[treeIndex] = nums[lo];
            return;
        }

        // recursive case
        int mid = lo + (hi - lo) / 2;
        BuildTree(2 * treeIndex + 1, lo, mid);
        BuildTree(2 * treeIndex + 2, mid + 1, hi);

        // merge build results
        tree[treeIndex] = tree[2 * treeIndex + 1] + tree[2 * treeIndex + 2];
    }

    // Time: O(log n)
    // Space: O(1)
    public void Update(int index, int val)
    {
        Update(0, 0, n - 1, index, val);
    }

    private void Update(int treeIndex, int lo, int hi, int index, int val)
    {
        // base case
        if (lo == hi)
        {
            tree[treeIndex] = val;
            return;
        }

        // recursive case
        // [lo, mid] [mid+1, hi]
        int mid = lo + (hi - lo) / 2;
        if (index <= mid) // go left
            Update(2 * treeIndex + 1, lo, mid, index, val);
        else if (index > mid) // go right
            Update(2 * treeIndex + 2, mid + 1, hi, index, val);

        // merge updates
        tree[treeIndex] = tree[2 * treeIndex + 1] + tree[2 * treeIndex + 2];
    }


    // Time: O(log n)
    // Space: O(1)
    public int SumRange(int left, int right)
    {
        return Query(0, 0, n - 1, left, right);
    }

    private int Query(int treeIndex, int lo, int hi, int left, int right)
    {
        // base case
        if (lo > right || hi < left) // out of range
            return 0;
        if (left <= lo && hi <= right) // in range
            return tree[treeIndex];

        // recurive case
        // [lo, mid] [mid+1, hi]
        int mid = lo + (hi - lo) / 2;
        int leftResult = 0, rightResult = 0;
        if (mid >= right) // go left
            leftResult = Query(2 * treeIndex + 1, lo, mid, left, right);
        else if (mid + 1 <= left) // go right 
            rightResult = Query(2 * treeIndex + 2, mid + 1, hi, left, right);
        else
        {
            leftResult = Query(2 * treeIndex + 1, lo, mid, left, mid);
            rightResult = Query(2 * treeIndex + 2, mid + 1, hi, mid + 1, right);
        }
        // merge query results
        return leftResult + rightResult;
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * obj.Update(index,val);
 * int param_2 = obj.SumRange(left,right);
 */

var nums = new int[] { 7, 2, 7, 2, 0 };
var obj = new NumArray(nums);
obj.Update(4, 6);
obj.Update(0, 2);
obj.Update(0, 9);
obj.SumRange(4, 4);
obj.Update(3, 8);
obj.SumRange(0, 4);
obj.Update(4, 1);
obj.SumRange(0, 3);
obj.SumRange(0, 4);
obj.Update(0, 4);

