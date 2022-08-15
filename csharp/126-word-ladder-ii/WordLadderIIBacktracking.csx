public class Solution
{
    // BFS + Backtracking
    // TLE
    // Time: O()
    // Space: O()
    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
    {
        // edge case
        var result = new List<IList<string>>();
        var wordSet = wordList.ToHashSet();
        if (!wordSet.Contains(endWord))
            return result;

        // build the DAG using BFS
        var graph = BuildGraph(wordSet, beginWord, endWord);
        // Backtracking
        var path = new List<string> { beginWord };
        Backtrack(graph, path, beginWord, endWord, result);
        return result;
    }

    private HashSet<string> FindNeighbors(string word, HashSet<string> wordSet)
    {
        var neiSet = new HashSet<string>();
        for (int i = 0; i < word.Length; i++)
        {
            var cs = word.ToArray();
            for (char c = 'a'; c <= 'z'; c++)
            {
                if (c == cs[i])
                    continue;
                cs[i] = c;
                var nei = new string(cs);
                if (wordSet.Contains(nei))
                    neiSet.Add(nei);
            }
        }

        return neiSet;
    }

    private void Backtrack(Dictionary<string, List<string>> graph, List<string> path, string src, string dst, IList<IList<string>> result)
    {
        if (src == dst)
        {
            result.Add(new List<string>(path));
            return;
        }

        if (!graph.ContainsKey(src))
            return;

        foreach (var nei in graph[src])
        {
            path.Add(nei);
            Backtrack(graph, path, nei, dst, result);
            path.RemoveAt(path.Count - 1);
        }
    }

    private Dictionary<string, List<string>> BuildGraph(HashSet<string> wordSet, string beginWord, string endWord)
    {
        var graph = new Dictionary<string, List<string>>();

        if (wordSet.Contains(beginWord))
            wordSet.Remove(beginWord);

        var visited = new HashSet<string>();
        var queue = new Queue<string>();
        queue.Enqueue(beginWord);
        while (queue.Count != 0)
        {
            int levelLen = queue.Count;
            var visitedAtLevel = new HashSet<string>();
            for (int i = 0; i < levelLen; i++)
            {
                var curr = queue.Dequeue();
                if (visited.Contains(curr))
                    continue;
                visited.Add(curr);
                if (!graph.ContainsKey(curr))
                    graph[curr] = new List<string>();
                var neiSet = FindNeighbors(curr, wordSet);
                foreach (var nei in neiSet)
                {
                    graph[curr].Add(nei);
                    queue.Enqueue(nei);
                    visitedAtLevel.Add(nei);
                }
            }
            foreach (var word in visitedAtLevel)
                wordSet.Remove(word);
        }

        return graph;
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
