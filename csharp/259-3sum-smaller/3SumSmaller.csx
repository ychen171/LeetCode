public class Solution
{
    // Sorting + Binary Search
    // Time: O(n^2 * log n)
    // Space: O(1)
    public int ThreeSumSmaller(int[] nums, int target)
    {
        int n = nums.Length;
        // sort
        Array.Sort(nums);
        // binary search
        int ans = 0;
        for (int i = 0; i < n - 2; i++)
        {
            for (int j = i + 1; j < n - 1; j++)
            {
                int numToFind = target - nums[i] - nums[j] - 1;
                // binary search on [j+1, n-1] for numToFind
                // find the right most index k (nums[k] >= numToFind)
                int left = j + 1;
                int right = n - 1;
                while (left < right)
                {
                    // [..., mid-1][mid, ...]
                    int mid = left + (right - left + 1) / 2;
                    if (nums[mid] > numToFind)
                        right = mid - 1;
                    else
                        left = mid;
                }
                int k = nums[right] > numToFind ? right - 1 : right;
                ans += k - j;
            }
        }

        return ans;
    }

    // Sorting + Two Pointers
    // Time: O(n^2)
    // Space: O(1)
    public int ThreeSumSmaller1(int[] nums, int target)
    {
        int n = nums.Length;
        // sort
        Array.Sort(nums);
        // two pointers
        int ans = 0;
        for (int i = 0; i < n - 2; i++)
        {
            int sum2 = target - nums[i];
            int left = i + 1;
            int right = n - 1;
            while (left < right)
            {
                if (nums[left] + nums[right] < sum2)
                {
                    ans += right - left;
                    left++;
                }
                else
                {
                    right--;
                }
            }
        }

        return ans;
    }

    // Backtracking
    // Time: O(N!/((N-3)!3!)) => O(N^3)
    // Space: O(3) => O(1)
    int count = 0;
    public int ThreeSumSmallerBacktrack(int[] nums, int target)
    {
        Backtrack(nums, target, new List<int>(), 0);
        return count;
    }

    private void Backtrack(int[] nums, int target, List<int> combo, int nextStart)
    {
        // base case
        if (combo.Count == 3)
        {
            if (combo.Sum() < target)
                count++;
            return;
        }

        // recursive case
        for (int i = nextStart; i < nums.Length; i++)
        {
            // add
            combo.Add(nums[i]);
            // backtrack
            Backtrack(nums, target, combo, i + 1);
            // remove
            combo.RemoveAt(combo.Count - 1);
        }
    }
}