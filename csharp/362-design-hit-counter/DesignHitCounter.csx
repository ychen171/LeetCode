public class HitCounter
{
    Dictionary<int, int> counterDict;
    public HitCounter()
    {
        counterDict = new Dictionary<int, int>();
    }

    // Time: O(1)
    // Space: O(1)
    public void Hit(int timestamp)
    {
        counterDict[timestamp] = counterDict.GetValueOrDefault(timestamp, 0) + 1;
    }
    // Time: O(1)
    // Space: O(1)
    public int GetHits(int timestamp)
    {
        int total = 0;
        foreach (var pair in counterDict)
        {
            var currTime = pair.Key;
            var currCount = pair.Value;
            if (currTime + 300 <= timestamp)
                counterDict.Remove(currTime);
            else
                total += counterDict[currTime];
        }

        return total;
    }
}

/**
 * Your HitCounter object will be instantiated and called as such:
 * HitCounter obj = new HitCounter();
 * obj.Hit(timestamp);
 * int param_2 = obj.GetHits(timestamp);
 */

public class HitCounter1
{
    LinkedList<KeyValuePair<int, int>> linkedList;
    public HitCounter1()
    {
        linkedList = new LinkedList<KeyValuePair<int, int>>();
    }

    // Time: O(1)
    // Time: O(n)
    public void Hit(int timestamp)
    {
        if (linkedList.Count == 0)
        {
            linkedList.AddLast(new LinkedListNode<KeyValuePair<int, int>>(new KeyValuePair<int, int>(timestamp, 1)));
        }
        else
        {
            var currTime = linkedList.Last.Value.Key;
            var currCount = linkedList.Last.Value.Value;
            if (currTime == timestamp)
            {
                linkedList.RemoveLast();
                linkedList.AddLast(new LinkedListNode<KeyValuePair<int, int>>(new KeyValuePair<int, int>(timestamp, currCount + 1)));
            }
            else
            {
                linkedList.AddLast(new LinkedListNode<KeyValuePair<int, int>>(new KeyValuePair<int, int>(timestamp, 1)));
            }
        }
    }

    public int GetHits(int timestamp)
    {
        Cleanup(timestamp);
        int count = 0;
        foreach (var pair in linkedList)
        {
            count += pair.Value;
        }

        return count;
    }

    private void Cleanup(int timestamp)
    {
        while (linkedList.Count != 0 && linkedList.First.Value.Key + 300 <= timestamp)
        {
            linkedList.RemoveFirst();
        }
    }
}