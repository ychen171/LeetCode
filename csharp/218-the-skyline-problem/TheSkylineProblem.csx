public class Solution
{
    // Divde and Conquer similar to MergeSort
    // 
    public IList<IList<int>> GetSkyline(int[][] buildings)
    {
        int n = buildings.Length;
        var result = Helper(buildings, 0, buildings.Length - 1);
        return result;
    }

    public IList<IList<int>> Helper(int[][] buildings, int start, int end)
    {
        var result = new List<IList<int>>();
        // base case (0 or 1 building)
        if (start > end) return result;
        if (start == end)
        {
            int xStart = buildings[start][0];
            int xEnd = buildings[start][1];
            int y = buildings[start][2];
            result.Add(new List<int> { xStart, y });
            result.Add(new List<int> { xEnd, 0 });
            return result; // [[x0,y0], [x1, y1]]
        }
        // divide (more than 1 building)
        var mid = start + (end - start) / 2;
        // conquer
        var left = Helper(buildings, start, mid);
        var right = Helper(buildings, mid + 1, end);
        // combine
        return Merge(left, right);
    }

    public IList<IList<int>> Merge(IList<IList<int>> left, IList<IList<int>> right)
    {
        var result = new List<IList<int>>();
        int i = 0;
        int j = 0;
        int currX = 0;
        int currY = 0, leftY = 0, rightY = 0;
        int maxY = 0;
        while (i < left.Count && j < right.Count)
        {
            var leftX = left[i][0];
            var rightX = right[j][0];

            if (leftX < rightX) // select point from left
            {
                currX = leftX;
                leftY = left[i][1];
                i++;
            }
            else // select point from right
            {
                currX = rightX;
                rightY = right[j][1];
                j++;
            }

            maxY = Math.Max(leftY, rightY);
            if (currY != maxY)
            {
                UpdateResult(result, currX, maxY);
                currY = maxY;
            }
        }
        // add the remaining left
        AddRange(result, left, i, currY);
        // add the remaining right
        AddRange(result, right, j, currY);

        return result;
    }

    private void UpdateResult(IList<IList<int>> result, int x, int y)
    {
        // if skyline channge is not vertial, add new point
        // else update the last point
        if (result.Count == 0 || result.Last()[0] != x)
        {
            result.Add(new List<int> { x, y });
        }
        else
        {
            result.Last()[1] = y;
        }
    }

    private void AddRange(IList<IList<int>> result, IList<IList<int>> skylines, int index, int currY)
    {
        while (index < skylines.Count)
        {
            var x = skylines[index][0];
            var y = skylines[index][1];
            // Update result if there is a skyline change
            if (y != currY)
            {
                UpdateResult(result, x, y);
                currY = y;
            }
            index++;
        }
    }
}
