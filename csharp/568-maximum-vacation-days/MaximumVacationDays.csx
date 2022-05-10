public class Solution
{
    // DP | Tabulation
    // Time: O(n^2 * k)
    // Space: O(n * k)
    public int MaxVacationDays(int[][] flights, int[][] days)
    {
        // the maximum number of vacation days that can be taken given we start from i city in k week 
        // is not dependent on the days that can be taken in the earlier weeks.
        // It only depends on the number of days that can be taken in the upcoming weeks 
        // and also on the connections between the various cities

        int n = flights.Length; // the number of cities
        int k = days[0].Length; // the number of weeks

        int[][] table = new int[n][];
        for (int i = 0; i < n; i++)
        {
            table[i] = new int[k + 1];
        }

        for (int week = k - 1; week >= 0; week--)
        {
            for (int curr = 0; curr < n; curr++)
            {
                table[curr][week] = days[curr][week] + table[curr][week + 1];
                for (int dest = 0; dest < n; dest++)
                {
                    if (flights[curr][dest] == 1)
                    {
                        table[curr][week] = Math.Max(table[curr][week], days[dest][week] + table[dest][week + 1]);
                    }
                }
            }
        }

        return table[0][0];
    }
}

var s = new Solution();
// var flights1 = new int[][] { new int[] { 0, 1, 1 }, new int[] { 1, 0, 1 }, new int[] { 1, 1, 0 } };
// var days1 = new int[][] { new int[] { 1, 3, 1 }, new int[] { 6, 0, 3 }, new int[] { 3, 3, 3 } };
// var result1 = s.MaxVacationDays(flights1, days1);
// Console.WriteLine(result1);
var flights2 = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 } };
var days2 = new int[][] { new int[] { 1, 1, 1 }, new int[] { 7, 7, 7 }, new int[] { 7, 7, 7 } };
var result2 = s.MaxVacationDays(flights2, days2);
Console.WriteLine(result2);

var flights3 = new int[][] { new int[] { 0, 1, 0 }, new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 } };
var days3 = new int[][] { new int[] { 0, 0, 7 }, new int[] { 2, 0, 0 }, new int[] { 7, 7, 7 } };
var result3 = s.MaxVacationDays(flights3, days3);
Console.WriteLine(result3);
