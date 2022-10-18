public class Solution
{
    // Dictionary
    // Time: O(n)
    // Space: O(n)
    public int MajorityElement(int[] nums)
    {
        int n = nums.Length;
        if (n == 1)
            return nums[0];

        var countDict = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            countDict[num] = countDict.GetValueOrDefault(num, 0) + 1;
            if (countDict[num] > n / 2)
                return num;
        }

        return nums.Last();
    }

    // Boyer-Moore Voting Algo
    // Time: O(n)
    // Space: O(1)
    public int MajorityElement1(int[] nums)
    {
        int n = nums.Length;
        int target = 0, count = 0;
        foreach (var num in nums)
        {
            if (count == 0)
                target = num;
            if (num == target)
                count++;
            else
                count--;
        }
        return target;
    }
}
