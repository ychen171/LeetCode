public class Solution 
{
    // HashSet
    // Time: O(m + n)
    // Space: O(m + n)
    public int[] Intersection(int[] nums1, int[] nums2) 
    {
        var set1 = new HashSet<int>(nums1);       
        var commonSet = new HashSet<int>();
        foreach (var num2 in nums2)
        {
            if (set1.Contains(num2))
                commonSet.Add(num2);
        }
        
        return commonSet.ToArray();
    }
}
