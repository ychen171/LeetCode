public class NumArray
{
    int[] tree;
    int n;
    // Time: O(n)
    // Space: O(n)
    public NumArray(int[] nums)
    {
        this.n = nums.Length;
        this.tree = new int[2 * n];
        // build tree
        BuildTree(nums);
    }

    public void BuildTree(int[] nums)
    {
        for (int i = n, j = 0; j < n; i++, j++)
            tree[i] = nums[j];
        for (int i = n - 1; i >= 0; i--)
            tree[i] = tree[i * 2] + tree[i * 2 + 1];
    }

    // Time: O(log n)
    // Space: O(1)
    public void Update(int index, int val)
    {
        int i = index + n;
        tree[i] = val;
        while (i > 0)
        {
            int left = i;
            int right = i;
            if (i % 2 == 0)
                right = i + 1;
            else
                left = i - 1;
            tree[i / 2] = tree[left] + tree[right];
            i /= 2;
        }
    }

    // Time: O(log n)
    // Space: O(1)
    public int SumRange(int left, int right)
    {
        int l = left + n;
        int r = right + n;
        int sum = 0;
        while (l <= r)
        {
            if (l % 2 == 1) // check if l is right child of its parent
            {
                sum += tree[l];
                l++;
            }
            if (r % 2 == 0) // check if r is left child of its parent
            {
                sum += tree[r];
                r--;
            }
            l /= 2;
            r /= 2;
        }

        return sum;
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

