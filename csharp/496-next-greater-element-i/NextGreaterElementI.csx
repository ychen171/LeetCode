public class Solution
{
    // Stack | Mono decrease
    // Time: O(m+n)
    // Space: O(n)
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        // nums1 = [4,1,2], nums2 = [1,3,4,2]
        // 1            [4, 1, 2]       [-1, -1, -1]
        // 1, 3         [4, 1, 2]       [-1, 3, -1]
        // 3
        // 3, 4         [4, 1, 2]       [-1, 3, -1]
        // 4
        // 4, 2         [4, 1, 2]       [-1, 3, -1]

        int n1 = nums1.Length;
        int n2 = nums2.Length;
        int[] ans = new int[n1];
        for (int i = 0; i < n1; i++)
            ans[i] = -1;
        var stack = new Stack<int>();
        stack.Push(nums2[0]);
        for (int j = 1; j < n2; j++)
        {
            var num2 = nums2[j];
            while (stack.Count != 0 && stack.Peek() < num2)
            {
                var top = stack.Pop();
                for (int i = 0; i < n1; i++)
                {
                    if (ans[i] != -1)
                        continue;
                    if (nums1[i] == top)
                        ans[i] = num2;
                }
            }
            stack.Push(num2);
        }

        return ans;
    }

    // Stack + Dictioanry
    // Time: O(m+n)
    // Space: O(m+n)
    public int[] NextGreaterElement1(int[] nums1, int[] nums2)
    {
        int m = nums1.Length;
        int n = nums2.Length;
        var greater = NextGreaterElement(nums2);
        var greaterDict = new Dictionary<int, int>();
        for (int i = 0; i < n; i++)
            greaterDict[nums2[i]] = greater[i];

        var result = new int[m];
        for (int i = 0; i < m; i++)
            result[i] = greaterDict[nums1[i]];

        return result;
    }

    public int[] NextGreaterElement(int[] nums)
    {
        int n = nums.Length;
        var result = new int[n];
        var stack = new Stack<int>();
        for (int i = n - 1; i >= 0; i--)
        {
            while (stack.Count != 0 && stack.Peek() <= nums[i])
                stack.Pop();
            result[i] = stack.Count == 0 ? -1 : stack.Peek();
            stack.Push(nums[i]);
        }

        return result;
    }
}