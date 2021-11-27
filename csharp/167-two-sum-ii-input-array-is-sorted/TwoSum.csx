public class Solution
{
    // two pointers
    public int[] TwoSum(int[] numbers, int target)
    {
        var left = 0;
        var right = numbers.Length - 1;
        while (left < right)
        {
            var sum = numbers[left] + numbers[right];
            if (sum == target)
                return new int[] { ++left, ++right };
            else if (sum < target)
                left++;
            else
                right--;
        }

        return new int[] { -1, -1 };
    }

    // dictionary
    public int[] TwoSum2(int[] numbers, int target)
    {
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < numbers.Length; i++)
        {
            var temp = target - numbers[i];
            if (dict.ContainsKey(temp))
                return new int[] { dict[temp] + 1, i + 1 };
            dict[numbers[i]] = i;
        }

        return new int[] { -1, -1 };
    }
}

public void Print(int[] input)
{
    var sb = new StringBuilder();
    sb.Append("[");
    foreach (var item in input)
        sb.Append(item + ", ");
    sb.Remove(sb.Length - 2, 2);
    sb.Append("]");
    Console.WriteLine(sb.ToString());
}

var s = new Solution();
Print(s.TwoSum(new int[] { -1, 0 }, -1));
Print(s.TwoSum(new int[] { 5, 25, 75 }, 100));
Print(s.TwoSum(new int[] { 2, 7, 11, 15 }, 9));
Console.WriteLine();

Print(s.TwoSum2(new int[] { -1, 0 }, -1));
Print(s.TwoSum2(new int[] { 5, 25, 75 }, 100));
Print(s.TwoSum2(new int[] { 2, 7, 11, 15 }, 9));
Console.WriteLine();
