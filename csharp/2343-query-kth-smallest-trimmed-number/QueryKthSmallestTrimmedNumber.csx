public class Solution
{
    // Simulation + Priority Queue
    // Time: O(m * n log n)
    // Space: O(n)
    public int[] SmallestTrimmedNumbers(string[] nums, int[][] queries)
    {
        var n = nums.Length;
        var m = queries.Length;
        var ans = new int[m];
        for (int j = 0; j < m; j++)
        {
            var query = queries[j];
            int k = query[0];
            int trim = query[1];
            var pq = new PriorityQueue<Tuple<int, string>, Tuple<int, string>>(Comparer<Tuple<int, string>>.Create((a, b) =>
            {
                if (a.Item2 == b.Item2)
                {
                    if (a.Item1 < b.Item1)
                        return 1;
                    else if (a.Item1 > b.Item1)
                        return -1;
                    else
                        return 0;
                }
                return string.Compare(b.Item2, a.Item2);
            })); // max heap
            for (int i = 0; i < n; i++)
            {
                string str = nums[i];
                var sb = new StringBuilder();
                for (int p = str.Length - trim; p < str.Length; p++)
                {
                    sb.Append(str[p]);
                }
                var trimmed = sb.ToString();
                var pair = new Tuple<int, string>(i, trimmed);
                if (pq.Count < k)
                {
                    pq.Enqueue(pair, pair);
                }
                else
                {
                    if (string.Compare(trimmed, pq.Peek().Item2) < 0)
                    {
                        pq.Dequeue();
                        pq.Enqueue(pair, pair);
                    }
                }
            }
            ans[j] = pq.Peek().Item1;
        }

        return ans;
    }

    // Simulation + Sorting
    // Time: O(m * n log n)
    // Space: O(n)
    public int[] SmallestTrimmedNumbers1(string[] nums, int[][] queries)
    {
        int n = nums.Length;
        int m = queries.Length;
        var ans = new int[m];
        for (int j = 0; j < m; j++)
        {
            var query = queries[j];
            int k = query[0];
            int trim = query[1];

            var list = new List<Tuple<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string str = nums[i];
                var sb = new StringBuilder();
                for (int p = str.Length - trim; p < str.Length; p++)
                {
                    sb.Append(str[p]);
                }
                var trimmed = sb.ToString();
                list.Add(new Tuple<string, int>(trimmed, i));
            }
            // sorting by str then index
            list.Sort((a, b) =>
            {
                if (a.Item1 == b.Item1)
                    return a.Item2 - b.Item2;
                return string.Compare(a.Item1, b.Item1);
            });
            ans[j] = list[k - 1].Item2;
        }

        return ans;
    }
}


var sln = new Solution();
// var nums = new string[] { "102", "473", "251", "814" };
// var queries = new int[][] { new int[] { 1, 1 }, new int[] { 2, 3 }, new int[] { 4, 2 }, new int[] { 1, 2 } };

var nums = new string[] { "24", "37", "96", "04" };
var queries = new int[][] { new int[] { 2, 1 }, new int[] { 2, 2 } };
var result = sln.SmallestTrimmedNumbers(nums, queries);

