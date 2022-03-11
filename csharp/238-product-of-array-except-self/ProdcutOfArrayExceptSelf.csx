public class Solution
{
    // Brute force
    // Time: O(n^2)
    // Space: O(1)
    public int[] ProductExceptSelf(int[] nums)
    {
        var result = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            int product = 1;
            for (int j = 0; j < nums.Length; j++)
            {
                if (i == j) continue;
                product *= nums[j];
            }
            result[i] = product;
        }

        return result;
    }

    // Left and Right product arrays
    // Time: O(n)
    // Space: O(n)
    public int[] ProductExceptSelf1(int[] nums)
    {
        int[] leftArr = new int[nums.Length];
        int[] rightArr = new int[nums.Length];
        // populate left product array
        leftArr[0] = 1;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            leftArr[i + 1] = leftArr[i] * nums[i];
        }
        // populate right product array
        rightArr[rightArr.Length - 1] = 1;
        for (int j = nums.Length - 1; j > 0; j--)
        {
            rightArr[j - 1] = rightArr[j] * nums[j];
        }
        int[] result = new int[nums.Length];
        for (int k = 0; k < nums.Length; k++)
        {
            result[k] = leftArr[k] * rightArr[k];
        }

        return result;
    }

    // Store left and right product arrays in single output array
    // Time: O(n)
    // Space: O(1)
    public int[] ProductExceptSelf2(int[] nums)
    {
        int[] result = new int[nums.Length];
        // store left product array into result array
        result[0] = 1;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            result[i + 1] = result[i] * nums[i];
        }
        // calculate right product array on the fly and multiply by left product
        int rightProduct = 1;
        for (int j = nums.Length - 1; j >= 0; j--)
        {
            result[j] = result[j] * rightProduct;
            rightProduct *= nums[j];
        }

        return result;
    }
}
