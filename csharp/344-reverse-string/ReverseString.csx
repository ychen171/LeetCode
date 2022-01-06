public class Solution
{
    // Recursion
    // Time: O(n)
    // Space: O(n)
    public void ReverseString(char[] s)
    {
        Helper(s, 0, s.Length - 1);
    }
    public void Helper(char[] s, int left, int right)
    {
        if (left >= right) return;
        char temp = s[left];
        s[left++] = s[right];
        s[right--] = temp;
        Helper(s, left, right);
    }

    // Iterative | two pointers
    // Time: O(n)
    // Space: O(1)
    public void ReverseStringIterative(char[] s)
    {
        if (s == null || s.Length == 1) return;
        var left = 0;
        var right = s.Length - 1;
        while (left < right)
        {
            var temp = s[left];
            s[left] = s[right];
            s[right] = temp;
            left++;
            right--;
        }
        return;
    }
}

var s = new Solution();
var input = new char[] { '1', '2', '3' };
s.ReverseString(input);
Console.WriteLine(input);



