public class Solution
{
    // Dictionary | TLE
    // Time: O(n)
    // Space: O(n)
    public int MaxNumberOfFamilies(int n, int[][] reservedSeats)
    {
        //  1 2 3    4 5 6 7    8 9 10

        //  2 3 4 5, 4 5 6 7, 6 7 8 9
        // X = [4,5,6,7]
        //      X != [2, 3, 4, 5]      2 3 4 5
        //      X != [6, 7, 8, 9]      5 6 7 8
        // X != [3,4,5,6]
        //      X != [2, 3],     2 3 4 5
        //      X != [8, 9],     6 7 8 9

        // creat dict for all seats
        var openSeatDict = new Dictionary<int, HashSet<int>>();
        int[] colArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        for (int row = 1; row <= n; row++)
        {
            openSeatDict[row] = colArray.ToHashSet();
        }
        // remove reserved seats
        foreach (int[] seat in reservedSeats)
        {
            int row = seat[0];
            int col = seat[1];
            openSeatDict[row].Remove(col);
        }
        // allocate groups
        int ans = 0;
        for (int row = 1; row <= n; row++)
        {
            var openCols = openSeatDict[row];
            if (openCols.Contains(2) && openCols.Contains(3) && openCols.Contains(4) && openCols.Contains(5))
            {
                openCols.Remove(2);
                openCols.Remove(3);
                openCols.Remove(4);
                openCols.Remove(5);
                ans++;
            }
            if (openCols.Contains(6) && openCols.Contains(7) && openCols.Contains(8) && openCols.Contains(9))
            {
                openCols.Remove(6);
                openCols.Remove(7);
                openCols.Remove(8);
                openCols.Remove(9);
                ans++;
            }
            if (openCols.Contains(4) && openCols.Contains(5) && openCols.Contains(6) && openCols.Contains(7))
            {
                openCols.Remove(4);
                openCols.Remove(5);
                openCols.Remove(6);
                openCols.Remove(7);
                ans++;
            }
        }

        return ans;
    }

    // Dictionary of group
    // Time: O(n)
    // Space: O(1)
    public int MaxNumberOfFamilies1(int n, int[][] reservedSeats)
    {
        var reservedGroupDict = new Dictionary<int, HashSet<int>>(); 
        // [row] = index of the reserved group (0, 1, 2)
        //  0 => [2,3,4,5], 1 => [4,5,6,7], 2 => [6,7,8,9]

        foreach (var seat in reservedSeats)
        {
            int row = seat[0];
            int col = seat[1];
            if (!reservedGroupDict.ContainsKey(row))
                reservedGroupDict[row] = new HashSet<int>();
            
            if (col == 2 || col == 3 || col == 4 || col == 5)
                reservedGroupDict[row].Add(0);
            if (col == 4 || col == 5 || col == 6 || col == 7)
                reservedGroupDict[row].Add(1);
            if (col == 6 || col == 7 || col == 8 || col == 9)
                reservedGroupDict[row].Add(2);
        }

        // initialize the answer with the max result
        int ans = n * 2;
        // remove the reserved group from the answer
        foreach (var kv in reservedGroupDict)
        {       
            HashSet<int> groups = kv.Value;
            if (groups.Count == 3)
            {
                ans -= 2;
            }
            else if (groups.Count == 2 || groups.Count == 1)
            {
                ans -= 1;
            }
        }

        return ans;
    }
}
