public class Solution
{
    int len;
    int[] prefixSum;
    int totalSum;
    int currSum;
    Random random;
    // [1, 3]          -- w
    // [0, 1, 4]       -- prefixSum
    // 4               -- sum
    // [0, 1, 2, 3]    -- currSum
    //  0  1  1  1     -- index

    // Time: O(n)
    // Space: O(n)
    public Solution(int[] w)
    {
        len = w.Length;
        prefixSum = new int[len + 1];
        for (int i = 1; i < len + 1; i++)
        {
            prefixSum[i] = prefixSum[i - 1] + w[i - 1];
        }
        totalSum = prefixSum.Last();
        currSum = 0;
        random = new Random();
    }

    // Time: O(log n)
    // Space: O(1)
    public int PickIndex()
    {
        int index = 0;
        currSum = random.Next(0, totalSum); // [0, totalSum)
        // linear search
        // for (int i = 0; i < len + 1; i++)
        // {
        //     if (currSum < prefixSum[i])
        //     {
        //         index = i - 1;
        //         break;
        //     }
        // }
        // binary search
        index = BinarySearchRight(prefixSum, currSum);

        return index;
    }

    public int BinarySearchRight(int[] nums, int target)
    {
        int n = nums.Length;
        int left = 0;
        int right = n - 1;
        // [..., mid-1][mid, ...]
        while (left < right)
        {
            int mid = left + (right - left + 1) / 2;
            if (nums[mid] > target)
            {
                right = mid - 1;
            }
            else // nums[mid] <= target
            {
                left = mid;
            }
        }

        return right; // nums[right] <= target
    }
    public int BinarySearchLeft(int[] nums, int target)
    {
        int n = nums.Length;
        int left = 0;
        int right = n - 1;
        // [..., mid][mid+1, ...]
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else // nums[mid] >= target
            {
                right = mid;
            }
        }

        return left; // target <= nums[left]
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(w);
 * int param_1 = obj.PickIndex();
 */


var sln = new Solution(new int[] { });
var nums = new int[] { 0, 1, 4 };
int target;
Console.WriteLine("Testing Binary Search Right Most");
for (target = 0; target < 4; target++)
{
    Console.WriteLine(sln.BinarySearchRight(nums, target));
}
Console.WriteLine("Testing Binary Search Left Most");
for (target = 0; target < 4; target++)
{
    Console.WriteLine(sln.BinarySearchLeft(nums, target));
}
