public class Solution
{
    // Recursion
    // Time: O(n)
    // Space: O(n)
    public int KthGrammar(int n, int k)
    {
        if (n == 1 || k == 1) return 0;
        // 1 -> 0
        // 2 -> 0 1
        // 3 -> 0 1 1 0
        // 4 -> 0 1 1 0 1 0 0 1 
        // 5 -> 0 1 1 0 1 0 0 1 1 0 0 1 0 1 1 0
        // the left half is the previous row
        // the right half is the complement of the previous row
        int mid = (int)Math.Pow(2, n - 1) / 2;
        if (k <= mid)
            return KthGrammar(n - 1, k);
        else // bitwise complement
        {
            var result = KthGrammar(n - 1, k - mid);
            return ~result + 2; // TODO: why add 2
        }

    }
}

var s = new Solution();
Console.WriteLine(s.KthGrammar(1, 1));
Console.WriteLine(s.KthGrammar(2, 1));
Console.WriteLine(s.KthGrammar(2, 2));



