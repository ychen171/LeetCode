public class Logger
{
    Dictionary<string, int> limitDict;
    public Logger()
    {
        limitDict = new Dictionary<string, int>();
    }

    // Time: O(1)
    // Space: O(m)
    public bool ShouldPrintMessage(int timestamp, string message)
    {
        if (limitDict.ContainsKey(message))
        {
            if (timestamp < limitDict[message])
                return false;
            else
            {
                limitDict[message] = timestamp + 10;
                return true;
            }
        }
        limitDict.Add(message, timestamp + 10);
        return true;
    }
}

/**
 * Your Logger object will be instantiated and called as such:
 * Logger obj = new Logger();
 * bool param_1 = obj.ShouldPrintMessage(timestamp,message);
 */

public class Logger1
{
    Queue<Tuple<int, string>> msgQueue;
    HashSet<string> msgSet;
    public Logger1()
    {
        msgQueue = new Queue<Tuple<int, string>>();
        msgSet = new HashSet<string>();
    }

    // Time: O(n)
    // Space: O(n)
    public bool ShouldPrintMessage(int timestamp, string message)
    {
        // clean up queue and set
        while (msgQueue.Count != 0 && msgQueue.Peek().Item1 + 10 <= timestamp)
        {
            var msg = msgQueue.Dequeue();
            msgSet.Remove(msg.Item2);
        }
        // check if message is already in the queue
        if (msgSet.Contains(message))
        {
            return false;
        }
        else
        {
            msgSet.Add(message);
            msgQueue.Enqueue(new Tuple<int, string>(timestamp, message));
            return true;
        }
    }
}