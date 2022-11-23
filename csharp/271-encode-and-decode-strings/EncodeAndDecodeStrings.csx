public class Codec
{

    // Encodes a list of strings to a single string.
    public string encode(IList<string> strs)
    {
        var sb = new StringBuilder();
        foreach (var str in strs)
            sb.Append(str.Length).Append("#").Append(str);
        return sb.ToString();
    }

    // Decodes a single string to a list of strings.
    public IList<string> decode(string s)
    {
        var result = new List<string>();
        int i = 0;
        int n = s.Length;
        while (i < n)
        {
            int j = i;
            while (s[j] != '#')
                j++;
            int len = int.Parse(s.Substring(i, j - i));
            result.Add(s.Substring(j + 1, len));
            i = j + 1 + len;
        }
        return result;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(strs));
