public class Solution
{
    // Brute force
    // Time: O(m * n)
    // Space: O(1)
    public int[] AnagramMappings(int[] nums1, int[] nums2)
    {
        int[] ans = new int[nums1.Length];
        for (int i = 0; i < nums1.Length; i++)
        {
            int a = nums1[i];
            for (int j = 0; j < nums2.Length; j++)
            {
                if (a == nums2[j])
                {
                    ans[i] = j;
                }
            }
        }

        return ans;
    }

    // Dictionary
    // Time: O(m + n)
    // Space: O(n)
    public int[] AnagramMappings1(int[] nums1, int[] nums2)
    {
        var numIndexDict = new Dictionary<int, int>();
        for (int i = 0; i < nums2.Length; i++)
            numIndexDict[nums2[i]] = i;
        
        int[] ans = new int[nums1.Length];
        for (int i = 0; i < nums1.Length; i++)
        {
            int a = nums1[i];
            ans[i] = numIndexDict[a];
        }

        return ans;
    }
}
