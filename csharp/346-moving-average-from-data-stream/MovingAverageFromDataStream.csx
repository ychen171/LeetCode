public class MovingAverage
{
    public int size;
    private int sum;
    private Queue<int> queue;

    public MovingAverage(int size)
    {
        this.size = size;
        this.sum = 0;
        queue = new Queue<int>();
    }

    // Time: O(1)
    // Space: O(n)
    public double Next(int val)
    {
        queue.Enqueue(val);
        if (queue.Count > this.size)
        {
            int toRemove = queue.Dequeue();
            sum -= toRemove;
        }
        sum += val;
        return (double)sum / queue.Count;
    }
}

/**
 * Your MovingAverage object will be instantiated and called as such:
 * MovingAverage obj = new MovingAverage(size);
 * double param_1 = obj.Next(val);
 */