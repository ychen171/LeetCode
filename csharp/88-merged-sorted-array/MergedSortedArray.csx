public class Solution
{
    // Brute force
    // Time: O(m + n)
    // Space: O(m + n)
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int i = 0;
        int j = 0;
        var result = new List<int>();

        while (i < m && j < n)
        {
            if (nums1[i] < nums2[j])
                result.Add(nums1[i++]);
            else
                result.Add(nums2[j++]);
        }

        while (i < m)
        {
            result.Add(nums1[i++]);
        }
        
        while (j < n)
        {
            result.Add(nums2[j++]);
        }

        for (int k = 0; k < m + n; k++)
            nums1[k] = result[k];
    }

    // Three pointers 
    // Time: O(m + n)
    // Space: O(1)
    public void Merge1(int[] nums1, int m, int[] nums2, int n)
    {
        int i = m - 1;
        int j = n - 1;
        for (int k = m + n - 1; k >= 0; k--)
        {
            if (j < 0)
                break;
            if (i >= 0 && nums1[i] > nums2[j])
                nums1[k] = nums1[i--];
            else
                nums1[k] = nums2[j--];
        }
    }
}
