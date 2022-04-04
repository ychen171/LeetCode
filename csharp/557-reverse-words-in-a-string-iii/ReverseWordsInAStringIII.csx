public class Solution
{
    // Split and Reverse
    // Time: O(n)
    // Space: O(n)
    public string ReverseWords(string s)
    {
        var strs = s.Split(new char[] {' '});
        var sb = new StringBuilder();
        foreach (var str in strs)
        {
            sb.Append(new string(str.Reverse().ToArray()) + " ");
        }
        sb.Remove(sb.Length - 1, 1);
        return sb.ToString();
    }

    // Array of Characters
    // Time: O()
    // Space: O()
    public string ReverseWords1(string s)
    {
        char[] cs = s.ToCharArray();
        int left = 0;
        int right = 0;
        var sb = new StringBuilder();
        for (right = 0; right < cs.Length; right++)
        {
            if (cs[right] == ' ')
            {
                var temp = right;
                while (right >= left)
                {
                    sb.Append(cs[right]);
                    right--;
                }
                right = temp;
                left = right + 1;
            }
        }

        if (left < cs.Length)
        {
            sb.Append(' ');
            right = cs.Length - 1;
            while (right >= left)
            {
                sb.Append(cs[right]);
                right--;
            }
        }

        if (sb[0] == ' ')
            sb.Remove(0, 1);

        return sb.ToString();
    }
}
