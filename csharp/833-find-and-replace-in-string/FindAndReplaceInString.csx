public class Solution
{
    // Sorting + Two Pointers
    // Time: O(k * log k + k * n)
    // Space: O(n)
    public string FindReplaceString(string s, int[] indices, string[] sources, string[] targets)
    {
        int n = s.Length;
        int k = indices.Length;
        var sb = new StringBuilder();
        int prevIndex = 0;
        int currIndex = 0;
        int prevLen = 0;
        int currLen = 0;
        int[] sortKeys = new int[k];
        Array.Copy(indices, sortKeys, k);
        Array.Sort(sortKeys, sources);
        Array.Copy(indices, sortKeys, k);
        Array.Sort(indices, targets);
        Array.Sort(indices);
        for (int i = 0; i < k; i++)
        {
            string srcStr = sources[i];
            currLen = srcStr.Length;
            currIndex = indices[i];
            if (currIndex + currLen > n)
                continue;
            if (currIndex - prevIndex > prevLen)
            {
                sb.Append(s.Substring(prevIndex + prevLen, currIndex - prevIndex - prevLen));
            }
            string currStr = s.Substring(currIndex, currLen);
            if (currStr == srcStr) // matched 
            {
                sb.Append(targets[i]); // replace
            }
            else  // not matched
            {
                sb.Append(currStr); // don't replace
            }
            prevLen = currLen;
            prevIndex = currIndex;
        }

        // next index should be n
        if (prevIndex + prevLen < n) // there are substring left
        {
            sb.Append(s.Substring(prevIndex + prevLen));
        }

        return sb.ToString();
    }
}

/*
"vmokgggqzp"
[3,5,1]
["kg","ggq","mo"]
["s","so","bfr"]
*/
var sln = new Solution();
var s = "vmokgggqzp";
var indices = new int[] { 3, 5, 1 };
var sources = new string[] { "kg", "ggq", "mo" };
var targets = new string[] { "s", "so", "bfr" };
var result = sln.FindReplaceString(s, indices, sources, targets);
Console.WriteLine(result);
/*
"abcde"
[2,2]
["cdef","bc"]
["f","fe"]
*/
s = "abcde";
indices = new int[] { 2, 2 };
sources = new string[] { "cdef", "bc" };
targets = new string[] { "f", "fe" };
result = sln.FindReplaceString(s, indices, sources, targets);
Console.WriteLine(result);
/*
"abcd"
[0, 2]
["a", "cd"]
["eee", "ffff"]
*/
s = "abcd";
indices = new int[] { 0, 2 };
sources = new string[] { "a", "cd" };
targets = new string[] { "eee", "ffff" };
result = sln.FindReplaceString(s, indices, sources, targets);
Console.WriteLine(result);