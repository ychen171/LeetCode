public class Solution
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        var dict1 = new Dictionary<int, int>();
        foreach (var item in nums1)
        {
            if (dict1.ContainsKey(item))
                dict1[item]++;
            else
                dict1[item] = 1;

        }
        var result = new List<int>();
        foreach (var target in nums2)
        {
            if (!dict1.ContainsKey(target))
                continue;

            if (dict1[target] > 0)
            {
                dict1[target]--;
                result.Add(target);
            }
        }

        return result.ToArray();
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
var result = s.Intersect(new int[] { 1, 2, 2, 1 }, new int[] { 2, 2 });
Print(result);
Print(s.Intersect(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 }));
