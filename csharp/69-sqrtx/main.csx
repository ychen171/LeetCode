public class Solution
{
    public int Search(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (nums[mid] < target)
                left = mid + 1;
            else
                right = mid;
        }

        if (nums[left] == target) return left;
        return -1;
    }

    public int MySqrt(int x)
    {
        if (x < 2) return x;
        int left = 2;
        int right = x / 2;
        while (left < right)
        {
            var mid = left + (right - left) / 2 + 1;
            long num = (long)mid * mid;
            if (num > x)
                right = mid - 1;
            else
                left = mid;
        }

        return left;
    }
    // public int MySqrt(int x)
    // {
    //     if (x < 2) return x;
    //     int left = 2;
    //     int right = x / 2;
    //     long num;
    //     while (left <= right)
    //     {
    //         var mid = left + (right - left) / 2;
    //         num = (long)mid * (long)mid;
    //         if (num > x)
    //             right = mid - 1;
    //         else if (num < x)
    //             left = mid + 1;
    //         else 
    //             return mid;
    //     }

    //     return right;
    // }

    public int MySqrtNewton(int x)
    {
        long r = x;
        while (r * r > x)
            r = (r + x / r) / 2;

        return (int)r;
    }
}


var s = new Solution();
Console.WriteLine(s.MySqrt(4));
Console.WriteLine(s.MySqrt(8));
Console.WriteLine(s.MySqrt(15));
Console.WriteLine(s.MySqrt(16));
Console.WriteLine(s.MySqrt(2147395599));

Console.WriteLine(s.MySqrtNewton(4));
Console.WriteLine(s.MySqrtNewton(8));
Console.WriteLine(s.MySqrtNewton(15));
Console.WriteLine(s.MySqrtNewton(16));
Console.WriteLine(s.MySqrtNewton(2147395599));


