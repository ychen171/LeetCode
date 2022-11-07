public class Solution
{
    // Greedy
    // Time: O(n)
    // Space: O(n)
    public int Maximum69Number(int num)
    {
        // find the index of the left most 6
        var digits = new List<int>();
        while (num > 0)
        {
            digits.Add(num % 10);
            num /= 10;
        }
        for (int i = digits.Count - 1; i >= 0; i--)
        {
            if (digits[i] == 6)
            {
                digits[i] = 9;
                break;
            }
        }
        int ans = 0;
        for (int i = digits.Count - 1; i >= 0; i--)
        {
            ans = ans * 10 + digits[i];
        }
        return ans;
    }
}
