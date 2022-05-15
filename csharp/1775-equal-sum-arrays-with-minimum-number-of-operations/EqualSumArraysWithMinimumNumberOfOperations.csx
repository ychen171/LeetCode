public class Solution
{
    // Greedy + Dictionary
    // Time: O(m + n)
    // Space: O(m + n)
    public int MinOperations(int[] nums1, int[] nums2)
    {
        // 6 6          1
        // dict1 = {[6]=2}      dict2 = {[1]=1}
        // sum1 = 12       sum2 = 1      diff = 11
        // 6->1 = -5          1->6 = 5

        // 1 6          1
        // dict1={[1]=1, [6]=1}  dict2 = {[1]=1}
        // sum1 = 7         sum2 = 1     diff = 6
        // range 6 -> 1 = -5          1 -> 6 = 5

        // 1 1          1
        // dict1{[1]=2}      dict2 = {[1]=1}
        // sum1 = 2         sum2 = 1    diff = 1
        // range [1,4]      [1,5]

        // 1 1          2

        var countDict1 = new Dictionary<int, int>();
        var countDict2 = new Dictionary<int, int>();
        int sum1 = 0;
        int sum2 = 0;
        foreach (var num in nums1)
        {
            countDict1[num] = countDict1.GetValueOrDefault(num, 0) + 1;
            sum1 += num;
        }
        foreach (var num in nums2)
        {
            countDict2[num] = countDict2.GetValueOrDefault(num, 0) + 1;
            sum2 += num;
        }

        int ans = 0;
        while (sum1 != sum2)
        {
            if (sum1 < sum2) // either increase num1 or decrease num2
            {
                int min1 = countDict1.Keys.Min();
                int max2 = countDict2.Keys.Max();

                int limit1 = 6 - min1;
                int limit2 = max2 - 1;
                if (limit1 == 0 && limit2 == 0) // cannot do it
                    return -1;
                int diff = sum2 - sum1;
                if (limit1 >= limit2) // increase min1 by diff or to 6
                {
                    var newNum = Math.Min(6, min1 + diff);
                    // update dict1 for new num
                    countDict1[newNum] = countDict1.GetValueOrDefault(newNum, 0) + 1;
                    // update dict1 for old num
                    countDict1[min1]--;
                    if (countDict1[min1] == 0)
                        countDict1.Remove(min1);
                    // update sum1
                    sum1 = sum1 - min1 + newNum;
                }
                else // decrease max2 by diff or to 1
                {
                    var newNum = Math.Max(1, max2 - diff);
                    // update dict2 for new num
                    countDict2[newNum] = countDict2.GetValueOrDefault(newNum, 0) + 1;
                    // update dict2 for old num
                    countDict2[max2]--;
                    if (countDict2[max2] == 0) // remove old num
                        countDict2.Remove(max2);
                    // update sum2
                    sum2 = sum2 - max2 + newNum;
                }
            }
            else // either decrease num1 or increase num2
            {
                int max1 = countDict1.Keys.Max();
                int min2 = countDict2.Keys.Min();

                int limit1 = max1 - 1;
                int limit2 = 6 - min2;
                if (limit1 == 0 && limit2 == 0) // cannot do it
                    return -1;
                int diff = sum1 - sum2;
                if (limit1 >= limit2) // decrease max1 by diff or to 1
                {
                    var newNum = Math.Max(1, max1 - diff);
                    // update dict1 for new num
                    countDict1[newNum] = countDict1.GetValueOrDefault(newNum, 0) + 1;
                    // update dict1 for old num
                    countDict1[max1]--;
                    if (countDict1[max1] == 0) // remove old num
                        countDict1.Remove(max1);
                    // update sum1
                    sum1 = sum1 - max1 + newNum;
                }
                else  // increase min2 by diff or to 6
                {
                    var newNum = Math.Min(6, min2 + diff);
                    // update dict2 for new num
                    countDict2[newNum] = countDict2.GetValueOrDefault(newNum, 0) + 1;
                    // update dict2 for old num
                    countDict2[min2]--;
                    if (countDict2[min2] == 0) // remove old num
                        countDict2.Remove(min2);
                    // update sum2
                    sum2 = sum2 - min2 + newNum;
                }
            }
            ans++;
        }

        return ans;
    }
}


var s = new Solution();
var result = s.MinOperations(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 1, 2, 2, 2, 2 });
Console.WriteLine(result);