public class Solution
{
    // Diff Array
    // Time: O(n)
    // Space: O(n)
    public int[] CorpFlightBookings(int[][] bookings, int n)
    {
        // create diff array
        var diff = new int[n];
        // update diff array
        foreach (var booking in bookings)
        {
            int first = booking[0] - 1;
            int last = booking[1] - 1;
            int seats = booking[2];
            diff[first] += seats;
            if (last + 1 < n)
                diff[last + 1] -= seats;
        }
        // construct result array
        var result = new int[n];
        result[0] = diff[0];
        for (int i = 1; i < n; i++)
            result[i] = result[i - 1] + diff[i];

        return result;
    }
}
