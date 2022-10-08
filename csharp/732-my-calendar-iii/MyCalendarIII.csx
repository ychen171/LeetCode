public class MyCalendarThree
{
    // Sweep-line Algo | SortedDictionary
    // Time: O(n log n)
    // Space: O(n)
    SortedDictionary<int, int> diff;
    public MyCalendarThree()
    {
        diff = new SortedDictionary<int, int>();
    }

    public int Book(int start, int end)
    {
        diff[start] = diff.GetValueOrDefault(start, 0) + 1;
        diff[end] = diff.GetValueOrDefault(end, 0) - 1;
        int result = 0, curr = 0;
        foreach (var delta in diff.Values)
        {
            curr += delta;
            result = Math.Max(result, curr);
        }
        return result;
    }
}

/**
 * Your MyCalendarThree object will be instantiated and called as such:
 * MyCalendarThree obj = new MyCalendarThree();
 * int param_1 = obj.Book(start,end);
 */
