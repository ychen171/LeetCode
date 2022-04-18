public class Solution
{
    // Dictionary
    // Time: O(m + n)
    // Space: O(m)
    public string[] FindRestaurant(string[] list1, string[] list2)
    {
        List<string> ansList = new List<string>();
        int sum = int.MaxValue;
        var dict1 = new Dictionary<string, int>();
        for (int i = 0; i < list1.Length; i++)
            dict1[list1[i]] = i;

        for (int j = 0; j < list2.Length; j++)
        {
            string item = list2[j];
            if (dict1.ContainsKey(item))
            {
                int currSum = dict1[item] + j;
                if (currSum < sum)
                {
                    ansList = new List<string>();
                    ansList.Add(item);
                    sum = currSum;
                }
                else if (currSum == sum)
                {
                    ansList.Add(item);
                }
            }
        }

        return ansList.ToArray();
    }
}
