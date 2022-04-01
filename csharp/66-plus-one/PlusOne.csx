public class Solution
{
    // Brute force
    // Time: O(n)
    // Space: O(n)
    public int[] PlusOne(int[] digits)
    {
        int n = digits.Length;
        for (int i = n - 1; i >= 0; i--)
        {
            if (digits[i] == 9)
            {
                digits[i] = 0;
            }
            else
            {
                digits[i]++;
                return digits;
            }
        }
        
        var answer = new int[n + 1];
        answer[0] = 1;
        return answer;
    }
}
