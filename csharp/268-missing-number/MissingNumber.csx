public class Solution
{
    // HashSet
    // Time: O(n)
    // Space: O(n)
    public int MissingNumber(int[] nums)
    {
        var n = nums.Length;
        var currSet = new HashSet<int>();
        for (int i = 0; i < n; i++)
            currSet.Add(nums[i]);
        int answer = 0;
        for (int i = 0; i <= n; i++)
        {
            if (!currSet.Contains(i))
            {
                answer = i;
                break;
            }
        }

        return answer;
    }

    // Sum
    // Time: O(n)
    // Space: O(1)
    public int MissingNumber1(int[] nums)
    {
        var n = nums.Length;
        var answer = 0;
        for (int i=0; i<=n; i++)
            answer += i;
        foreach (var num in nums)
            answer -= num;
        
        return answer;
    }

    // Gauss' Formula
    // Time: O(n)
    // Space: O(1)
    public int MissingNumber2(int[] nums)
    {
        var n = nums.Length;
        var expectedSum = (0 + n) * n / 2;
        var actualSum = 0;
        foreach (var num in nums)
            actualSum += num;

        return expectedSum - actualSum;
    }
}


var s = new Solution();
Console.WriteLine(s.MissingNumber(new int[]{3,0,1}));
