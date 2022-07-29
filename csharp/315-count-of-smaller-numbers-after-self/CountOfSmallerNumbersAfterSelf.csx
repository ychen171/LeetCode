public class Solution
{
    // TLE
    // Brute force
    // Time: O(n^2)
    // Space: O(n)
    public IList<int> CountSmaller(int[] nums)
    {
        /*
            5   2   6   1
                        0
                    0+1=1
                0+1=1
            1+1=2

            2   1   1   0

            2   0   1
                    0
                0
            
        */

        int n = nums.Length;
        if (n == 1)
            return new List<int> { 0 };

        var arr = new int[n];
        for (int i = n - 1; i >= 0; i--)
        {
            if (i == n - 1)
            {
                arr[i] = 0;
                continue;
            }
            int count = 0;
            for (int j = i + 1; j < n; j++)
            {
                if (nums[j] < nums[i])
                    count++;
            }
            arr[i] = count;
        }

        return arr.ToList();
    }

    // Segment Tree
    // Time: O(n log m)
    // Space: O(m)
    // n is the length of nums, m is the difference between the max and min values in nums
    public IList<int> CountSmaller1(int[] nums)
    {
        int offset = 10000; // offset negative to non-negative
        int size = 2 * 10000 + 1; // total possible values in nums
        var tree = new int[size * 2];
        int n = nums.Length;
        var arr = new int[n];

        for (int i = n - 1; i >= 0; i--)
        {
            int smallerCount = Query1(0, nums[i] + offset, tree, size);
            arr[i] = smallerCount;
            Update1(nums[i] + offset, 1, tree, size);
        }

        return arr.ToList();
    }

    // implement segment tree
    private void Update1(int index, int value, int[] tree, int size)
    {
        index += size; // shift the index to the leaf
        // update from leaf to root
        tree[index] += value;
        while (index > 1)
        {
            index /= 2;
            tree[index] = tree[index * 2] + tree[index * 2 + 1];
        }
    }

    private int Query1(int left, int right, int[] tree, int size)
    {
        // return sum of [left, right]
        int result = 0;
        left += size; // shift the index to the leaf
        right += size;
        while (left < right)
        {
            // if left is a right node
            // bring the value and move to parent's right node
            if (left % 2 == 1)
            {
                result += tree[left];
                left++;
            }
            // else directly move to parent
            left /= 2;
            // if right is a right node
            // bring the value of the left node and move to parent
            if (right % 2 == 1)
            {
                right--;
                result += tree[right];
            }
            // else directly move to parent
            right /= 2;
        }

        return result;
    }

    // Merge Sort
    // Time: O(n log n)
    // Space: O(n)
    IList<int> result;
    public IList<int> CountSmaller2(int[] nums)
    {
        int n = nums.Length;
        result = new List<int>();
        var pairs = new KeyValuePair<int, int>[n];
        for (int i = 0; i < n; i++)
        {
            result.Add(0);
            pairs[i] = new KeyValuePair<int, int>(i, nums[i]);
        }

        MergeSort(pairs, 0, n - 1);

        return result;
    }

    public void MergeSort(KeyValuePair<int, int>[] pairs, int lo, int hi)
    {
        // base case
        if (lo >= hi)
            return;

        // recursive case
        int mid = lo + (hi - lo) / 2;
        MergeSort(pairs, lo, mid);
        MergeSort(pairs, mid + 1, hi);
        Merge(pairs, lo, mid, hi);
    }

    public void Merge(KeyValuePair<int, int>[] pairs, int lo, int mid, int hi)
    {
        int len = hi - lo + 1;
        var merged = new KeyValuePair<int, int>[len];
        // [lo, mid] [mid + 1, hi]
        int i = lo, j = mid + 1;
        for (int k = 0; k < len; k++)
        {
            if (i == mid + 1)
                merged[k] = pairs[j++];
            else if (j == hi + 1)
            {
                merged[k] = pairs[i++];
                result[merged[k].Key] += j - mid - 1;
            }
            else if (pairs[i].Value <= pairs[j].Value)
            {
                merged[k] = pairs[i++];
                result[merged[k].Key] += j - mid - 1;
            }
            else
                merged[k] = pairs[j++];
        }

        for (int k = 0; k < len; k++)
            pairs[k + lo] = merged[k];
    }
}

var s = new Solution();
var nums = new int[] { 1, 3, 5, 2, 4, 6, 7 };
var result = s.CountSmaller2(nums);
Console.WriteLine(result);
