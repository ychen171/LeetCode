public class Solution
{
    // Two pointers with cache
    // Time: O(n)
    // Space: O(n)
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        if (nums.Length == 1) return 1;
        int[] counts = new int[nums.Length];
        // count consecutive ones and store in array
        int i = 0;
        int j = 0;
        int count = 0;
        for (j = 0; j < nums.Length; j++)
        {
            if (nums[j] == 0)
            {
                Console.WriteLine($"i:{i}, count:{count}");
                counts[i] = count;
                i = j + 1;
                count = 0;
            }
            else
                count++;
        }
        if (count > 0)
            counts[i] = count;
        // try flip one 0, find max consecutive ones
        int max = 0;
        i = 0;
        int k = 0;
        while (i < counts.Length)
        {
            if (counts[i] > 0)
            {
                Console.WriteLine($"k:{k}, counts[{k}]:{counts[k]}, i:{i}, counts[{i}]:{counts[i]}");
                if (i == k + counts[k] + 1)
                    max = Math.Max(max, counts[k] + counts[i]);
                else
                    max = Math.Max(max, counts[i]);
                k = i;
                i = i + counts[i];
                Console.WriteLine($"k:{k}, i:{i}");
            }
            else
            {
                i++;
                Console.WriteLine($"i:{i}");
            }
        }

        return max < nums.Length ? max + 1 : max;
    }

    // Two pointers One pass
    // Time: O(n)
    // Space: O(1)
    public int FindMaxConsecutiveOnes1(int[] nums)
    {
        if (nums.Length == 1) return 1;
        int max = 0;
        int curr = 0;
        int prev = 0;
        int seenZero = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                prev = curr;
                curr = 0;
                seenZero = 1;
            }
            else
            {
                curr++;
            }
            max = Math.Max(max, prev + curr + seenZero);
        }

        return max;
    }

    // Sliding Window
    public int FindMaxConsecutiveOnes2(int[] nums)
    {
        int max = 0;
        int i = 0;
        int j = 0;
        int zeroCount = 0;

        while (j < nums.Length)
        {
            // update zero counter
            if (nums[j] == 0)
            {
                zeroCount++;
            }
            // check if the window is valid
            while (zeroCount > 1)
            {
                if (nums[i] == 0)
                {
                    zeroCount--;
                }
                i++;
            }
            // update max
            max = Math.Max(max, j - i + 1);
            // expand window
            j++;
        }

        return max;
    }
}
