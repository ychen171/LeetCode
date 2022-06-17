public class Solution
{
    int[] nums;
    Dictionary<int, List<int>> numIndexDict;
    Random random;
    // Time: O(n)
    // Space: O(n)
    public Solution(int[] nums)
    {
        this.nums = nums;
        numIndexDict = new Dictionary<int, List<int>>();
        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            if (!numIndexDict.ContainsKey(num))
                numIndexDict[num] = new List<int>();
            numIndexDict[num].Add(i);
        }

        random = new Random();
    }

    // Time: O(1)
    // Space: O(1)
    public int Pick(int target)
    {
        List<int> indexList = numIndexDict[target];
        int i = random.Next(0, indexList.Count);
        return indexList[i];
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(nums);
 * int param_1 = obj.Pick(target);
 */
