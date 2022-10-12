public class Solution
{
    // LIS
    // Time: O(n log 3) => O(n)
    // Space: O(3) => O(1)
    public bool IncreasingTriplet(int[] nums)
    {
        /*
            20  100 10  12  5   13
            ijk
            i   j
                    ij
                    i   j
        */
        var n = nums.Length;
        if (n < 3)
            return false;

        var list = new List<int>();
        list.Add(nums[0]);
        for (int i = 1; i < n; i++)
        {
            var num = nums[i];
            if (num > list.Last())
            {
                list.Add(num);
            }
            else // binary search to find the smallest num that is greater than nums[i]
            {
                var index = BinarySearchLB(list, num);
                list[index] = num;
            }
            if (list.Count == 3)
                return true;
        }
        return false;
    }

    private int BinarySearchLB(IList<int> list, int target)
    {
        int n = list.Count;
        int left = 0, right = n - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (list[mid] < target)
                left = mid + 1;
            else if (list[mid] > target)
                right = mid - 1;
            else //
                right = mid - 1;
        }
        if (left == n) return -1;
        return left;
    }

    // Linear Scan | Mind boggling
    // Time: O(n)
    // Space: O(1)
    public bool IncreasingTriplet1(int[] nums)
    {
        int first = int.MaxValue;
        int second = int.MaxValue;
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] <= first)
                first = nums[i];
            else if (nums[i] <= second)
                second = nums[i];
            else
                return true;
        }
        return false;
    }
}
