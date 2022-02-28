public class Solution
{
    // HashSet
    // Time: O(n)
    // Space: O(1)
    public int FirstUniqChar(string s)
    {
        var set = new HashSet<char>();
        for (int i = 0; i < s.Length; i++)
        {
            var target = s[i];
            if (set.Contains(target)) continue;
            set.Add(target);
            var isUnique = true;
            for (int j = i + 1; j < s.Length; j++)
            {
                if (target == s[j])
                {
                    isUnique = false;
                    break;
                }
            }
            if (isUnique) return i;
        }

        return -1;
    }

    // HashTable/Dictionary
    // Time: O(n)
    // Space: O(1)
    public int FirstUniqChar1(string s)
    {
        var countDict = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            var target = s[i];
            if (countDict.ContainsKey(target))
                countDict[target]++;
            else
                countDict[target] = 1;
        }

        for (int i = 0; i < s.Length; i++)
        {
            var target = s[i];
            if (countDict[target] == 1)
                return i;
        }

        return -1;
    }
}


