public class Solution
{
    // Greedy | Sorting + Dictionary
    // Time: O(n log n)
    // Space: O(n)
    public int[] FindOriginalArray(int[] changed)
    {
        /*
            1   2   3   4   6   8

            1   2   2   2   4   4
        */
        int n = changed.Length;
        if (n % 2 != 0)
            return new int[0];

        Array.Sort(changed);
        var valToIndex = new Dictionary<int, Queue<int>>();
        var result = new List<int>();
        for (int i = 0; i < n; i++)
        {
            var num = changed[i];
            if (num % 2 == 0)
            {
                var target = num / 2;
                if (valToIndex.ContainsKey(target))
                {
                    result.Add(target);
                    valToIndex[target].Dequeue();
                    if (valToIndex[target].Count == 0)
                        valToIndex.Remove(target);
                    continue;
                }
            }
            if (!valToIndex.ContainsKey(num))
                valToIndex[num] = new Queue<int>();
            valToIndex[num].Enqueue(i);
        }

        return result.Count == n / 2 ? result.ToArray() : new int[0];
    }
}

var sln = new Solution();
// var changed = new int[] { 1, 3, 4, 2, 6, 8 };
var changed = new int[] { 1, 2, 2, 2, 4, 4 };
var result = sln.FindOriginalArray(changed);
Console.WriteLine(result);
