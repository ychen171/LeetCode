public class Solution
{
    // Greedy + Two Pointers
    // Time: O(n^2)
    // Space: O(n)
    public int MinMovesToMakePalindrome(string s)
    {
        int n = s.Length;
        if (n <= 2)
            return 0;

        var cs = s.ToCharArray();
        int left = 0, right = n - 1;
        int count = 0;
        int center = -1;
        while (left + 1 < right)
        {
            // for the target, find the position for the matched char
            char target = cs[right];
            int i = left;
            while (i < right)
            {
                if (cs[i] == cs[right])
                    break;
                i++;
            }
            // curr char doesn't have pair, note it and skip
            if (i == right)
            {
                center = right;
                right--;
                continue;
            }
            // swap the matched char to correct position
            while (i != left)
            {
                Swap(cs, i - 1, i);
                i--;
                count++;
            }
            left++;
            right--;
        }

        // has center char, move the center char to the center position
        if (center != -1) 
        {
            int i = center;
            while (i > n / 2)
            {
                Swap(cs, i - 1, i);
                i--;
                count++;
            }
        }

        return count;
    }

    public void Swap(char[] cs, int left, int right)
    {
        var temp = cs[left];
        cs[left] = cs[right];
        cs[right] = temp;
    }
}

var sln = new Solution();
var s = "scpcyxprxxsjyjrww";
/*
scpcyxprxxsjyjrww
wscpcyxprxxsjyjrw   w   15
wrscpcyxpxxsjyjrw   r   7
wrjscpcyxpxxsyjrw   j   10
wrjyscpcxpxxsyjrw   y   4
wrjyscpcxpxxsyjrw   s   0
wrjysxcpcpxxsyjrw   x   3
wrjysxcpcpxxsyjrw   x   skip    center = right     right--
wrjysxpccpxxsyjrw   p   1
wrjysxpccpxxsyjrw   c   0
wrjysxpcxcpxsyjrw   x   2
*/
var result = sln.MinMovesToMakePalindrome(s);
Console.WriteLine(result);

