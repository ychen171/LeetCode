public class NumArray
{
    int[] nums;
    int[] prefixSum;
    public NumArray(int[] nums)
    {
        this.nums = nums;
        int n = nums.Length;
        prefixSum = new int[n + 1];
        for (int i = 1; i < n + 1; i++)
            prefixSum[i] = prefixSum[i - 1] + nums[i - 1];
    }

    public void Update(int index, int val)
    {
        nums[index] = val;
        for (int i = index + 1; i < prefixSum.Length; i++)
            prefixSum[i] = prefixSum[i - 1] + nums[i - 1];
    }

    public int SumRange(int left, int right)
    {
        return prefixSum[right + 1] - prefixSum[left];
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

