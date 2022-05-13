public class MedianFinder
{
    // Space: O(n)
    PriorityQueue<int, int> leftPQ;
    PriorityQueue<int, int> rightPQ;
    public MedianFinder()
    {
        leftPQ = new PriorityQueue<int, int>(); // max heap
        rightPQ = new PriorityQueue<int, int>(); // min heap
    }

    // Time: O(log n)
    public void AddNum(int num)
    {
        // add to left PQ by default
        int rightMin = rightPQ.Count == 0 ? int.MaxValue : rightPQ.Peek();
        if (num > rightMin)
            rightPQ.Enqueue(num, num);
        else
            leftPQ.Enqueue(num, -num);
        
        // check and adjust the length
        while (leftPQ.Count - rightPQ.Count > 1)
        {
            int curr = leftPQ.Dequeue();
            rightPQ.Enqueue(curr, curr);
        }
        while (rightPQ.Count - leftPQ.Count > 0)
        {
            int curr = rightPQ.Dequeue();
            leftPQ.Enqueue(curr, -curr);
        }
    }

    // Time: O(1)
    public double FindMedian()
    {
        // two pqs have same length
        if (leftPQ.Count != 0 && leftPQ.Count == rightPQ.Count)
            return (double)(leftPQ.Peek() + rightPQ.Peek()) / 2.0;
        // leftPQ is longer
        else
            return (double)leftPQ.Peek();
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */

var s = new MedianFinder();
s.AddNum(1);
s.AddNum(2);
Console.WriteLine(s.FindMedian());
s.AddNum(3);
Console.WriteLine(s.FindMedian());
