public class Solution
{
    // Two pointers | TwoSum sorted | Three pointers?
    // Time: O(n^2)
    // Space: O(n)
    public int ThreeSumClosest(int[] nums, int target)
    {
        int diff = int.MaxValue;
        List<int> sorted = nums.ToList();
        sorted.Sort();
        for (int i=0; i < sorted.Count && diff != 0; i++)
        {
            int lo = i + 1;
            int hi = sorted.Count - 1;
            while (lo < hi)
            {
                int sum = sorted[i] + sorted[lo] + sorted[hi];
                if (Math.Abs(target - sum) < Math.Abs(diff))
                    diff = target - sum;
                if (sum < target) lo++;
                else hi--;
            }
        }

        return target - diff;
    }
}

var s = new Solution();
// Console.WriteLine(s.ThreeSumClosest(new int[] { -1, 2, 1, -4 }, 1));
// Console.WriteLine(s.ThreeSumClosest(new int[] { 0, 0, 0 }, 1));
// Console.WriteLine(s.ThreeSumClosest(new int[] { 1,1,1,1 }, 0));
Console.WriteLine(s.ThreeSumClosest(new int[] { 4, 0, 5, -5, 3, 3, 0, -4, -5 }, -2));

