public class Solution
{
    // Sorting + Binary Search
    // Time: O(n^2 * log n)
    // Space: O(n)
    public int TriangleNumber(int[] nums)
    {
        // Sort
        Array.Sort(nums);
        // Binary Search
        // Given nums[i] <= nums[j] <= nums[k] 
        // foreach nums[i], find j and k, so that:
        // nums[i] + nums[j] > nums[k]
        // nums[i] + nums[k] > nums[j]
        // nums[j] + nums[k] > nums[i]

        int n = nums.Length;
        int ans = 0;
        for (int i = 0; i < n - 2; i++)
        {
            for (int j = i + 1; j < n - 1; j++)
            {
                // find the maximum nums[k], where nums[k] < nums[i] + nums[j]
                // binary search on [j+1, n-1], target = nums[i] + nums[j] - 1
                // find the right most k, nums[k] >= target

                int target = nums[i] + nums[j] - 1;
                int left = j + 1;
                int right = n - 1;
                while (left < right)
                {
                    // [...mid-1][mid, ...]
                    int mid = left + (right - left + 1) / 2;
                    if (nums[mid] > target)
                        right = mid - 1;
                    else
                        left = mid;
                }

                int k = nums[right] > target ? right - 1 : right;
                if (j < k)
                    ans += k - j;
            }
        }

        return ans;
    }

    // Sorting + Two Pointers
    // Time: O(n^2)
    // Space: O(n)
    public int TriangleNumber1(int[] nums)
    {
        // Given nums[i] <= nums[j] <= nums[k] 
        // foreach nums[i], find j and k, so that:
        // nums[i] + nums[j] > nums[k]

        // Sort
        Array.Sort(nums);
        int n = nums.Length;
        // Two Pointers
        int ans = 0;
        for (int i = 0; i < n - 2; i++)
        {
            if (nums[i] == 0)
                continue;
            int k = i + 2;
            for (int j = i + 1; j < n - 1; j++)
            {
                if (nums[j] == 0)
                    continue;
                // find the right most k
                while (k < n && nums[i] + nums[j] > nums[k])
                {
                    k++;
                }
                ans += k - 1 - j;
            }
        }

        return ans;
    }
}
