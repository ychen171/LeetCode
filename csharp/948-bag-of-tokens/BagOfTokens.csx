public class Solution
{
    // Greedy + Two Pointers
    // Time: O(n log n)
    // Space: O(n)
    public int BagOfTokensScore(int[] tokens, int power)
    {
        int n = tokens.Length;
        if (n == 0)
            return 0;

        Array.Sort(tokens);
        int left = 0, right = n - 1;
        int score = 0;
        while (left <= right)
        {
            // gain as many scores as possible
            while (left <= right && power >= tokens[left])
            {
                power -= tokens[left];
                left++;
                score++;
            }
            // only 2 or less tokens left
            if (right - left < 2)
                break;
            // no score left
            if (score == 0)
                break;
            // gain the largest power that can be used
            if (score > 0 && power + tokens[right] >= tokens[left])
            {
                power += tokens[right];
                right--;
                score--;
            }
        }

        return score;
    }
}
