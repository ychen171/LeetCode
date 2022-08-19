public class Solution
{
    // Greedy | Dictionary
    // Time: O(n)
    // Space: O(n)
    public bool IsPossible(int[] nums)
    {
        var freq = new Dictionary<int, int>();
        var need = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            freq[num] = freq.GetValueOrDefault(num, 0) + 1;
            need[num] = 0;
        }

        foreach (var num in nums)
        {
            if (freq[num] == 0)
                continue;
            // check if num can be appended to the existing subset
            // check if num can be the beginning of new subset
            if (freq[num] > 0 && need[num] > 0)
            {
                need[num]--;
                freq[num]--;
                need[num + 1] = need.GetValueOrDefault(num + 1, 0) + 1;
            }
            else if (freq[num] > 0 && freq.ContainsKey(num + 1) && freq[num + 1] > 0 && freq.ContainsKey(num + 2) && freq[num + 2] > 0)
            {
                freq[num]--;
                freq[num + 1]--;
                freq[num + 2]--;
                need[num + 3] = need.GetValueOrDefault(num + 3, 0) + 1;
            }
            else
            {
                return false;
            }
        }

        return true;
    }
}
