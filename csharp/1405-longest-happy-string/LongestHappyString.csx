public class Solution
{
    // Priority Queue + Dictionary
    // Time: O(n)
    // Space: O(1)
    public string LongestDiverseString(int a, int b, int c)
    {
        // greedy 
        // find the most char and append to result
        // use Priority Queue to keep the order of count
        // use Dictionary to keep track of remaining count
        var pq = new PriorityQueue<char, int>();
        var countDict = new Dictionary<char, int>();
        if (a > 0)
        {
            pq.Enqueue('a', -a);
            countDict['a'] = a;
        }
        if (b > 0)
        {
            pq.Enqueue('b', -b);
            countDict['b'] = b;
        }
        if (c > 0)
        {
            pq.Enqueue('c', -c);
            countDict['c'] = c;
        }
        var sb = new StringBuilder();
        char last = '*';

        while (pq.Count != 0)
        {
            if (pq.Peek() == last)  // the most char is the last char
            {
                var most = pq.Dequeue();
                // find the next char
                if (pq.Count == 0)
                    break;
                var curr = pq.Dequeue();
                // append 1 the next char and update countDict
                sb.Append(curr);
                countDict[curr]--;
                if (countDict[curr] == 0)
                    countDict.Remove(curr);
                    
                // push the most and next back to pq
                if (countDict.ContainsKey(curr))
                    pq.Enqueue(curr, -countDict[curr]);
                if (countDict.ContainsKey(most))
                    pq.Enqueue(most, -countDict[most]);
                // update last char
                last = curr;
            }
            else // the most char is not last char
            {
                var curr = pq.Dequeue();
                // append 2 the most char and update countDict
                for (int k = 0; k < 2; k++)
                {
                    if (countDict[curr] == 0)
                    {
                        countDict.Remove(curr);
                        break;
                    }
                    sb.Append(curr);
                    countDict[curr]--;
                }


                // push the most char back to pq
                if (countDict.ContainsKey(curr))
                    pq.Enqueue(curr, -countDict[curr]);
                // update last char
                last = curr;
            }
        }

        return sb.ToString();
    }
}
