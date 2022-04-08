public class Solution
{
    // Time: O(n log (ribbons.Max()))
    // n = ribbons.Length
    // Space: O(1)
    public int MaxLength(int[] ribbons, int k)
    {
        // binary search on the range of answer
        // n = ribbons.Length, n = [0, ribbons.Max()]

        // [9, 7, 5], k = 3
        // mid = lf + (rt - lf + 1) / 2
        // answer is in [0, 9], find maximum / rightmost
        // lf = 0, rt = 9, mid = 5, the number of ribbons = 1 + 1 + 1 = 3
        // lf = 5, rt = 9, mid = 7, the number of ribbons = 1 + 1 + 0 = 2


        int lf = 0;
        int rt = ribbons.Max();

        while (lf < rt)
        {
            int mid = lf + (rt - lf + 1) / 2;
            if (HasRibbons(ribbons, mid, k))
            {
                lf = mid;
            }
            else
            {
                rt = mid - 1;
            }
        }

        return lf;
    }

    private bool HasRibbons(int[] ribbons, int len, int k)
    {
        int count = 0;
        foreach (int ribbon in ribbons)
        {
            count += ribbon / len;
            if (count >= k)
                return true;
        }

        return false;
    }
}
