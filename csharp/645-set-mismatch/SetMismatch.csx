public class Solution
{
    // XOR 
    // Time: O(n)
    // Space: O(1)
    public int[] FindErrorNums(int[] nums)
    {
        int xor = 0, xor0 = 0, xor1 = 0;
        foreach (var num in nums)
            xor ^= num;
        int n = nums.Length;
        for (int num = 1; num <= n; num++)
            xor ^= num;
        int rightMostBit = xor & ~(xor - 1);
        foreach (var num in nums)
        {
            if ((num & rightMostBit) != 0)
                xor1 ^= num;
            else
                xor0 ^= num;
        }
        for (int num = 1; num <= n; num++)
        {
            if ((num & rightMostBit) != 0)
                xor1 ^= num;
            else
                xor0 ^= num;
        }
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == xor0)
                return new int[] { xor0, xor1 };
        }
        return new int[] { xor1, xor0 };
    }

    // HashSet
    // Time: O(n)
    // Space: O(n)
    public int[] FindErrorNums1(int[] nums)
    {
        int n = nums.Length;
        var ans = new int[2];
        var set = new HashSet<int>();
        foreach (var num in nums)
        {
            if (!set.Add(num))
                ans[0] = num;
        }

        for (int num = 1; num <= n; num++)
        {
            if (!set.Contains(num))
                ans[1] = num;
        }

        return ans;
    }
}

