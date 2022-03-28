public class Solution
{
    // Brute force
    // Time: O(n^2)
    // Space: O(1)
    public int RemoveElement(int[] nums, int val)
    {
        int k = nums.Length;
        int i = 0;
        while (i < k)
        {
            if (nums[i] == val)
            {
                Console.WriteLine($"i:{i}, nums[{i}]:{nums[i]}, k:{k}");
                RemoveAt(nums, i, k);
                k--;
            }
            else
                i++;
        }

        return k;
    }

    public void RemoveAt(int[] nums, int index, int k)
    {
        if (index >= k) return;
        for (int i = index + 1; i < k; i++)
        {
            nums[i - 1] = nums[i];
        }
    }

    // Two Pointers | Considuer the element to be removed as non-existent
    // Time: O(n)
    // Space: O(1)
    public int RemoveElement1(int[] nums, int val)
    {
        int l = 0;
        int r = 0;
        for (r = 0; r < nums.Length; r++)
        {
            if (nums[r] == val) continue;
            nums[l] = nums[r];
            l++;
        }

        return l;
    }

    // Two Pointers - when elements to remove are rare | Swap
    // Time: O(n)
    // Space: O(1)
    public int RemoveElement2(int[] nums, int val)
    {
        int i = 0;
        int n = nums.Length;
        while (i < n)
        {
            if (nums[i] == val)
            {
                nums[i] = nums[n-1];
                n--;
            }
            else
            {
                i++;
            }
        }

        return n;
    }
}

