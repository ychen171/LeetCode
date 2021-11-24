public class Solution
{
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        var set1 = nums1.ToHashSet();
        var set2 = nums2.ToHashSet();
        var foundSet = new HashSet<int>();
        foreach (var target in set1)
        {
            if (!foundSet.Contains(target) && set2.Contains(target))
            {
                foundSet.Add(target);
                set1.Remove(target);
                set2.Remove(target);
                continue;
            }
        }

        return foundSet.ToArray();
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
Print(s.Intersection(new int[] { 1, 2, 2, 1 }, new int[] { 2, 2 }));
Print(s.Intersection(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 }));
