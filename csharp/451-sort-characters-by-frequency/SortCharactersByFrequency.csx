public class Solution
{
    public string FrequencySort(string s)
    {
        var charCountMap = new Dictionary<char, int>();
        foreach (var c in s)
        {
            charCountMap[c] = charCountMap.GetValueOrDefault(c, 0) + 1;
        }
        var pq = new PriorityQueue<KeyValuePair<char, int>, KeyValuePair<char, int>>(Comparer<KeyValuePair<char, int>>.Create((a, b) => b.Value - a.Value));
        foreach (var kv in charCountMap)
        {
            pq.Enqueue(kv, kv);
        }
        var sb = new StringBuilder();
        while (pq.Count != 0)
        {
            var kv = pq.Dequeue();
            char letter = kv.Key;
            int count = kv.Value;
            while (count > 0)
            {
                sb.Append(letter);
                count--;
            }
        }
        return sb.ToString();
    }
}
// Dictionary + PriorityQueue
// Time: O(n log n)
// Space: O(n)
