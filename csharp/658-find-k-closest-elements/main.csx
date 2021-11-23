public class Solution
{
    public IList<int> FindClosestElements(int[] arr, int k, int x)
    {
        if (arr.Length < k) return null;
        var left = 0;
        var right = arr.Length - k;

        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (x - arr[mid] > arr[mid + k] - x)
                left = mid + 1;
            else
                right = mid;
        }

        var result = new List<int>();
        for (int i = left; i < left + k; i++)
            result.Add(arr[i]);

        return result;
    }
}

public void PrintResult(IList<int> list)
{
    var sb = new StringBuilder();
    sb.Append("[");
    foreach (var item in list)
        sb.Append(item + ", ");
    sb.Remove(sb.Length - 2, 2);
    sb.Append("]");
    Console.WriteLine(sb.ToString());
}

var s = new Solution();
IList<int> result;

result = s.FindClosestElements(new int[] { 1, 2, 3, 4, 5 }, 4, 3);
PrintResult(result);
result = s.FindClosestElements(new int[] { 1, 2, 3, 4, 5 }, 4, -1);
PrintResult(result);



