public class Solution
{
    // Dictionary + Sorting
    // Time: O(n log n + n^3) in worst, O(n log n + n) in best
    // Space: O(n)
    public IList<string> MostVisitedPattern(string[] username, int[] timestamp, string[] website)
    {
        /*
            ua  ua  ua  ub  ub  ub
            1   2   3   4   5   6
            a   b   a   a   b   c

            a   b   a       1
            a   b   c       1
            
            dict[ua] = [a,b,a]
            dict[ub] = [a,b,c]

        */

        // build visitDict => user: websites
        var visitDict = new Dictionary<string, List<string>>();
        var sortKeys = new int[timestamp.Length];
        timestamp.CopyTo(sortKeys, 0);
        Array.Sort(sortKeys, username); // sort username by timestamp
        timestamp.CopyTo(sortKeys, 0);
        Array.Sort(sortKeys, website);  // sort website by timestamp
        int n = timestamp.Length;
        for (int i = 0; i < n; i++)
        {
            var u = username[i];
            var w = website[i];
            if (!visitDict.ContainsKey(u))
                visitDict[u] = new List<string>();
            visitDict[u].Add(w);
        }

        // find every pattern and count users
        var patUserDict = new Dictionary<string, HashSet<string>>();
        foreach (var kv in visitDict)
        {
            var user = kv.Key;
            var webList = kv.Value;
            if (webList.Count < 3)
                continue;
            for (int i = 0; i < webList.Count; i++)
            {
                for (int j = i + 1; j < webList.Count; j++)
                {
                    for (int k = j + 1; k < webList.Count; k++)
                    {
                        var sb = new StringBuilder();
                        sb.Append(webList[i]).Append(',').Append(webList[j]).Append(',').Append(webList[k]);
                        var pat = sb.ToString();
                        if (!patUserDict.ContainsKey(pat))
                            patUserDict[pat] = new HashSet<string>();
                        patUserDict[pat].Add(user);
                    }
                }
            }
        }

        // find max score
        int maxScore = 0;
        foreach (var userSet in patUserDict.Values)
            maxScore = Math.Max(maxScore, userSet.Count);
        if (maxScore == 0)
            return null;
        // find max score patterns
        List<string> mostPatterns = new List<string>();
        foreach (var kv in patUserDict)
        {
            var pat = kv.Key;
            var userSet = kv.Value;
            var score = userSet.Count;
            if (score >= maxScore)
            {
                mostPatterns.Add(pat);
                maxScore = score;
            }
        }
        if (mostPatterns.Count == 0)
            return null;

        // sort in lexi order
        mostPatterns.Sort();
        return mostPatterns[0].Split(',').ToList();
    }
}

/*
["dowg","dowg","dowg"]
[158931262,562600350,148438945]
["y","loedo","y"]
*/
var sln = new Solution();
var username = new string[] { "dowg", "dowg", "dowg" };
var timestamp = new int[] { 158931262, 562600350, 148438945 };
var website = new string[] { "y", "loedo", "y" };

/*
["zkiikgv","zkiikgv","zkiikgv","zkiikgv"]
[436363475,710406388,386655081,797150921]
["wnaaxbfhxp","mryxsjc","oz","wlarkzzqht"]
*/
username = new string[] { "zkiikgv", "zkiikgv", "zkiikgv", "zkiikgv" };
timestamp = new int[] { 436363475, 710406388, 386655081, 797150921 };
website = new string[] { "wnaaxbfhxp", "mryxsjc", "oz", "wlarkzzqht" };

/*
["h","eiy","cq","h","cq","txldsscx","cq","txldsscx","h","cq","cq"]
[527896567,334462937,517687281,134127993,859112386,159548699,51100299,444082139,926837079,317455832,411747930]
["hibympufi","hibympufi","hibympufi","hibympufi","hibympufi","hibympufi","hibympufi","hibympufi","yljmntrclw","hibympufi","yljmntrclw"]
*/
username = new string[] { "h", "eiy", "cq", "h", "cq", "txldsscx", "cq", "txldsscx", "h", "cq", "cq" };
timestamp = new int[] { 527896567, 334462937, 517687281, 134127993, 859112386, 159548699, 51100299, 444082139, 926837079, 317455832, 411747930 };
website = new string[] { "hibympufi", "hibympufi", "hibympufi", "hibympufi", "hibympufi", "hibympufi", "hibympufi", "hibympufi", "yljmntrclw", "hibympufi", "yljmntrclw" };

/*
["g","gnyzbcggec","ghswd","ghswd","g","ghswd","xevn","ghswd","ghswd","xevn","g","ghswd","ghswd","xevn"]
[901084750,649291680,787654559,358221108,460949921,161111936,946313451,28476065,770103644,807659354,981056328,997032135,494515452,437013388]
["sizphxp","qfq","civvrxnd","civvrxnd","qfq","civvrxnd","sizphxp","sizphxp","sizphxp","civvrxnd","civvrxnd","qfq","qfq","civvrxnd"]
*/
username = new string[] { "g", "gnyzbcggec", "ghswd", "ghswd", "g", "ghswd", "xevn", "ghswd", "ghswd", "xevn", "g", "ghswd", "ghswd", "xevn" };
timestamp = new int[] { 901084750, 649291680, 787654559, 358221108, 460949921, 161111936, 946313451, 28476065, 770103644, 807659354, 981056328, 997032135, 494515452, 437013388 };
website = new string[] { "sizphxp", "qfq", "civvrxnd", "civvrxnd", "qfq", "civvrxnd", "sizphxp", "sizphxp", "sizphxp", "civvrxnd", "civvrxnd", "qfq", "qfq", "civvrxnd" };


var result = sln.MostVisitedPattern(username, timestamp, website);
Console.WriteLine(result);

Console.WriteLine(string.Compare("qfq", "sizphxp"));