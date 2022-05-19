public class Solution
{
    // Two Pointers
    // Time: O(n)
    // Space: O(n)
    public int NextGreaterElement(int n)
    {
        // input: 12
        // 1 2
        // 2 1

        // input: 21
        // 2 1
        // 

        // scan from right to left, find the decresing point
        // create the digit list in the reversed order
        var digits = new List<int>();
        while (n > 0)
        {
            digits.Add(n % 10);
            n /= 10;
        }
        // input: 230241, output: 230412
        //digits = [1,4,2,0,3,2]
        if (digits.Count == 1)
            return -1;

        // find the decreasing position
        int i = 0;
        bool found = false;
        for (i = 0; i < digits.Count - 1; i++)
        {
            if (digits[i] > digits[i + 1])
            {
                found = true;
                break;
            }
        }
        if (!found) // not found, early return
            return -1;

        // from right to i, find the next greater position j, where digits[j] > digits[i + 1], and swap 
        int j = 0;
        for (j = 0; j < i + 1; j++)
        {
            if (digits[j] > digits[i + 1])
            {
                Swap(digits, j, i + 1);
                break;
            }
        }
        // reverse from 0 to i to get the smallest permutation
        Reverse(digits, 0, i);
        // digits = [2,1,4,0,3,2]
        int ans = 0;
        for (int k = digits.Count - 1; k >= 0; k--)
        {
            if (ans > int.MaxValue / 10 || ans * 10 > int.MaxValue - digits[k])
                return -1;
            ans = ans * 10 + digits[k];
        }

        return ans;
    }

    private void Swap(List<int> digits, int i, int j)
    {
        int tmp = digits[i];
        digits[i] = digits[j];
        digits[j] = tmp;
    }

    private void Reverse(List<int> digits, int i, int j)
    {
        while (i < j)
        {
            Swap(digits, i, j);
            i++;
            j--;
        }
    }
}

var s = new Solution();
var result = s.NextGreaterElement(2147483476);
Console.WriteLine(result);