public class Solution
{
    // Math + Merge Sorted List
    // Time: O(n) | TLE
    // Space: O(1)
    public int NthUglyNumber(int n, int a, int b, int c)
    {
        var ugly = new int[n];
        int producta = a, productb = b, productc = c;
        int pa = 0, pb = 0, pc = 0;
        int p = 0;
        while (p < n)
        {
            // find the min head and add to the merged list
            int min = Math.Min(Math.Min(producta, productb), productc);
            ugly[p] = min;
            p++;
            // update each source list
            if (min == producta)
            {
                producta += a;
                pa++;
            }
            if (min == productb)
            {
                productb += b;
                pb++;
            }
            if (min == productc)
            {
                productc += c;
                pc++;
            }
        }

        return ugly[n - 1];
    }

    // Math + Binary Search
    // Time: O(log n)
    // Space: O(1)
    public int NthUglyNumber1(int n, int a, int b, int c)
    {
        int left = 1, right = (int)2e9;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            var midVal = F(mid, a, b, c);
            if (midVal < n)
                left = mid + 1;
            else if (midVal > n)
                right = mid - 1;
            else
                right = mid - 1;
        }

        return left;
    }

    // calculate how many nums in [1, num] can be divisible by a, b, or c
    public long F(int num, int a, int b, int c)
    {
        long setA = num / a;
        long setB = num / b;
        long setC = num / c;
        long setAB = num / LCM(a, b);
        long setBC = num / LCM(b, c);
        long setAC = num / LCM(a, c);
        long setABC = num / LCM(LCM(a, b), c);
        return setA + setB + setC - setAB - setAC - setBC + setABC;
    }

    // least common multiple
    public long LCM(long a, long b)
    {
        return a * b / GCD(a, b);
    }

    // greatest common divisor
    public long GCD(long a, long b)
    {
        if (a < b)
            return GCD(b, a);
        if (b == 0)
            return a;

        return GCD(b, a % b);
    }
}

var sln = new Solution();
var result = sln.NthUglyNumber(5, 2, 11, 13);
Console.WriteLine(result);

Console.WriteLine(sln.GCD(2, 3));