public class Solution
{
    // Dictionary + Priority Queue
    // Time: O(n log k)
    // Time: O(n)
    public IList<string> TopKFrequent(string[] words, int k)
    {
        // min heap: frequency in ascending order, string in descending order
        var pq = new PriorityQueue<KeyValuePair<string, int>, KeyValuePair<string, int>>(Comparer<KeyValuePair<string, int>>.Create((a, b) =>
        {
            if (a.Value == b.Value)
            {
                return string.Compare(b.Key, a.Key);
            }
            return a.Value - b.Value;
        }));

        var wordCount = new Dictionary<string, int>();
        foreach (var word in words)
            wordCount[word] = wordCount.GetValueOrDefault(word, 0) + 1;

        foreach (var kv in wordCount)
        {
            pq.Enqueue(kv, kv);
            // keep the size of pq <= k, pop the top k+1 th element
            if (pq.Count > k)
                pq.Dequeue();
        }
        var result = new string[k];
        for (int i = k - 1; i >= 0; i--)
        {
            result[i] = pq.Dequeue().Key;
        }
        return result;
    }
}

var sln = new Solution();
var words = new string[] { "i", "love", "leetcode", "i", "love", "coding" };
var result = sln.TopKFrequent(words, 2);
Console.WriteLine(result);
