public class Solution
{
    // Binary Search
    // Doesn't work on edge cases
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        // arrayA is longer, arrayB is shorter
        int[] arrayA;
        int[] arrayB;
        if (nums1.Length == nums2.Length)
        {
            if (nums1.Length != 0 && nums1[0] < nums2[0])
            {
                arrayA = nums1;
                arrayB = nums2;
            }
            else
            {
                arrayA = nums2;
                arrayB = nums1;
            }
        }
        else if (nums1.Length < nums2.Length)
        {
            arrayA = nums2;
            arrayB = nums1;
        }
        else
        {
            arrayA = nums1;
            arrayB = nums2;
        }
        int lenA = arrayA.Length;
        int lenB = arrayB.Length;
        // edge case
        if (lenA == 0 && lenB == 0) // both are empty
            return 0.0;
        else if (lenB == 0) // shorter one is empty
            return lenA % 2 == 0 ? (arrayA[(lenA - 1) / 2] + arrayA[lenA / 2]) / 2.0 : arrayA[(lenA - 1) / 2];
        else if (lenA == 1 && lenB == 1)
            return (arrayA[0] + arrayB[0]) / 2.0;

        int totalLen = lenA + lenB;
        int halfLen = totalLen % 2 == 0 ? totalLen / 2 : (totalLen + 1) / 2;

        // binary search on the longer array (arrayA)
        int l = 0;
        int r = lenA - 1;
        while (l <= r)
        {
            int i = l + (r - l) / 2; // the mid index for arrayA
            int j = halfLen - (i + 1) - 1; // the mid index of arrayB

            // leftA is the right most value of left partition in arrayA
            double leftA = i >= 0 && i < lenA ? arrayA[i] : double.MinValue;
            // rightA is the left most value of right partition in arrayA
            double rightA = i + 1 >= 0 && i + 1 < lenA ? arrayA[i + 1] : double.MaxValue;
            // leftB is the right most value of left partition in arrayB
            double leftB = j < 0 ? arrayB[0] : j < lenB ? arrayB[j] : double.MinValue;
            // rightB is the left most value of right partition in arrayB
            double rightB = j + 1 >= 0 && j + 1 < lenB ? arrayB[j + 1] : double.MaxValue;

            // valid partition (all values in both left partitions <= all values in both right partitions)
            if (leftA <= rightB && leftB <= rightA)
            {
                if (totalLen % 2 == 0) // even
                {
                    return (Math.Max(leftA, leftB) + Math.Min(rightA, rightB)) / 2.0;
                }
                else // odd
                {
                    return Math.Max(leftA, leftB);
                }
            }
            else if (leftA > rightB)
            {
                r = i - 1;
            }
            else
            {
                l = i + 1;
            }
        }

        return -1;
    }
}

var s = new Solution();
var result = s.FindMedianSortedArrays(new int[] { 1 }, new int[] { 2, 3, 4, 5, 6 });
Console.WriteLine(result);