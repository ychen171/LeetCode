public class Solution
{
    public string DecodeString(string s)
    {
        // stack
        // Input: s = "3[a]2[bc]", Output: "aaabcbc"
        // 3[a]
        // 3[, str = "a"
        // , str = "a", k = 3
        // k = 3, str = "a",      sb = "aaa"
        // 2[bc], k = 2, str = "bc"     sb = "aaabcbc"

        var stack = new Stack<char>();
        List<char> cs = s.ToCharArray().ToList();
        for (int i = 0; i < cs.Count; i++)
        {
            if (cs[i] == ']')
            {
                List<char> strList = new List<char>();
                while (stack.Peek() != '[')
                {
                    strList.Insert(0, stack.Pop());
                }
                stack.Pop();

                List<char> kList = new List<char>();
                while (stack.Count != 0 && char.IsNumber(stack.Peek()))
                {
                    kList.Insert(0, stack.Pop());
                }
                int k = int.Parse(kList.ToArray());

                while (k > 0)
                {
                    for (int j = 0; j < strList.Count; j++)
                        stack.Push(strList[j]);
                    k--;
                }
            }
            else
            {
                stack.Push(cs[i]);
            }
        }

        var sb = new StringBuilder();
        while (stack.Count != 0)
            sb.Append(stack.Pop());
        
        return new string(sb.ToString().Reverse().ToArray());
    }
}
