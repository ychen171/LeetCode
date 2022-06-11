public class Solution
{
    // Sliding Window
    // Time: O(n)
    // Space: O(k)
    public int SubarraysWithKDistinct(int[] nums, int k)
    {
        return AtMostK(nums, k) - AtMostK(nums, k - 1);
    }

    public int AtMostK(int[] nums, int k)
    {
        int n = nums.Length;
        var countDict = new Dictionary<int, int>();
        int l = 0;
        int r = 0;
        int ans = 0;
        while (r < n)
        {
            countDict[nums[r]] = countDict.GetValueOrDefault(nums[r], 0) + 1;
            while (countDict.Count > k)
            {
                countDict[nums[l]]--;
                if (countDict[nums[l]] == 0)
                    countDict.Remove(nums[l]);
                l++;
            }
            ans += r - l + 1;
            r++;
        }

        return ans;
    }

    // TLE
    // Sliding Window
    // Time: O(n^2)
    // Space: O(k)
    public int SubarraysWithKDistinct1(int[] nums, int k)
    {
        // sliding window
        // maintain the count of integer in the window
        // sliding from left to right
        // 1 2 1 2 3           k = 2
        // ij            1
        // i j           2    12
        // i   j         2    121  21
        // i     j       2    1212 212 12
        // i       j     3
        //   i     j     3
        //       i j     2    23

        // 2 1 1 1 2             k=1
        // ij         [2]=1               2
        // i j        [2]=1,[1]=1         
        //   ij       [1]=1,              1
        //   i j      [1]=2,              11 1
        //   i   j    [1]=3,              111 11 1
        //   i     j  [1]=3,[2]=1
        //        ij  [2]=1               2
        int n = nums.Length;
        var charCountDict = new Dictionary<int, int>();
        int l = 0; // left
        int r = 0; // right
        // [l, r]
        int ans = 0;

        while (r < n)
        {
            charCountDict[nums[r]] = charCountDict.GetValueOrDefault(nums[r], 0) + 1;
            // found good array in the window, add all subarrays to ans
            if (charCountDict.Count == k)
            {
                // Console.WriteLine($"== k: {l}, {r}");
                var tempDict = new Dictionary<int, int>(charCountDict);
                int count = 0;
                for (int i = l; i <= r; i++)
                {
                    var temp = nums[i];
                    if (tempDict.Count == k)
                        count++;
                    tempDict[temp]--;
                    if (tempDict[temp] == 0)
                        tempDict.Remove(temp);
                }
                // Console.WriteLine($"Count: {count}");
                ans += count;
                r++;
            }
            else if (charCountDict.Count < k)
            {
                r++;
            }
            else // > k
            {
                while (charCountDict.Count > k)
                {
                    charCountDict[nums[l]]--;
                    if (charCountDict[nums[l]] == 0)
                        charCountDict.Remove(nums[l]);
                    l++;
                }
                // == k
                if (charCountDict.Count == k)
                {
                    // Console.WriteLine($"== k: {l}, {r}");
                    var tempDict = new Dictionary<int, int>(charCountDict);
                    int count = 0;
                    for (int i = l; i <= r; i++)
                    {
                        var temp = nums[i];
                        if (tempDict.Count == k)
                            count++;
                        tempDict[temp]--;
                        if (tempDict[temp] == 0)
                            tempDict.Remove(temp);
                    }
                    // Console.WriteLine($"Count: {count}");
                    ans += count;
                    r++;
                }
            }
        }

        // Console.WriteLine($"{l}, {r}");

        return ans;
    }

}

var s = new Solution();
var inputList = new List<Tuple<int[], int>>
{
    new Tuple<int[], int>(new int[] { 1, 2, 1, 2, 3 }, 2),  // 7
    new Tuple<int[], int>(new int[] { 2, 1, 1, 1, 2 }, 1),  // 8
};

foreach (var input in inputList)
{
    Console.WriteLine(s.SubarraysWithKDistinct(input.Item1, input.Item2));
    Console.WriteLine(s.SubarraysWithKDistinct1(input.Item1, input.Item2));
}
