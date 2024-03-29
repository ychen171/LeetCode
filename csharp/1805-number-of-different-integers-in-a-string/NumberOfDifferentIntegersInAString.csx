public class Solution
{
    // Two Pointers + HashSet
    // Time: O(n)
    // Space: O(n)
    public int NumDifferentIntegers(string word)
    {
        // Two Pointers + HashSet
        // i = 0, j = 0, s = "", set = {}
        // i = 1, j = 1, letter -> digit
        // i = 1, j = 4, digit -> letter, s = "123", set = {123, }
        // i = 6, j = 6, letter -> digit
        // i = 6, j = 8, digit -> letter, s = "34", set {123, 34}
        int i = 0;
        int j = 0;
        var set = new HashSet<string>();
        int n = word.Length;
        bool prevDigit = false;
        bool currDigit = false;
        for (j = 0; j < n; j++)
        {
            char c = word[j];
            currDigit = char.IsDigit(c);
            if (!prevDigit && currDigit)
            {
                i = j;
            }
            else if (prevDigit && !currDigit)
            {
                while (i < j && word[i] == '0')
                    i++;
                set.Add(word.Substring(i, j - i));
            }

            prevDigit = currDigit;
        }

        if (currDigit)
        {
            while (i < j && word[i] == '0')
                i++;
            set.Add(word.Substring(i, j - i));
        }

        return set.Count;
    }
}

var s = new Solution();
string word = "2393706880236110407059624696967828762752651982730115221690437821508229419410771541532394006597463715513741725852432559057224478815116557380260390432211227579663571046845842281704281749571110076974264971989893607137140456254346955633455446057823738757323149856858154529105301197388177242583658641529908583934918768953462557716z97438020429952944646288084173334701047574188936201324845149110176716130267041674438237608038734431519439828191344238609567530399189316846359766256507371240530620697102864238792350289978450509162697068948604722646739174590530336510475061521094503850598453536706982695212493902968251702853203929616930291257062173c79487281900662343830648295410";
var result = s.NumDifferentIntegers(word);
Console.WriteLine(result);
