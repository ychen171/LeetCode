public class Solution
{
    // Split + Parse, Two Pass
    // Time: O(N + M + max(N, M))
    // Space: O(N + M)
    public int CompareVersion(string version1, string version2)
    {
        var revisionArray1 = version1.Split('.');
        var revisionArray2 = version2.Split('.');
        var n1 = revisionArray1.Length;
        var n2 = revisionArray2.Length;
        var n = Math.Min(n1, n2);
        var i = 0;
        var result = 0;
        Console.WriteLine($"n1: {n1} -- n2:{n2}");
        while (i < n && result == 0)
        {
            var num1 = int.TryParse(revisionArray1[i], out var ra1) ? ra1 : 0;
            var num2 = int.TryParse(revisionArray2[i], out var ra2) ? ra2 : 0;
            Console.WriteLine($"i == {i}");
            Console.WriteLine($"{num1} -- {num2}");
            if (num1 < num2) result = -1;
            else if (num1 > num2) result = 1;
            else result = 0;
            i++;
        }

        if (n1 > n2)
        {
            while (i < n1 && result == 0)
            {
                var num1 = int.TryParse(revisionArray1[i], out var ra1) ? ra1 : 0;
                if (num1 > 0) result = 1;
                i++;
            }
        }
        if (n1 < n2)
        {
            while (i < n2 && result == 0)
            {
                var num2 = int.TryParse(revisionArray2[i], out var ra2) ? ra2 : 0;
                if (num2 > 0) result = -1;
                i++;
            }
        }

        return result;
    }
}
