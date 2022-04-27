public class Solution
{
    // Reverse two levels
    // Time: O(n)
    // Space: O(1)
    public void ReverseWords(char[] s)
    {
        // the sky is blue
        // eulb si yks eht
        // blue is sky the

        if (s.Length == 1)
            return;

        // reverse string
        Reverse(s, 0, s.Length - 1);
        // reverse each word in the reversed string
        ReverseEachWord(s);
    }

    private void Reverse(char[] s, int left, int right)
    {
        while (left < right)
        {
            char temp = s[left];
            s[left] = s[right];
            s[right] = temp;
            left++;
            right--;
        }
    }

    private void ReverseEachWord(char[] s)
    {
        int n = s.Length;
        int left = 0;
        int right = 0;
        while (left < n)
        {
            while (right < n && s[right] != ' ')
            {
                right++;
            }
            Reverse(s, left, right - 1);
            right++;
            left = right;
        }
    }
}
