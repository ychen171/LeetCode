public class Solution
{
    // Brute force
    // Time: O(n)
    // Space: O(1)
    public bool ValidMountainArray(int[] arr)
    {
        int max = 0;
        int p = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] >= max)
            {
                max = arr[i];
                p = i;
            }
        }

        if (p == 0 || p == arr.Length - 1)
            return false;

        for (int i = 1; i <= p; i++)
        {
            if (arr[i] <= arr[i - 1])
                return false;
        }

        for (int i = p + 1; i < arr.Length; i++)
        {
            if (arr[i] >= arr[i - 1])
                return false;
        }

        return true;
    }

    public bool ValidMountainArray1(int[] arr)
    {
        int i = 0;
        // walk up
        while (i >= 0 && i < arr.Length - 1 && arr[i + 1] > arr[i])
        {
            i++;
        }
        if (i == 0 || i == arr.Length - 1)
            return false;
        // walk down
        while (i < arr.Length - 1)
        {
            if (arr[i + 1] >= arr[i])
                return false;
            i++;
        }

        return true;
    }
}
