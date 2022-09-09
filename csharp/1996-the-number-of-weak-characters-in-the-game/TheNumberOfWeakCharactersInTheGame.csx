public class Solution
{
    // Sorting + Next Greater Elements | Mono Stack
    // Time: O(n log n)
    // Space: O(n)
    public int NumberOfWeakCharacters(int[][] properties)
    {
        /*
            1,2
            1,1
            2,2
            2,1
        */
        // sort by attack in the acending order and defense in the descending order
        int n = properties.Length;
        Array.Sort(properties, (a, b) =>
        {
            if (a[0] == b[0])
                return b[1] - a[1];
            return a[0] - b[0];
        });
        // next greater elements
        int count = 0;
        var stack = new Stack<int[]>();
        for (int i = n - 1; i >= 0; i--)
        {
            var curr = properties[i];
            while (stack.Count != 0 && curr[1] >= stack.Peek()[1])
                stack.Pop();

            if (stack.Count != 0 && curr[0] < stack.Peek()[0])
                count++;

            stack.Push(curr);

        }

        return count;
    }
}
