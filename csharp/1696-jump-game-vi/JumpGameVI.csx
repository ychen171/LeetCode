public class Solution
{
    // Doesn't work!!!
    // DP | Top-down | Recursion
    int globalMaxSum = int.MinValue;
    public int MaxResult(int[] nums, int k)
    {
        Helper(nums, k, 0, 0);
        return globalMaxSum;
    }

    public void Helper(int[] nums, int k, int index, int sum)
    {
        int n = nums.Length;
        // base case
        if (index == n - 1)
        {
            globalMaxSum = Math.Max(globalMaxSum, sum);
            return;
        }
        if (index >= n)
            return;

        // recursive case
        for (int i = index + 1; i <= Math.Min(n - 1, index + k); i++)
        {
            Helper(nums, k, i, sum + nums[i]);
        }
    }

    // DP + DeQueue (monotonic queue)
    // Time: O(n)
    // Spacee: O(n)
    public int MaxResult1(int[] nums, int k)
    {
        int n = nums.Length;
        var scores = new int[n];
        scores[0] = nums[0];
        var dq = new LinkedList<int>();
        dq.AddLast(0);
        for (int i = 1; i < n; i++)
        {
            // pop old index
            while (dq.Count != 0 && dq.First.Value < i - k)
            {
                dq.RemoveFirst();
            }
            scores[i] = scores[dq.First.Value] + nums[i];
            // pop teh smaller value
            while (dq.Count != 0 && scores[dq.Last.Value] < scores[i])
            {
                dq.RemoveLast();
            }
            dq.AddLast(i);
        }

        return scores[n - 1];
    }

    // DP + PriorityQueue
    // Time: O(n log n)
    // Space: O(n)
    public int MaxResult2(int[] nums, int k)
    {
        int n = nums.Length;
        var scores = new int[n];
        scores[0] = nums[0];
        var pq = new PriorityQueue<int[], int>(); // max heap   <[score, index], -score>
        pq.Enqueue(new int[] { nums[0], 0 }, -nums[0]);
        for (int i = 1; i < n; i++)
        {
            // pop old index
            while (pq.Count != 0 && pq.Peek()[1] < i - k)
            {
                pq.Dequeue();
            }
            scores[i] = pq.Peek()[0] + nums[i];
            pq.Enqueue(new int[] { scores[i], i }, -scores[i]);
        }

        return scores[n - 1];
    }
}

var s = new Solution();
var nums = new int[] { 1, -1, -2, 4, -7, 3 };
var k = 2;
var result = s.MaxResult(nums, k);
Console.WriteLine(result);
var result1 = s.MaxResult1(nums, k);
Console.WriteLine(result1);
