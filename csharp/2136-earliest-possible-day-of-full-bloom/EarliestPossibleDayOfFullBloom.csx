public class Solution
{
    public int EarliestFullBloom(int[] plantTime, int[] growTime)
    {
        // create index array
        // sort by growTime in descending order
        // iterate and find totalPlantDays and result
        int n = plantTime.Length;
        var indexes = new List<int>();
        for (int i = 0; i < n; i++)
            indexes.Add(i);
        indexes.Sort(Comparer<int>.Create((a, b) => growTime[b] - growTime[a]));
        int totalPlantTime = 0;
        int result = 0;
        for (int i = 0; i < n; i++)
        {
            int index = indexes[i];
            totalPlantTime += plantTime[index];
            result = Math.Max(result, totalPlantTime + growTime[index]);
        }
        return result;
    }
}
