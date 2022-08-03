public class MyCalendar
{
    List<int[]> bookings; // list of intervals
    public MyCalendar()
    {
        bookings = new List<int[]>();
    }

    public bool Book(int start, int end)
    {
        int n = bookings.Count;
        var newIv = new int[] { start, end };
        int[] prev, curr;
        // edge case
        if (n == 0)
        {
            bookings.Add(newIv);
            return true;
        }
        // n == 1
        // not overlapped: currEnd <= start || currStart >= end
        else if (n == 1)
        {
            curr = bookings[0];
            if (curr[0] >= end)
            {
                bookings.Insert(0, newIv);
                return true;
            }
            if (curr[1] <= start)
            {
                bookings.Add(newIv);
                return true;
            }
            else
                return false;
        }
        // n >= 2
        // not overlapped: currStart >= end && prevEnd <= start
        // find the smallest element whose start greater than start
        int i = 0;
        while (i < n && bookings[i][0] <= start)
            i++;
        // i == n || currStart > start
        if (i == 0)
        {
            curr = bookings[0];
            if (curr[0] >= end)
            {
                bookings.Insert(0, newIv);
                return true;
            }
            if (curr[1] <= start)
            {
                bookings.Add(newIv);
                return true;
            }
            else
                return false;
        }
        else if (i == n) // currStart <= start
        {
            curr = bookings[n - 1];
            if (curr[1] <= start)
            {
                bookings.Add(newIv);
                return true;
            }
            else
                return false;
        }
        else // currStart > start
        {
            prev = bookings[i - 1];
            curr = bookings[i];
            if (curr[0] >= end && prev[1] <= start)
            {
                bookings.Insert(i, newIv);
                return true;
            }
            else
                return false;
        }
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */

var sln = new MyCalendar();

var res1 = sln.Book(10, 20);
Console.WriteLine(res1);
var res2 = sln.Book(15, 25);
Console.WriteLine(res2);
var res3 = sln.Book(20, 30);
Console.WriteLine(res3);

