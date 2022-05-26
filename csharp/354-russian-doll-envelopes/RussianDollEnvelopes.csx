public class Solution
{
    public int MaxEnvelopes(int[][] envelopes)
    {
        if (envelopes.Length == 1)
            return 1;
        int n = envelopes.Length;
        // sort the array on first element in ascending order
        // sort the array on second element in descending order
        var comparer = new EnvelopeComparer();
        Array.Sort(envelopes, comparer);

        // extract the second dimension and run LIS
        var secondDim = new int[n];
        for (int i = 0; i < n; i++)
        {
            secondDim[i] = envelopes[i][1];
        }

        return LengthOfLIS(secondDim);
    }

    public int LengthOfLIS(int[] nums)
    {
        var list = new List<int>();
        list.Add(nums[0]);

        for (int i = 1; i < nums.Length; i++)
        {
            int num = nums[i];
            if (num > list.Last())
                list.Add(num);
            else
            {
                int j = BinarySearch(list, num);
                list[j] = num;
            }
        }

        return list.Count;
    }

    public int BinarySearch(List<int> list, int target)
    {
        int left = 0;
        int right = list.Count - 1;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (list[mid] == target)
            {
                return mid;
            }
            else if (list[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

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
