public class Solution
{
    // loop
    // Time: O(n^2)
    // Space: O(1)
    public void DuplicateZeros(int[] arr)
    {
        int n = arr.Length;
        for (int i = n - 2; i >= 0; i--)
        {
            if (arr[i] == 0)
            {
                for (int j = n - 2; j >= i; j--)
                {
                    arr[j + 1] = arr[j];
                }
            }
        }

        return;
    }

    // Two pass
    // Time: O(n)
    // Space: O(1)
    public void DuplicateZeros1(int[] arr)
    {
        int n = arr.Length;
        int end = n - 1;
        int dupCount = 0;
        // find the number of duplicate zeros
        // if the zero cannot be duplicated (no more space), 
        // set the last item to be zero, don't count dups and exclude it from the end index
        for (int i = 0; i <= end - dupCount; i++)
        {
            if (arr[i] == 0)
            {
                if (i == end - dupCount)
                {
                    arr[end] = 0;
                    end--;
                    break;
                }
                dupCount++;
            }
        }

        for (int i = end - dupCount; i >= 0; i--)
        {
            if (arr[i] == 0)
            {
                arr[i + dupCount] = arr[i];
                dupCount--;
                arr[i + dupCount] = arr[i];
            }
            else
                arr[i + dupCount] = arr[i];
        }

        return;
    }
}
