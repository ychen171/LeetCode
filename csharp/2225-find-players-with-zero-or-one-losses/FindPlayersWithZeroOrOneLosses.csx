public class Solution
{
    public IList<IList<int>> FindWinners(int[][] matches)
    {
        var winCountMap = new Dictionary<int, int>();
        var loseCountMap = new Dictionary<int, int>();
        var playerSet = new HashSet<int>();
        foreach (var match in matches)
        {
            var winner = match[0];
            var loser = match[1];
            winCountMap[winner] = winCountMap.GetValueOrDefault(winner, 0) + 1;
            loseCountMap[loser] = loseCountMap.GetValueOrDefault(loser, 0) + 1;
            playerSet.Add(winner);
            playerSet.Add(loser);
        }
        var answer = new List<IList<int>>();
        var list0 = new List<int>();
        var list1 = new List<int>();
        foreach (var player in playerSet)
        {
            if (loseCountMap.ContainsKey(player))
            {
                if (loseCountMap[player] == 1)
                    list1.Add(player);
            }
            else // have not lost
            {
                list0.Add(player);
            }
        }
        list0.Sort();
        list1.Sort();
        answer.Add(list0);
        answer.Add(list1);
        return answer;
    }
}
// Dictionary + HashSet
// Time: O(n log n)
// Space: O(n)
