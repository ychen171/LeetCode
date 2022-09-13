public class Solution
{
    // String Manipulation
    // Time: O(n)
    // Space: O(n)
    public bool ValidUtf8(int[] data)
    {
        int n = data.Length;
        var binaryStrs = new string[n];
        for (int i = 0; i < n; i++)
        {
            int num = data[i];
            var str = Convert.ToString(num, 2);
            if (str.Length < 8)
                binaryStrs[i] = new string('0', 8 - str.Length) + str;
            else
                binaryStrs[i] = str;
        }

        int byteCount = 0;
        foreach (var str in binaryStrs)
        {
            if (byteCount > 0)
            {
                if (!str.StartsWith("10"))
                    return false;
                byteCount--;
            }
            else // new start
            {
                int indexOfZero = str.IndexOf('0');
                if (indexOfZero == -1)  // 11111111
                    return false;
                if (indexOfZero == 1)   // 10xxxxxx
                    return false;
                if (indexOfZero > 4)    // 111110xx
                    return false;
                if (indexOfZero == 0)   // 0xxxxxxx
                    continue;
                byteCount = indexOfZero - 1;
            }
        }

        return byteCount == 0;
    }
}

var sln = new Solution();
// var data = new int[] { 197, 130, 1 };
// var data = new int[] { 237 };
// var data = new int[] { 145 };
var data = new int[] { 250, 145, 145, 145, 145 };
var result = sln.ValidUtf8(data);
Console.WriteLine(result);

