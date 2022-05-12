public class Solution
{
    // HashSet
    // Time: O(n)
    // Space: O(n)
    public int LongestConsecutive(int[] nums)
    {
        //  100 4   200  1   3   2
        //  100     200     1,2,3,4
        var numSet = nums.ToHashSet();
        int maxLen = 0;
        int currLen = 0;
        // find the starting position
        // from the starting position, count the consecutive nums 
        foreach (var num in numSet)
        {
            // if num is the smallest one in its group
            // reset Count;
            if (!numSet.Contains(num - 1))
            {
                int currNum = num;
                currLen = 1;
                // count the consecutive nums
                while (numSet.Contains(currNum + 1))
                {
                    currLen++;
                    currNum++;
                }
                // update max 
                maxLen = Math.Max(maxLen, currLen);
            }
        }

        return maxLen;
    }
}
