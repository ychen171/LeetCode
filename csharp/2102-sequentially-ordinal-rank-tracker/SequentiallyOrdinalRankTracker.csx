public class SORTracker
{
    // Space: O(n)
    PriorityQueue<KeyValuePair<string, int>, KeyValuePair<string, int>> pq;
    RankComparer comparer;
    int count;
    public SORTracker()
    {
        comparer = new RankComparer();
        pq = new PriorityQueue<KeyValuePair<string, int>, KeyValuePair<string, int>>(comparer);
        count = 0;
    }

    // Time: O(1)
    public void Add(string name, int score)
    {
        var pair = new KeyValuePair<string, int>(name, score);
        pq.Enqueue(pair, pair);
    }

    // Time: O(n log n)
    public string Get()
    {
        count++;
        int k = 0;
        KeyValuePair<string, int> curr = pq.Peek();
        var newPQ = new PriorityQueue<KeyValuePair<string, int>, KeyValuePair<string, int>>(comparer);
        while (pq.Count != 0)
        {
            curr = pq.Dequeue();
            newPQ.Enqueue(curr, curr);
            k++;
            if (k >= count)
                break;
        }

        while (pq.Count != 0)
        {
            newPQ.Enqueue(pq.Peek(), pq.Peek());
            pq.Dequeue();
        }
        pq = newPQ;
        Console.WriteLine(curr.Key);
        return curr.Key;
    }
}

public class RankComparer : IComparer<KeyValuePair<string, int>>
{
    // [name, score]
    public int Compare(KeyValuePair<string, int> a, KeyValuePair<string, int> b)
    {
        if (a.Value == b.Value)
        {
            var res = string.Compare(a.Key, b.Key);
            if (res < 0)
                return -1;
            else if (res > 0)
                return 1;
            else
                return 0;
        }
        else if (a.Value < b.Value)
            return 1;
        else
            return -1;
    }
}

/**
 * Your SORTracker object will be instantiated and called as such:
 * SORTracker obj = new SORTracker();
 * obj.Add(name,score);
 * string param_2 = obj.Get();
 */

var obj = new SORTracker();
obj.Add("bradford", 2);
obj.Add("branford", 3);
obj.Get();
obj.Add("alps", 2);
obj.Get();
obj.Add("orland", 2);
obj.Get();
obj.Add("orlando", 3);
obj.Get();
obj.Add("alpine", 2);
obj.Get();
obj.Get();