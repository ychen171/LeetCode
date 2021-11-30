
public class Solution
{
    public IList<int> PartitionLabels(string s)
    {
        var charIndexDict = new Dictionary<char, List<int>>();
        for (int i = 0; i < s.Length; i++)
        {
            var letter = s[i];
            if (!charIndexDict.ContainsKey(letter))
            {
                var startEndIndex = new List<int>();
                startEndIndex.Add(i);
                startEndIndex.Add(i);
                charIndexDict[letter] = startEndIndex;
            }
            else
                charIndexDict[letter][1] = i;
        }

        int prevStart = 0;
        int prevEnd = 0;
        var result = new List<int>();
        foreach (var kv in charIndexDict)
        {
            var currStart = kv.Value[0];
            var currEnd = kv.Value[1];
            if (currStart > prevEnd)
            {
                result.Add(prevEnd - prevStart + 1);
                prevStart = currStart;
                prevEnd = currEnd;
            }
            else
                prevEnd = Math.Max(prevEnd, currEnd);
        }
        result.Add(prevEnd - prevStart + 1);
        return result;
    }
}

public void Print(IList<int> input)
{
    var sb = new StringBuilder();
    sb.Append("[");
    foreach (var item in input)
        sb.Append(item + ", ");
    sb.Remove(sb.Length - 2, 2);
    sb.Append("]");
    Console.WriteLine(sb.ToString());
}



var s = new Solution();
Print(s.PartitionLabels("ababcbacadefegdehijhklij"));





