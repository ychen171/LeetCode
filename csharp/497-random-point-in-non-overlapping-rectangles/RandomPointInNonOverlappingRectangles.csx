// Prefix Sum + Binary Search + Randomize
public class Solution
{
    int[][] rects;
    int len;
    int[] areas;
    int[] prefixSum;
    int totalSum;
    Random random;
    // Time: O(n)
    // Space: O(n)
    public Solution(int[][] rects)
    {
        // rects [-2,-2, 1, 1], [2, 2, 4, 6]
        // index     0              1
        // area   3*3=9           2*4=8
        // prefixSum 0              9            17
        // totalSum    17

        // random pick currSum = [1, 17]    17 different picks
        // [1, 9]  ---> return index 0
        // [10, 17] ---> return index 1

        // random pick currSum = [0, 16]    17 different picks
        // [0, 8]  ---> return index 0
        // [9, 16] ---> return index 1

        this.rects = rects;
        len = rects.Length;
        areas = new int[len];
        for (int i = 0; i < len; i++)
        {
            var rect = rects[i];
            int a = rect[0];
            int b = rect[1];
            int x = rect[2];
            int y = rect[3];
            int area = (x - a + 1) * (y - b + 1); // xlen + 1, ylen + 1
            areas[i] = area;
        }
        prefixSum = new int[len + 1];
        for (int i = 1; i < len + 1; i++)
        {
            prefixSum[i] = prefixSum[i - 1] + areas[i - 1];
        }
        totalSum = prefixSum.Last();
        random = new Random();
    }

    // Time: O(log (area))
    // Space: O(1)
    public int[] Pick()
    {
        int currSum = random.Next(1, totalSum + 1);
        int index = BinarySearchLeftMost(prefixSum, currSum) - 1;
        // int currSum = random.Next(totalSum);
        // int index = BinarySearchRightMost(prefixSum, currSum);
        int[] rect = rects[index];
        int a = rect[0];
        int b = rect[1];
        int x = rect[2];
        int y = rect[3];

        int u = random.Next(a, x + 1);
        int v = random.Next(b, y + 1);
        return new int[] { u, v };
    }
    public int BinarySearchLeftMost(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;
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

        return left; // target <= nums[left] || nums[right] < target
    }
    public int BinarySearchRightMost(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;
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

        return right; // target < nums[left] || nums[right] <= target
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(rects);
 * int[] param_1 = obj.Pick();
 */
