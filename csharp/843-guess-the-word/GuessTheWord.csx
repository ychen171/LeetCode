
// This is the Master's API interface.
// You should not implement it, or speculate about its implementation
class Master
{
    public int Guess(string word)
    {
        // TODO
        return -1;
    }
}


class Solution
{
    // Array | String
    // Time: O(n)
    // Space: O(n)
    public void FindSecretWord(string[] wordlist, Master master)
    {
        var candidateList = wordlist.ToList();
        var random = new Random();
        int matches = 0;
        while (candidateList.Count != 0)
        {
            // randomly pick a word
            int pick = random.Next(candidateList.Count);
            var word = candidateList[pick];

            // call API using the word
            matches = master.Guess(word);
            if (matches == 6)
                return;

            // shrink and size of candidateList 
            var newList = new List<string>();
            foreach (var candidate in candidateList)
            {
                if (FindMatches(word, candidate) == matches)
                    newList.Add(candidate);
            }
            candidateList = newList;
        }
    }

    // Time: O(6) or O(1)
    // Space: O(1)
    public int FindMatches(string word, string candidate)
    {
        int ans = 0;
        int n = word.Length;
        for (int i = 0; i < n; i++)
        {
            if (word[i] == candidate[i])
                ans++;
        }

        return ans;
    }
}
