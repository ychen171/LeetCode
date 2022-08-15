public class Solution
{
    // BFS | TLE
    // Time: O()
    // Space: O()
    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
    {
        // edge case
        var result = new List<IList<string>>();
        var wordSet = wordList.ToHashSet();
        if (!wordSet.Contains(endWord))
            return result;

        // BFS
        var queue = new Queue<List<string>>();
        var visited = new HashSet<string>();
        queue.Enqueue(new List<string> { beginWord });
        visited.Add(beginWord);
        bool found = false;
        while (queue.Count != 0)
        {
            int levelLen = queue.Count;
            for (int i = 0; i < levelLen; i++)
            {
                var path = queue.Dequeue();
                var curr = path.Last();
                if (curr == endWord)
                {
                    result.Add(path);
                    found = true;
                }
                var neiSet = GetNeigbors(curr, wordSet);
                foreach (var nei in neiSet)
                {
                    var neiPath = new List<string>(path);
                    neiPath.Add(nei);
                    visited.Add(nei);
                    queue.Enqueue(neiPath);
                }
            }
            if (found)
                break;
            foreach (var word in visited)
                wordSet.Remove(word);
            visited.Clear();
        }
        return result;
    }

    private HashSet<string> GetNeigbors(string word, HashSet<string> wordSet)
    {
        var neiSet = new HashSet<string>();
        for (int i = 0; i < word.Length; i++)
        {
            var cs = word.ToArray();
            for (char c = 'a'; c <= 'z'; c++)
            {
                cs[i] = c;
                var nei = new string(cs);
                if (wordSet.Contains(nei))
                    neiSet.Add(nei);
            }
        }

        return neiSet;
    }
}

var sln = new Solution();
/*
"hit"
"cog"
["hot","dot","dog","lot","log","cog"]
*/
var startWord = "hit";
var endWord = "cog";
var wordList = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" };
var result = sln.FindLadders(startWord, endWord, wordList);
Console.WriteLine(result);
