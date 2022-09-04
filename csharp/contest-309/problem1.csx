public class Solution
{
    public bool CheckDistances(string s, int[] distance)
    {
        int n = s.Length;
        var dict = new Dictionary<char, int>();
        for (int i = 0; i < n; i++)
        {
            var c = s[i];
            if (dict.ContainsKey(c))
            {
                var currDist = i - dict[c] - 1;
                if (currDist != distance[c - 'a'])
                    return false;
            }
            else
            {
                dict[c] = i;
            }
        }
        return true;
    }
}
