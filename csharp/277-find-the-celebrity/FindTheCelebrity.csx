/* The Knows API is defined in the parent class Relation.
      bool Knows(int a, int b); */

public class Solution : Relation
{
    // Dictionary
    // Time: O(n^2)
    // Space: O(n)
    public int FindCelebrity(int n)
    {
        // key = person, value = peope who knows him/her / incoming edges
        var knownDict = new Dictionary<int, HashSet<int>>();
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (!knownDict.ContainsKey(j))
                    knownDict[j] = new HashSet<int>();
                if (!knownDict.ContainsKey(i))
                    knownDict[i] = new HashSet<int>();

                if (Knows(i, j))
                {
                    knownDict[j].Add(i);
                }
                if (Knows(j, i))
                {
                    knownDict[i].Add(j);
                }
            }
        }
        int ans = -1;
        for (int i = 0; i < n; i++)
        {
            bool found = false;
            if (knownDict[i].Count == n - 1)
            {
                found = true;
                foreach (var knownSet in knownDict.Values)
                {
                    if (knownSet.Contains(i))
                    {
                        found = false;
                        break;
                    }
                }
            }
            if (found)
            {
                ans = i;
                break;
            }
        }

        return ans;
    }

    public int FindCelebrity1(int n)
    {
        int candidate = 0;
        for (int i = 0; i < n; i++)
        {
            if (Knows(candidate, i))
            {
                candidate = i;
            }
        }

        if (IsCelebrity(n, candidate))
            return candidate;
        else
            return -1;
    }

    private bool IsCelebrity(int n, int candidate)
    {
        for (int j = 0; j < n; j++)
        {
            if (candidate == j)
                continue;
            if (Knows(candidate, j) || !Knows(j, candidate))
                return false;
        }

        return true;
    }
}
