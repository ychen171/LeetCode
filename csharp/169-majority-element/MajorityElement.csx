public class Solution
{
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
}
