public class Solution
{
    // TLE
    // Working Backward + Priority Queue
    // Time: O(k * log n)
    // Space: O(n)
    // n is the length of target array
    // k is the maximum of the target array
    public bool IsPossible(int[] target)
    {
        // [9,3,5]    9 and 8
        // [1,3,5]    5 and 4
        // [1,3,1]    3 and 2
        // [1,1,1]

        // [8,5]      8 and 5
        // [3,5]      5 and 3
        // [3,2]      3 and 2
        // [1,2]      2 and 1
        // [1,1]

        // edge case
        if (target.Length == 1)
            return target[0] == 1;
        // add target into pq
        var pq = new PriorityQueue<int, int>(); // maxHeap
        int totalSum = 0;
        foreach (var num in target)
        {
            if (num != 1)
                pq.Enqueue(num, -num);
            totalSum += num;
        }

        while (pq.Count != 0)
        {
            // find the max num
            int maxNum = pq.Dequeue();
            int otherSum = totalSum - maxNum;
            if (otherSum == 1)
                return true;
            int newNum = maxNum - otherSum;
            if (newNum > 1) // maxNum - otherSum > 1
            {
                pq.Enqueue(newNum, -newNum);
                totalSum -= otherSum;
            }
            else if (newNum == 1)
            {
                totalSum -= otherSum;
            }
            else // maxNum - otherSum < 1
            {
                return false;
            }
        }

        // every num is 1
        return true;
    }

    // Working Backward + Priority Queue
    // Time: O(log k * log n)
    // Space: O(n)
    // n is the length of target array
    public bool IsPossible1(int[] target)
    {
        // edge case
        if (target.Length == 1)
            return target[0] == 1;
            
        // add target into pq
        var pq = new PriorityQueue<int, int>(); // maxHeap
        int totalSum = 0;
        foreach (var num in target)
        {
            pq.Enqueue(num, -num);
            totalSum += num;
        }

        while (pq.Peek() > 1)
        {
            // find the max num
            int maxNum = pq.Dequeue();
            int otherSum = totalSum - maxNum;
            if (otherSum == 1)
                return true;
            int newNum = maxNum % otherSum;
            // impossible to reduce
            if (newNum == 0 || newNum == maxNum)
                return false;

            pq.Enqueue(newNum, -newNum);
            totalSum = totalSum - maxNum + newNum;
        }

        // every num is 1
        return true;
    }
}
