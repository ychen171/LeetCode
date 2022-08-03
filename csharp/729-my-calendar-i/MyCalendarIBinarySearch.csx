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
        // binary search
        // find the smallest iv whose start is greater than start
        // find the biggest iv whose start  is less than start
        int currIndex = BinarySearchLeftBound(bookings, start);
        int prevIndex = BinarySearchRightBound(bookings, start);
        if (currIndex != -1 && prevIndex != -1)
        {
            curr = bookings[currIndex];
            prev = bookings[prevIndex];
            if (curr[0] >= end && prev[1] <= start)
            {
                bookings.Insert(currIndex, newIv);
                return true;
            }
            else
                return false;
        }
        if (prevIndex == -1)
        {
            curr = bookings[currIndex];
            if (curr[0] >= end)
            {
                bookings.Insert(currIndex, newIv);
                return true;
            }
            else
                return false;
        }
        if (currIndex == -1)
        {
            prev = bookings[prevIndex];
            if (prev[1] <= start)
            {
                bookings.Add(newIv);
                return true;
            }
            else
                return false;
        }

        return false;
    }

    private int BinarySearchLeftBound(List<int[]> bookings, int target)
    {
        int n = bookings.Count;
        int left = 0;
        int right = n - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            var iv = bookings[mid];
            if (iv[0] < target)
                left = mid + 1;
            else if (iv[0] > target)
                right = mid - 1;
            else
                right = mid - 1;
        }
        if (left == n) return -1;
        return left;
    }

    private int BinarySearchRightBound(List<int[]> bookings, int target)
    {
        int n = bookings.Count;
        int left = 0;
        int right = n - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            var iv = bookings[mid];
            if (iv[0] < target)
                left = mid + 1;
            else if (iv[0] > target)
                right = mid - 1;
            else
                left = mid + 1;
        }
        if (right == -1) return -1;
        return right;
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */
