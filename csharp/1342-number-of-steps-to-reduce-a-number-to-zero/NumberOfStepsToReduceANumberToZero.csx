public class Solution
{
    // Bit Manipulation
    // Time: O(log n)
    // Space: O(1)
    public int NumberOfSteps(int num)
    {
        int step = 0;
        while (num != 0)
        {
            if (num % 2 == 0)
            {
                num >>= 1;
            }
            else
            {
                num--;
            }
            step++;
        }

        return step;
    }

    // Time: O(log n)
    // Space: O(1)
    public int NumberOfSteps1(int num)
    {
        int step = 0;
        string binary = Convert.ToString(num, 2);
        foreach (var c in binary)
        {
            if (c == '1')
                step += 2;
            else
                step += 1;
        }

        return step - 1; // subtract 1, becasue the last bit was over-counted
    }
}
