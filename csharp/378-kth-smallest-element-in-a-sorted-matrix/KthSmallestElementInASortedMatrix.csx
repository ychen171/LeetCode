public class Solution
{
    // Priority Queue | Max Heap
    // Time: O(n^2 * log k)
    // Space: O(k)
    public int KthSmallest(int[][] matrix, int k)
    {
        /*
            1   5   9
            10  11  13
            12  13  15

            k = 8

        */

        int n = matrix.Length;
        var pq = new PriorityQueue<int, int>(); // max heap
        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                int num = matrix[r][c];
                pq.Enqueue(num, -num);
                if (pq.Count > k)
                    pq.Dequeue();
            }
        }

        return pq.Peek();
    }

    // Priority Queue | Merge Sorted Lists | Min Heap
    // Time: O(k log n)
    // Space: O(n)
    public int KthSmallest1(int[][] matrix, int k)
    {
        int n = matrix.Length;
        var pq = new PriorityQueue<int[], int>(); // min heap
        // add the head of each sorted list to min heap
        int[] item = null;
        for (int r = 0; r < n; r++)
        {
            int head = matrix[r][0];
            item = new int[] { head, r, 0 };
            pq.Enqueue(item, head);
        }

        // start merging
        while (pq.Count != 0)
        {
            item = pq.Dequeue();
            int num = item[0];
            int r = item[1];
            int c = item[2];
            k--;
            if (k == 0)
                break;

            if (c == n - 1) // last column
                continue;
            item = new int[] { matrix[r][c + 1], r, c + 1 };
            pq.Enqueue(item, matrix[r][c + 1]);
        }

        return item == null ? 0 : item[0];
    }

    // Binary Search
    // Time: O(n log n)
    // Space: O(1)
    public int KthSmallest2(int[][] matrix, int k)
    {
        int n = matrix.Length;
        int start = matrix[0][0];
        int end = matrix[n - 1][n - 1];
        while (start < end)
        {
            int mid = start + (end - start) / 2;
            // the first number is the smallest and the second number is the largest
            var smallLargePair = new int[] { matrix[0][0], matrix[n - 1][n - 1] };

            int count = CountLessEqual(matrix, mid, smallLargePair);

            if (count == k)
                return smallLargePair[0];
            else if (count < k)
                start = smallLargePair[1]; // to increase mid
            else // count > k
                end = smallLargePair[0]; // to descrease mid
        }

        return start;
    }

    private int CountLessEqual(int[][] matrix, int mid, int[] smallLargePair)
    {
        int n = matrix.Length;
        int count = 0;
        int row = n - 1;
        int col = 0;
        while (row >= 0 && col < n) // valid
        {
            int num = matrix[row][col];
            if (num > mid)
            {
                smallLargePair[1] = Math.Min(smallLargePair[1], num);
                // count += col + 1;
                row--;
            }
            else // num <= mid
            {
                smallLargePair[0] = Math.Max(smallLargePair[0], num);
                count += row + 1;
                col++;
            }
        }

        return count;
    }

    // Quickselect
    // Time: O(n^2 * log n)
    // Space: O(n^2)
    public int KthSmallest3(int[][] matrix, int k)
    {
        int n = matrix.Length;
        int size = n * n;
        var nums = new int[size];
        int index = 0;
        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                nums[index] = matrix[r][c];
                index++;
            }
        }

        int lo = 0, hi = size - 1;
        k = k - 1;
        while (lo <= hi)
        {
            int pivotIndex = Partition(nums, lo, hi);
            if (pivotIndex < k)
                lo = pivotIndex + 1;
            else if (pivotIndex > k)
                hi = pivotIndex - 1;
            else
                return nums[pivotIndex];
        }

        return -1;
    }

    private void Shuffle(int[] nums)
    {
        int n = nums.Length;
        var rand = new Random();
        for (int i = 0; i < n; i++)
        {
            var r = rand.Next(i, n);
            Swap(nums, i, r);
        }
    }

    private void Swap(int[] nums, int left, int right)
    {
        var temp = nums[left];
        nums[left] = nums[right];
        nums[right] = temp;
    }

    private int Partition(int[] nums, int lo, int hi)
    {
        int pivot = nums[lo];
        // [lo, left-1] <= pivot && [right+1, hi] > pivot
        int left = lo + 1, right = hi;
        while (left <= right)
        {
            while (left < hi && nums[left] <= pivot)
                left++;
            while (right > lo && nums[right] > pivot)
                right--;
            if (left >= right)
                break;
            Swap(nums, left, right);
        }
        Swap(nums, lo, right);

        return right;
    }
}
