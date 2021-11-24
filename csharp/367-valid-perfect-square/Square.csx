
public class Solution
{
    public bool IsPerfectSquare(int num)
    {
        if (num < 2) return true;
        int left = 2;
        int right = num / 2;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            long square = (long)mid * mid;
            if (square == num) return true;
            else if (square > num) right = mid - 1;
            else left = mid + 1;
        }
        return false;
    }

    public bool IsPerfectSquare2(int num)
    {
        if (num < 2) return true;
        int left = 2;
        int right = num / 2;
        while (left < right)
        {
            var mid = left + (right - left) / 2 + 1;
            long square = (long)mid * mid;
            if (square == num) return true;
            else if (square > num) right = mid - 1;
            else left = mid;
        }
        if (left * left == num) return true;
        return false;
    }

    public bool IsPerfectSquareNewton(int num)
    {
        if (num < 2) return true;
        long r = num / 2;
        while (r * r > num)
            r = (r + num / r) / 2;
        
        return r * r == num;
    }
}

var s = new Solution();
Console.WriteLine(s.IsPerfectSquare(4));
Console.WriteLine(s.IsPerfectSquare(5));
Console.WriteLine(s.IsPerfectSquare(6));
Console.WriteLine(s.IsPerfectSquare(7));
Console.WriteLine(s.IsPerfectSquare(8));
Console.WriteLine(s.IsPerfectSquare(9));

Console.WriteLine(s.IsPerfectSquareNewton(4));
Console.WriteLine(s.IsPerfectSquareNewton(5));
Console.WriteLine(s.IsPerfectSquareNewton(6));
Console.WriteLine(s.IsPerfectSquareNewton(7));
Console.WriteLine(s.IsPerfectSquareNewton(8));
Console.WriteLine(s.IsPerfectSquareNewton(9));
