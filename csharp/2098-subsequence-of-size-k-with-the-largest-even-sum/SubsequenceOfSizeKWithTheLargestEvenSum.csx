public class Solution
{
    // Sort + Greedy
    // Time: O(n log n)
    // Space: O(log n)
    public long LargestEvenSum(int[] nums, int k)
    {
        // sort it in descending order
        Array.Sort(nums, (a, b) => b - a);
        // separate into odd list and even list
        var oddList = new List<int>();
        var evenList = new List<int>();
        foreach (var num in nums)
        {
            if (num % 2 == 0)
                evenList.Add(num);
            else
                oddList.Add(num);
        }
        // greedy
        int oddIndex = 0, evenIndex = 0;
        int oddCount = oddList.Count;
        int evenCount = evenList.Count;
        long sum = 0;
        while ((oddIndex < oddCount || evenIndex < evenCount) && k > 0)
        {
            if (oddIndex < oddCount && evenIndex < evenCount)
            {
                if (oddList[oddIndex] > evenList[evenIndex])
                    sum += oddList[oddIndex++];
                else
                    sum += evenList[evenIndex++];
            }
            else if (oddIndex < oddCount)
                sum += oddList[oddIndex++];
            else
                sum += evenList[evenIndex++];
            k--;
        }
        // if it is even, return
        if (sum % 2 == 0) return sum;
        // if it is odd
        // option 1. remove the last odd and replace it with the largest even from the evenList
        // option 2. remove the last even and replace it with the largest odd from the oddList
        // compare 1 and 2
        var sum1 = long.MinValue;
        var sum2 = long.MinValue;
        if (oddIndex - 1 >= 0 && oddIndex - 1 < oddCount && evenIndex >= 0 && evenIndex < evenCount)
            sum1 = sum - oddList[oddIndex - 1] + evenList[evenIndex];
        if (evenIndex - 1 >= 0 && evenIndex - 1 < evenCount && oddIndex >= 0 && oddIndex < oddCount)
            sum2 = sum - evenList[evenIndex - 1] + oddList[oddIndex];
        var result = Math.Max(sum1, sum2);
        return result == long.MinValue ? -1 : result;
    }
}

var s = new Solution();
var result = s.LargestEvenSum(new int[] { 1, 3, 5 }, 1);
Console.WriteLine(result);
