public class Solution
{
    // Greedy + Sorting + Priority Queue
    // Time: O(n log n)
    // Space: O(n)
    public int[] AdvantageCount(int[] nums1, int[] nums2)
    {
        /*
            12,24,8,32      13,25,32,11
            
            nums1   32,24,12,8
            nums2   32,25,13,11

                    8,32,24,12
        */
        int n = nums1.Length;
        var ans = new int[n];
        var pq = new PriorityQueue<int[], int>(); // max heap <[index, val], -val>
        for (int i = 0; i < n; i++)
        {
            pq.Enqueue(new int[] { i, nums2[i] }, -nums2[i]);
        }

        int left = 0, right = n - 1;
        Array.Sort(nums1);
        // nums1[left] smallest  nums1[right] largest
        while (pq.Count != 0)
        {
            var item = pq.Dequeue();
            int index = item[0];
            int num = item[1];
            if (nums1[right] > num)
            {
                ans[index] = nums1[right];
                right--;
            }
            else
            {
                ans[index] = nums1[left];
                left++;
            }
        }

        return ans;
    }

    // Greedy + Sorting + Binary Search
    // Time: O(n log n)
    // Space: O(n)
    public int[] AdvantageCount1(int[] nums1, int[] nums2)
    {
        int n = nums1.Length;
        var ans = new int[n];
        // sort 
        Array.Sort(nums1);
        var list1 = nums1.ToList();
        // binary search left bound
        for (int i = 0; i < n; i++)
        {
            int num = nums2[i];
            int target = num + 1;
            int index = BinarySearchLeftBound(list1, target);
            if (index != -1)
            {
                ans[i] = list1[index];
                list1.RemoveAt(index);
            }
            else
            {
                ans[i] = list1[0];
                list1.RemoveAt(0);
            }
        }

        return ans;
    }

    public int BinarySearchLeftBound(List<int> nums, int target)
    {
        int n = nums.Count;
        int left = 0;
        int right = n - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] < target)
                left = mid + 1;
            else if (nums[mid] > target)
                right = mid - 1;
            else
                right = mid - 1;
        }
        if (left == n) return -1;
        return left;
    }
}
