public class Solution
{
    // DFS traversal
    // Time: O(V + E)
    // Space: O(V)
    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        // DFS
        // n = rooms.Count
        // HashSet to record visited rooms
        var visited = new HashSet<int>();
        DFS(rooms, 0, visited);
        return visited.Count == rooms.Count;
    }

    private void DFS(IList<IList<int>> rooms, int index, HashSet<int> visited)
    {
        // base case
        if (index == rooms.Count)
            return;
        // recursive case
        if (visited.Add(index))
        {
            foreach (int key in rooms[index])
            {
                DFS(rooms, key, visited);
            }
        }
    }
}
