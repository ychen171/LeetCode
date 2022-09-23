public class Solution
{
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
            var pq = new PriorityQueue<Tuple<int, long>, Tuple<int, long>>(Comparer<Tuple<int, long>>.Create((a, b) =>
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
                else if (a.Item2 < b.Item2)
                    return 1;
                else
                    return -1;
            })); // max heap
            for (int i = 0; i < n; i++)
            {
                string str = nums[i];
                long trimmedNum = 0;
                for (int p = str.Length - trim; p < str.Length; p++)
                {
                    trimmedNum = trimmedNum * 10 + str[p] - '0';
                }
                var pair = new Tuple<int, long>(i, trimmedNum);
                if (pq.Count < k)
                {
                    pq.Enqueue(pair, pair);
                }
                else
                {
                    if (pq.Peek().Item2 > trimmedNum)
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
}


var sln = new Solution();
// var nums = new string[] { "102", "473", "251", "814" };
// var queries = new int[][] { new int[] { 1, 1 }, new int[] { 2, 3 }, new int[] { 4, 2 }, new int[] { 1, 2 } };

var nums = new string[] { "24", "37", "96", "04" };
var queries = new int[][] { new int[] { 2, 1 }, new int[] { 2, 2 } };
var result = sln.SmallestTrimmedNumbers(nums, queries);

