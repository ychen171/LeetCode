public class Solution
{
    // Two Pointers
    // Time: O(n)
    // Space: O(1)
    public string ReverseVowels(string s)
    {
        int n = s.Length;
        int left = 0, right = n - 1;
        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        var cs = s.ToCharArray();
        while (left < right)
        {
            while (!vowels.Contains(s[left]) && left < right)
                left++;
            while (!vowels.Contains(s[right]) && left < right)
                right--;
            if (left < right)
            {
                Swap(cs, left, right);
                left++;
                right--;
            }
        }
        return new string(cs);
    }

    private void Swap(char[] cs, int i, int j)
    {
        var temp = cs[i];
        cs[i] = cs[j];
        cs[j] = temp;
    }
}
