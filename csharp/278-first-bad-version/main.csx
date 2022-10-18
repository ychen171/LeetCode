
/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl
{
    public int FirstBadVersion(int n)
    {
        int left = 1;
        int right = n;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            var isBad = IsBadVersion(mid);
            if (isBad)
                right = mid - 1;
            else
                left = mid + 1;
        }

        return left;
    }
}
