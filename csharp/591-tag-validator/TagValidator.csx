public class Solution
{
    // Stack
    // Time: O(n)
    // Space: O(n)
    Stack<string> stack = new Stack<string>();
    bool containsTag = false;

    public bool IsValid(string code)
    {
        // <DIV>>>  ![cdata[]] <![CDATA[<div>]>]]>]]>>]</DIV>
        // <DIV>   >>  ![cdata[]] <![CDATA[<div>]>]]>]]>>]      </DIV>

        // <DIV>
        // >>  ![cdata[]] 
        // <![CDATA[
        // <div>]>
        // ]]>
        // ]]>>]
        // </DIV>

        // find <A> and </A> pair

        int n = code.Length;
        // edge case
        if (code[0] != '<' || code[n - 1] != '>')
            return false;

        for (int i = 0; i < n; i++)
        {
            bool ending = false;
            int closeIndex = 0;
            if (stack.Count == 0 && containsTag)
                return false;

            if (code[i] == '<')
            {
                if (stack.Count != 0 && code[i + 1] == '!') // check if it is valid cdata
                {
                    closeIndex = code.IndexOf("]]>", i + 1); // find the close index for cdata
                    if (closeIndex < 0 || !IsValidCData(code.Substring(i + 2, closeIndex - (i + 2))))
                        return false;
                }
                else // it is either start tag or end tag
                {
                    if (code[i + 1] == '/') // check if it is end tag
                    {
                        i++;
                        ending = true;
                    }
                    closeIndex = code.IndexOf('>', i + 1); // find the close index for tag
                    if (closeIndex < 0 || !IsValidTagName(code.Substring(i + 1, closeIndex - (i + 1)), ending))
                        return false;
                }
                i = closeIndex;
            }
        }

        return stack.Count == 0 && containsTag;
    }

    public bool IsValidTagName(string s, bool ending)
    {
        int n = s.Length;
        if (n < 1 || n > 9)
            return false;

        for (int i = 0; i < n; i++)
        {
            char c = s[i];
            if (!char.IsUpper(c))
                return false;
        }
        if (ending)
        {
            if (stack.Count != 0 && stack.Peek() == s)
                stack.Pop();
            else
                return false;
        }
        else // starting
        {
            containsTag = true;
            stack.Push(s);
        }

        return true;
    }

    public bool IsValidCData(string s)
    {
        return s.IndexOf("[CDATA[") == 0;
    }

}

var s = new Solution();
var code = "<DIV>>>  ![cdata[]] <![CDATA[<div>]>]]>]]>>]</DIV>";
var result = s.IsValid(code);
Console.WriteLine(result);
