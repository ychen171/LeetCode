public class Solution
{
    // 1. Dictionary or HashSet
    // Time: O(n)
    // Space: O(n)
    public int FindDuplicate1(int[] nums)
    {
        var dict = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (dict.ContainsKey(nums[i]))
                return nums[i];
            dict[nums[i]] = i;
        }

        return -1;
    }

    // 2. sort + linear search
    // Time: O(n log(n))
    // Space: O(log(n)) or O(n)
    public int FindDuplicate2(int[] nums)
    {
        var list = nums.ToList();
        list.Sort();
        for (int i = 1; i < list.Count; i++)
        {
            if (list[i] == list[i - 1])
                return list[i];
        }

        return -1;
    }

    // 3. Negative Marking
    // Time: O(n)
    // Space: O(1)
    public int FindDuplicate3(int[] nums)
    {
        var dup = -1;
        for (int i = 0; i < nums.Length; i++)
        {
            var curr = Math.Abs(nums[i]);
            if (nums[curr] < 0)
            {
                dup = curr;
                break;
            }
            nums[i] *= -1;
        }

        // restore nums
        for (int i = 0; i < nums.Length; i++)
            nums[i] = Math.Abs(nums[i]);

        return dup;
    }

    // 4.1 Array as HashMap (Recursive)
    public int FindDuplicate4Recursive(int[] nums)
    {
        return Store(nums, 0);
    }
    public int Store(int[] nums, int curr)
    {
        if (curr == nums[curr])
            return curr;
        int next = nums[curr];
        nums[curr] = curr;
        return Store(nums, next);
    }
    // 4.2 Array as HashMap (Iterative)
    // Time: O(n)
    // Space: O(1)
    public int FindDuplicate4Iterative(int[] nums)
    {
        int curr = 0;
        while (curr != nums[curr])
        {
            int next = nums[curr];
            nums[curr] = curr;
            curr = next;
        }

        return curr;
    }

    // 5. Binary Search   (Pigeonhole principle)
    // Time: O(n log(n))
    // Space: O(1)
    public int FindDuplicate5(int[] nums)
    {
        // Though the values are not ordered, the indices are still ordered. 
        int left = 1;
        int right = nums.Length - 1;

        while (left < right)
        {
            var mid = left + (right - left) / 2;
            int count = 0;
            foreach (var num in nums)
            {
                if (num <= mid)
                    count++;
            }
            if (count <= mid)
            {
                left = mid + 1;
            }
            else
                right = mid;
        }

        return left;
    }

    // 6. Sum of Set Bits
    // Time: O(n log(n))
    // Space: O(1)

    // 7. Floyd's Tortoise and Hare (Cycle Detection)
    // Time: O(n)
    // Space: O(1)
    public int FindDuplicate7(int[] nums)
    {
        // find the intersection of the two runners
        int tortoise = nums[0];
        int hare = nums[0];

        do
        {
            tortoise = nums[tortoise];
            hare = nums[nums[hare]];
        } while (tortoise != hare);

        // find the "entrance" to the cycle
        tortoise = nums[0];
        while (tortoise != hare)
        {
            tortoise = nums[tortoise];
            hare = nums[hare];
        }

        return hare;
    }
}


var s = new Solution();
Console.WriteLine(s.FindDuplicate4Iterative(new int[] { 3, 3, 5, 4, 1, 3 }));
Console.WriteLine();

Console.WriteLine(s.FindDuplicate5(new int[] { 3, 3, 5, 4, 1, 3 }));
Console.WriteLine(s.FindDuplicate5(new int[] { 1, 1 }));
Console.WriteLine(s.FindDuplicate5(new int[] { 3, 3, 3, 5, 4, 1 }));
Console.WriteLine();

Console.WriteLine(s.FindDuplicate7(new int[] { 3, 3, 5, 4, 1, 3 }));
Console.WriteLine(s.FindDuplicate7(new int[] { 1, 1 }));
Console.WriteLine(s.FindDuplicate7(new int[] { 3, 3, 3, 5, 4, 1 }));
Console.WriteLine();



















