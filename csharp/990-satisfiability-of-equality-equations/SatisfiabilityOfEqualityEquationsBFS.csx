public class Solution
{
    // BFS
    // Time: O(n)
    // Space: O(n)
    public bool EquationsPossible(string[] equations)
    {
        // build graph / array
        // BFS to connect variables level by level
        // check if the level matches the equation

        var graph = new List<int>[26];
        for (int i = 0; i < 26; i++)
            graph[i] = new List<int>();
        foreach (var equation in equations)
        {
            bool areEqual = equation[1] == '=';
            if (areEqual)
            {
                char x = equation[0];
                char y = equation[3];
                graph[x - 'a'].Add(y - 'a');
                graph[y - 'a'].Add(x - 'a');
            }
        }

        var visited = new bool[26];
        var groups = new int[26]; // variable to group
        int currGroup = 0;
        var queue = new Queue<int>();
        for (int i = 0; i < 26; i++)
        {
            if (visited[i])
                continue;
            currGroup++;
            queue.Enqueue(i);
            groups[i] = currGroup;
            visited[i] = true;
            while (queue.Count != 0)
            {
                var curr = queue.Dequeue();
                foreach (var nei in graph[curr])
                {
                    if (visited[nei])
                        continue;
                    groups[nei] = currGroup;
                    visited[nei] = true;
                    queue.Enqueue(nei);
                }
            }
        }

        foreach (var equation in equations)
        {
            bool areEqual = equation[1] == '=';
            if (!areEqual)
            {
                char x = equation[0];
                char y = equation[3];
                if (groups[x - 'a'] == groups[y - 'a'])
                    return false;
            }
        }

        return true;
    }
}
