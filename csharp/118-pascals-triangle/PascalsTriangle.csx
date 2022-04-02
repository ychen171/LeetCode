public class Solution
{
    // Brute force
    // Time: O(m^2)
    // Time: O(1)
    public IList<IList<int>> Generate(int numRows)
    {
        var ans = new List<IList<int>>();
        int m = numRows;
        int row = 0;
        // row = 0
        if (row < m)
        {
            ans.Add(new List<int>() { 1 });
            row++;
        }
        // row = 1
        if (row < m)
        {
            ans.Add(new List<int>() { 1, 1 });
            row++;
        }
        // row = [2, 3, 4, ... m-1]
        while (row < m)
        {
            var prevList = ans[row - 1];
            var currList = new List<int>();
            currList.Add(1);
            for (int col = 1; col < row; col++)
            {
                currList.Add(prevList[col - 1] + prevList[col]);
            }
            currList.Add(1);
            ans.Add(currList);
            row++;
        }

        return ans;
    }
}
