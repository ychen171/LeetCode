public class Solution
{
    public int MinDays(int[] bloomDay, int m, int k)
    {
        /*
            Binary Search on [1, maxDay]
            for any given day, check if we can make m bouquets with k adjacent flowers
            find the min day
        */
        int n = bloomDay.Length;
        int maxDay = bloomDay.Max();
        int left = 1, right = maxDay;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (CanMake(bloomDay, m, k, mid))
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }
        if (!CanMake(bloomDay, m, k, left))
            return -1;
        return left;
    }

    private bool CanMake(int[] bloomDay, int m, int k, int waitDay)
    {
        int n = bloomDay.Length;
        var remainDay = new int[n];
        for (int i = 0; i < n; i++)
            remainDay[i] = Math.Max(0, bloomDay[i] - waitDay);

        int mCount = 0, kCount = 0;
        for (int i = 0; i < n; i++)
        {
            if (remainDay[i] == 0)
                kCount++;
            else
                kCount = 0;
            if (kCount == k)
            {
                mCount++;
                kCount = 0;
                if (mCount == m)
                    return true;
            }
        }
        return false;
    }
}

var sln = new Solution();
/*
[1000000000,1000000000]
1
1
*/
var bloomDay = new int[] { 1000000000, 1000000000 };
var m = 1;
var k = 1;
var result = sln.MinDays(bloomDay, m, k);
Console.WriteLine(result);
