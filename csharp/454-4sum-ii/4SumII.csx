public class Solution
{
    // Dictionary | divide and conquer
    // Time: O(n^2)
    // Space: O(n^2)
    public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
    {
        // 2Sum + 2Sum = 0    
        // a+b, c+d;
        var twoSumCountDict = new Dictionary<int, int>();
        int ans = 0;
        foreach (var a in nums1)
        {
            foreach (var b in nums2)
            {
                var twoSum = a + b;
                twoSumCountDict[twoSum] = twoSumCountDict.GetValueOrDefault(twoSum, 0) + 1;
            }
        }

        foreach (var c in nums3)
        {
            foreach (var d in nums4)
            {
                var comp = -(c + d);
                if (twoSumCountDict.ContainsKey(comp))
                {
                    ans += twoSumCountDict[comp];
                }
            }
        }

        return ans;
    }

    public int FourSumCountGeneric(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
    {
        return KSumCount(new int[][] {nums1, nums2, nums3, nums4});
    }

    public int KSumCount(int[][] kNums)
    {
        var dict = new Dictionary<int, int>();
        AddToHash(kNums, 0, 0, dict);
        return CountComplements(kNums, 0, kNums.Length / 2, dict);
    }

    // backtracking
    // Time: O(n^(k/2))
    // Space: O(n^(k/2))
    private void AddToHash(int[][] kNums, int sum, int i, Dictionary<int, int> dict)
    {
        // base case
        if (i == kNums.Length / 2)
        {
            dict[sum] = dict.GetValueOrDefault(sum, 0) + 1;
            return;
        }
        // recursive case
        foreach (var num in kNums[i])
        {
            sum += num;
            AddToHash(kNums, sum, i + 1, dict);
            sum -= num;
        }
    }

    private int CountComplements(int[][] kNums, int complement, int i, Dictionary<int, int> dict)
    {
        // base case
        if (i == kNums.Length)
            return dict.GetValueOrDefault(complement, 0);
        // recursive case
        int count = 0;
        foreach (var num in kNums[i])
        {
            complement -= num;
            count += CountComplements(kNums, complement, i+1, dict);
            complement += num;
        }

        return count;
    }
}
