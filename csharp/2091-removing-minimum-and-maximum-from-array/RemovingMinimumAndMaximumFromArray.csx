public class Solution
{
    // Greedy
    // Time: O(n)
    // Space: O(1)
    public int MinimumDeletions(int[] nums)
    {
        // 2 10 7 5 4 1 8 6
        //   MAX     MIN
        //  2, 7     6, 3
        //    2       3      2+3=5

        // 0  -4  19  1  8  -2  -3  5
        //   MIN  MAX
        //  2,7   3,6
        //   2     3

        // [-1,-53,93,-42,37,94,97,82,46,42,-99,56,-76,-66,-67,-13,10,66,85,-28]
        //                      MAX         MIN
        //                     7, 14       11 ,10

        // edge case
        int n = nums.Length;
        if (n <= 2)
            return n;

        // n >= 3
        // find the index of min and max
        int min = int.MaxValue;
        int max = int.MinValue;
        int minIndex = -1;
        int maxIndex = -1;
        for (int i = 0; i < n; i++)
        {
            int num = nums[i];
            if (num < min)
            {
                min = Math.Min(min, num);
                minIndex = i;
            }
            if (num > max)
            {
                max = Math.Max(max, num);
                maxIndex = i;
            }
        }

        // int leftToMinCount = minIndex + 1;
        // int rightToMinCount = n - minIndex;
        var minCount = new int[] { minIndex + 1, n - minIndex };
        // int leftToMaxCount = maxIndex + 1;
        // int rightToMaxCount = n - maxIndex;
        var maxCount = new int[] { maxIndex + 1, n - maxIndex };

        int[] leftCount, rightCount;
        if (minCount[0] < maxCount[0])
        {
            leftCount = minCount;
            rightCount = maxCount;
        }
        else
        {
            leftCount = maxCount;
            rightCount = minCount;
        }

        // compare three options:
        // delete from left side
        var leftDeletions = Math.Max(leftCount[0], rightCount[0]);
        // delete from right side
        var rightDeletions = Math.Max(leftCount[1], rightCount[1]);
        // delete from both sides
        var bothDeletions = leftCount[0] + rightCount[1];

        return Math.Min(Math.Min(leftDeletions, rightDeletions), bothDeletions);
    }
}

var s = new Solution();
var nums = new int[] { -1, -53, 93, -42, 37, 94, 97, 82, 46, 42, -99, 56, -76, -66, -67, -13, 10, 66, 85, -28 };
var result = s.MinimumDeletions(nums);
Console.WriteLine(result);
