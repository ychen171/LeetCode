public class Solution
{
    // HashSet
    // Time(log n)
    // Space: O(log n)
    public bool IsHappy(int n)
    {
        var set = new HashSet<int>();
        int sum = n;
        while (sum != 1)
        {
            sum = Sum(sum);
            if (set.Add(sum))
                continue;
            else
                return false;

        }

        return true;
    }

    private int Sum(int n)
    {
        int ans = 0;
        while (n != 0)
        {
            int digit = n % 10;
            ans += digit * digit;
            n /= 10;
        }

        return ans;
    }

    // Cycle Detection
    // Time: O(log n)
    // Space: O(1)
    public bool IsHappy1(int n)
    {
        int slow = n;
        int fast = Sum(n);
        while (fast != 1 && fast != slow)
        {
            slow = Sum(slow);
            fast = Sum(Sum(fast));
        }

        return fast == 1;
    }
}
