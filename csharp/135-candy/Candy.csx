public class Solution
{
    // Brute force
    // Time: O(n^2)
    // Space: O(n)
    public int Candy(int[] ratings)
    {
        // 1 0 2
        // 1 1 1
        // 2 1 1
        // 2 1 2

        // 1 3 2 2 1
        // 1 1 1 1 1
        // 1 2 1 1 1
        // 1 2 1 1 1
        // 1 2 1 1 1
        // 1 2 1 2 1

        int n = ratings.Length;
        if (n == 1)
            return 1;

        var candies = new int[n];
        for (int i = 0; i < n; i++)
            candies[i] = 1;
        bool hasChanged = true;

        while (hasChanged)
        {
            hasChanged = false;
            for (int i = 0; i < n; i++)
            {
                if (i != n - 1 && ratings[i] > ratings[i + 1] && candies[i] <= candies[i + 1])
                {
                    candies[i] = candies[i + 1] + 1;
                    hasChanged = true;
                }
                if (i != 0 && ratings[i] > ratings[i - 1] && candies[i] <= candies[i - 1])
                {
                    candies[i] = candies[i - 1] + 1;
                    hasChanged = true;
                }
            }
        }

        return candies.Sum();
    }

    // Two Arrays + Two Passes
    // Time: O(n)
    // Space: O(n)
    public int Candy1(int[] ratings)
    {
        int n = ratings.Length;
        if (n == 1)
            return 1;

        var leftToRight = new int[n];
        Array.Fill(leftToRight, 1);
        var rightToLeft = new int[n];
        Array.Fill(rightToLeft, 1);

        // traverse from left to right
        for (int i = 1; i < n; i++)
        {
            if (ratings[i] > ratings[i - 1])
                leftToRight[i] = leftToRight[i - 1] + 1;
        }

        // traverse from right to left
        for (int i = n - 2; i >= 0; i--)
        {
            if (ratings[i] > ratings[i + 1])
                rightToLeft[i] = rightToLeft[i + 1] + 1;
        }

        // merge two arrays by picking the larger number
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            ans += Math.Max(leftToRight[i], rightToLeft[i]);
        }

        return ans;
    }

    // One Array + Two Passes
    // Time: O(n)
    // Space: O(n)
    public int Candy2(int[] ratings)
    {
        int n = ratings.Length;
        if (n == 1)
            return 1;

        var candies = new int[n];
        Array.Fill(candies, 1);
        for (int i = 1; i < n; i++)
        {
            if (ratings[i] > ratings[i - 1])
                candies[i] = candies[i - 1] + 1;
        }

        for (int i = n - 2; i >= 0; i--)
        {
            if (ratings[i] > ratings[i + 1])
                candies[i] = Math.Max(candies[i], candies[i + 1] + 1);
        }

        return candies.Sum();
    }

    // One Pas with Constant Space
    // Time: O(n)
    // Space: O(1)
    public int Candy3(int[] ratings)
    {
        int n = ratings.Length;
        if (n <= 1)
            return n;

        int candies = 0;
        int up = 0;
        int down = 0;
        int oldSlope = 0;
        for (int i = 1; i < n; i++)
        {
            int newSlope = 0;
            if (ratings[i] > ratings[i - 1])
                newSlope = 1;
            else if (ratings[i] < ratings[i - 1])
                newSlope = -1;
            else
                newSlope = 0;

            if ((oldSlope > 0 && newSlope == 0) || (oldSlope < 0 && newSlope >= 0))
            {
                candies += Count(up) + Count(down) + Math.Max(up, down);
                up = 0;
                down = 0;
            }

            if (newSlope > 0)
                up++;
            else if (newSlope < 0)
                down++;
            else
                candies++;

            oldSlope = newSlope;
        }

        candies += Count(up) + Count(down) + Math.Max(up, down) + 1;
        return candies;
    }

    private int Count(int n)
    {
        return n * (n + 1) / 2;
    }
}
