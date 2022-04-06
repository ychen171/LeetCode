public class Solution
{
    // Two Pointers + Dictionary
    // Time: O(n)
    // Space: O(1)
    public int RemoveDuplicates(int[] nums)
    {
        // Two Pointers + Dictionary
        // left: the position to write
        // right: the position to read
        // Dictionary: num, count pair
        int left = 0;
        int right = 0;
        var countDict = new Dictionary<int, int>();
        while (right < nums.Length)
        {
            int num = nums[right];
            int count = countDict.GetValueOrDefault(num, 0) + 1;
            countDict[num] = count;
            if (count <= 2)
            {
                nums[left] = num;
                left++;
            }
            right++;
        }
        
        return left;
    }
}
