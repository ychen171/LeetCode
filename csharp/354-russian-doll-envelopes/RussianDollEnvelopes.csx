public class Solution
{
    // Sorting + LIS | BinarySearch
    // Time: O(n log n)
    // Space: O(n)
    public int MaxEnvelopes(int[][] envelopes)
    {
        int n = envelopes.Length;
        if (n == 1)
            return 1;
        // sort by first element in ascending order and second element in descending order
        Array.Sort(envelopes, (a, b) =>
        {
            if (a[0] == b[0])
                return b[1] - a[1];
            return a[0] - b[0];
        });
        // extract second elements into a list
        var secondDim = new int[n];
        for (int i = 0; i < n; i++)
        {
            secondDim[i] = envelopes[i][1];
        }
        // LIS
        return LengthOfLIS(secondDim);
    }

    // Time: O(n log n)
    // Space: O(n)
    public int LengthOfLIS(int[] nums)
    {
        var list = new List<int>();
        list.Add(nums[0]);
        for (int i = 1; i < nums.Length; i++)
        {
            var target = nums[i];
            if (list.Last() < target) // add to the list
                list.Add(target);
            else // binary search the list to find the position to replace
            {
                int index = BinarySearchLeftBound(list, target);
                if (index != -1)
                    list[index] = target;
            }
        }

        return list.Count;
    }

    public int BinarySearchLeftBound(List<int> list, int target)
    {
        int left = 0;
        int right = list.Count - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (list[mid] < target)
                left = mid + 1;
            else if (list[mid] > target)
                right = mid - 1;
            else // ==
                right = mid - 1;
        }
        if (left == list.Count) return -1;
        return left;
    }

    public class EnvelopeComparer : IComparer<int[]>
    {
        int IComparer<int[]>.Compare(int[]? x, int[]? y)
        {
            if (x == null || y == null)
                return 0;
            if (x[0] == y[0])
            {
                return y[1] - x[1];
            }
            else
            {
                return x[0] - y[0];
            }
        }
    }
}
