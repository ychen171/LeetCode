public class Solution
{
    // Naive
    // Time: O(log n)
    // Space: O(1)
    public bool IsPowerOfThree(int n)
    {
        if (n < 1)
            return false;

        while (n > 1)
        {
            int remainder = n % 3;
            if (remainder != 0)
                return false;
            n /= 3;
        }

        return n == 1;
    }

    // Brute force + Precomputations
    // Time: O(1)
    // Space: O(1)
    public bool IsPowerOfThree1(int n)
    {
        var nums = new HashSet<int>();
        int lastNum = 1;
        nums.Add(1);
        for (int i = 1; i < 21; i++)
        {
            lastNum *= 3;
            nums.Add(lastNum);
        }

        return nums.Contains(n);
    }

    // Math
    // Time: O(1)
    // Space: O(1)
    public bool IsPowerOfThree2(int n)
    {
        return (n > 0) && (Math.Log10(n) / Math.Log10(3) % 1 == 0);
    }

    public bool IsPowerOfThree3(int n)
    {
        if (n < 1) return false;
        double maxD = (Math.Log(int.MaxValue) / Math.Log(3));
        int maxI = 0;
        while (maxI <= maxD)
            maxI++;
        maxI--;

        return Math.Pow(3, maxI) % n == 0;
    }
}

var sln = new Solution();
var result = sln.IsPowerOfThree1(243);
Console.WriteLine(result);
