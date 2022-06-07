public class Solution
{
    // Topological Sorting | BFS
    // Time: O(V + E)
    // Space: O(V + E)
    public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies)
    {
        // the directed graph   [src] = [dest0, dest1, dest2]
        // [yeast] -> [bread]
        // [flour] -> [bread]
        // [bread] -> [sandwich, burger]

        // incoming edge count // indegree
        // [yeast] = 0
        // [bread] = 2
        // [sandwich] = 2
        // [burger] = 3

        // create graph and incoming edge count
        var graph = new Dictionary<string, List<string>>();
        var incomingCount = new Dictionary<string, int>();
        foreach (var supply in supplies)
        {
            if (!graph.ContainsKey(supply))
                graph[supply] = new List<string>();
        }

        int n = recipes.Length;
        for (int i = 0; i < n; i++)
        {
            var recipe = recipes[i];
            var ingredientList = ingredients[i];
            foreach (var ingredient in ingredientList)
            {
                if (!graph.ContainsKey(ingredient))
                    graph[ingredient] = new List<string>();
                graph[ingredient].Add(recipe);

                incomingCount[recipe] = incomingCount.GetValueOrDefault(recipe, 0) + 1;
            }
        }

        // topological sorting using BFS, starting from supplies
        var recipeSet = recipes.ToHashSet();
        var result = new List<string>();
        var queue = new Queue<string>();
        foreach (var supply in supplies)
            queue.Enqueue(supply);
        string curr = null;
        while (queue.Count != 0)
        {
            curr = queue.Dequeue();
            // reach the recipe, add to result
            if (recipeSet.Contains(curr))
                result.Add(curr);
            // invalid or visited
            if (!graph.ContainsKey(curr)) // curr is supply, not made of anything else
                continue;
            foreach (var nei in graph[curr])
            {
                incomingCount[nei]--; // curr is one of the prerequisites for nei; decrease the count
                if (incomingCount[nei] == 0) // all prerequisites are reached
                {
                    queue.Enqueue(nei);
                }
            }
        }

        return result;
    }
}
