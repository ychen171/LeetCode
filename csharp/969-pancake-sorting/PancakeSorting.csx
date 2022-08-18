public class Solution
{
    // Recursion
    // Time: O(n^2)
    // Space: O(n)
    public IList<int> PancakeSort(int[] arr)
    {
        /*
            3   2   4   1           k=4
            1   4   2   3           k=2
            4   1   2   3           k=4
            3   2   1   4           k=3
            1   2   3   4

            sort(arr, n), n is the number of indexes, starting at 0
            1. find max at index [0, n-1]
            2. move the max to bottom at [0, n-1]
            3. recursively call sort(arr, n-1), sort(arr, n-2), ...

            3   2   4   1

            sort(arr, 4), max=4, k=3
            4   2   3   1
            1   3   2   4

            sort(arr, 3), max=3, k=2
            3   1   2   4
            2   1   3   4

            sort(arr, 2), max=2, k=1
            2   1   3   4
            1   2   3   4
            
            sort(arr, 1), base case

        */
        var result = new List<int>();
        Sort(arr, arr.Length, result);
        return result;
    }

    private void Sort(int[] arr, int n, IList<int> result)
    {
        // base case
        if (n == 1)
            return;

        // recursive case
        int max = 0;
        int index = -1;
        for (int i = 0; i < n; i++)
        {
            var num = arr[i];
            if (num > max)
            {
                max = num;
                index = i;
            }
        }
        // flip at [0, index]
        Flip(arr, 0, index);
        result.Add(index + 1);
        Flip(arr, 0, n - 1);
        result.Add(n);
        Sort(arr, n - 1, result);
    }

    private void Flip(int[] arr, int i, int j)
    {
        // flip at [i, j]
        while (i < j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            i++;
            j--;
        }
    }
}
