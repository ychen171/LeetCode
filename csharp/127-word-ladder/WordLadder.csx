public class Solution
{
    // BFS Graph
    // Time: O(m * n^2)
    // Space: O(m * n^2)
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        if (!wordList.Contains(endWord)) return 0;
        if (!wordList.Contains(beginWord)) wordList.Add(beginWord);
        // create graph using dict based on the word list
        var graph = CreateGraph(wordList);
        // BFS
        // initialize Queue and HashSet
        var visited = new HashSet<string>();
        var queue = new Queue<string>();
        string currWord = beginWord;
        visited.Add(currWord);
        queue.Enqueue(currWord);
        int count = 1;
        
        while (queue.Count != 0)
        {
            // retrieve current level queue count
            int levelLength = queue.Count;
            for (int i = 0; i < levelLength; i++)
            {
                // get node for the current level
                currWord = queue.Dequeue();
                // return if it is what we want
                if (currWord == endWord)
                    return count;
                // add all neighbors into queue if not visited and valid
                var currNeighbors = graph.GetValueOrDefault(currWord, new List<string>());
                foreach (var neighbor in currNeighbors)
                {
                    if (visited.Add(neighbor))
                        queue.Enqueue(neighbor);
                }
            }
            count++;
        }

        return 0;
    }

    // Time: O(m * n^2)
    // Space: O(m * n^2)
    private Dictionary<string, IList<string>> CreateGraph(IList<string> wordList)
    {
        var graph = new Dictionary<string, IList<string>>();
        if (wordList == null || wordList.Count <= 1) return graph;
        for (int i = 0; i < wordList.Count - 1; i++)
        {
            for (int j = i + 1; j < wordList.Count; j++)
            {
                var word1 = wordList[i];
                var word2 = wordList[j];
                // check if word1 and word2 have only 1 different char
                if (OnlyOneDiff(word1, word2))
                {
                    if (!graph.ContainsKey(word1))
                        graph[word1] = new List<string>();
                    graph[word1].Add(word2);

                    if (!graph.ContainsKey(word2))
                        graph[word2] = new List<string>();
                    graph[word2].Add(word1);
                }
            }
        }

        return graph;
    }

    // Time: O(m)
    // Space: O(1)
    private bool OnlyOneDiff(string w1, string w2)
    {
        if (w1.Length != w2.Length) return false;
        int diff = 0;
        for (int i = 0; i < w1.Length; i++)
        {
            if (w1[i] != w2[i]) diff++;
        }

        return diff == 1;
    }
}

var s = new Solution();
Console.WriteLine(s.LadderLength("hit", "cog", new List<string> { "hot", "dot", "dog", "lot", "log", "cog" }));
