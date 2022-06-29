public class Solution
{
    // Greedy | Sorting
    // Time: O(N^2)
    // Space: O(N)
    public int[][] ReconstructQueue(int[][] people)
    {
        // [[7,0],[4,4],[7,1],[5,0],[6,1],[5,2]]

        //                          [4,4]
        // [[7,0],[7,1],[5,0],[6,1],[5,2]]

        // [5,0]                    [4,4]
        // [[7,0],[7,1],[6,1],[5,2]]

        // [5,0]        [5,2]       [4,4]
        // [[7,0],[7,1],[6,1]]

        //  [5,0]       [5,2] [6,1] [4,4] 
        // [[7,0],[7,1]]

        //  [5,0] [7,0] [5,2] [6,1] [4,4] 
        // [[7,1]]

        //  [5,0] [7,0] [5,2] [6,1] [4,4] [7,1]

        // edge case
        int n = people.Length;
        if (n == 1)
            return people;

        var result = new int[n][];
        // sort people by height in ascending order
        Array.Sort(people, (a, b) => a[0] - b[0]);
        for (int i = 0; i < n; i++)
        {
            var curr = people[i];
            int currHei = curr[0];
            int atFrontCount = curr[1];
            int currCount = 0;
            int j = 0;
            for (j = 0; i < n; j++)
            {
                if (currCount == atFrontCount)
                {
                    break;
                }
                if (result[j] == null || result[j][0] >= currHei) // same or greater height at k
                {
                    currCount++;
                }
            }

            if (currCount == atFrontCount)
            {
                while (result[j] != null)
                    j++;

                result[j] = curr;
            }
        }

        return result;
    }

    // Greedy | Sorting
    // Time: O(N^2)
    // Space: O(N)
    public int[][] ReconstructQueue1(int[][] people)
    {
        int n = people.Length;
        if (n == 1)
            return people;

        var result = new List<int[]>();
        // sort people by height in descending order and then by atFrontCount in ascending order
        Array.Sort(people, new PeopleComparer());
        for (int i = 0; i < n; i++)
        {
            var curr = people[i];
            int currHei = curr[0];
            int atFrontCount = curr[1];
            int currCount = 0;
            for (int j = 0; j < n; j++)
            {
                if (currCount == atFrontCount || j == i)
                {
                    result.Insert(j, curr);
                    break;
                }
                if (result[j][0] >= currHei)
                {
                    currCount++;
                }
            }
        }

        return result.ToArray();
    }
}

public class PeopleComparer : IComparer<int[]>
{
    public int Compare(int[] a, int[] b)
    {
        if (a[0] == b[0])
            return a[1] - b[1];
        else
            return b[0] - a[0];
    }
}


var s = new Solution();
var people = new int[][]
{
    new int[] { 7, 0 },
    new int[] { 4, 4 },
    new int[] { 7, 1 },
    new int[] { 5, 0 },
    new int[] { 6, 1 },
    new int[] { 5, 2 }
};

var result = s.ReconstructQueue(people);
Console.WriteLine(result);
