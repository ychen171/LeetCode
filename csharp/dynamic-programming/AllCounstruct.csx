
// Brute force recursion
// m = target.Length
// n = words.Length
// Time: O(n^m)
// Space: O(m)
public List<List<string>> AllConstruct(string target, string[] words)
{
    if (string.IsNullOrEmpty(target))
    {
        var newMatrix = new List<List<string>>();
        newMatrix.Add(new List<string>());
        return newMatrix; // [[]]
    }

    List<List<string>> result = new List<List<string>>(); // []

    foreach (var word in words)
    {
        if (target.EndsWith(word))
        {
            string remainder = target.Remove(target.Length - word.Length, word.Length);
            List<List<string>> remainResult = AllConstruct(remainder, words);
            remainResult.ForEach(list => list.Add(word));
            result.AddRange(remainResult);
        }
    }

    return result;
}

// Memoized recursion ??? doesn't pass some test cases
// m = target.Length
// n = words.Length
// Time: O(n*m)
// Space: O(m)
public List<List<string>> AllConstruct(string target, string[] words, Dictionary<string, List<List<string>>> memo)
{
    if (memo.ContainsKey(target)) return memo[target];
    if (string.IsNullOrEmpty(target))
    {
        var newMatrix = new List<List<string>>();
        newMatrix.Add(new List<string>());
        return newMatrix; // [[]]
    }

    List<List<string>> result = new List<List<string>>(); // []

    foreach (var word in words)
    {
        if (target.EndsWith(word))
        {
            string remainder = target.Remove(target.Length - word.Length, word.Length);
            List<List<string>> remainResult = AllConstruct(remainder, words, memo);
            remainResult.ForEach(list => list.Add(word));
            result.AddRange(remainResult);
        }
    }

    memo[target] = result;
    return result;
}


// Tabulation Iteration
// m = target.Length
// n = words.Length
// Time: O(n^m)
// Space: O(n^m)
public List<List<string>> AllConstructTabulation(string target, string[] words)
{
    var table = new List<List<List<string>>>();
    // initialize table with default value
    for (int i = 0; i <= target.Length; i++)
        table.Add(new List<List<string>>());
    // seed the trivial answer into the table
    table[0].Add(new List<string>());
    // fill further positions with current position
    for (int i = 0; i <= target.Length; i++)
    {
        if (table[i].Count != 0)
        {
            foreach (var word in words)
            {
                var nextIndex = i + word.Length;
                if (nextIndex <= target.Length)
                {
                    if (target.Substring(i).StartsWith(word))
                    {
                        // deep copy the list of lists at position i
                        // and add word into every sub list
                        var newCombinations = new List<List<string>>();
                        foreach (var list in table[i])
                        {
                            newCombinations.Add(new List<string>(list));
                            newCombinations.Last().Add(word);
                        }
                        // append the list of lists to the new position
                        table[nextIndex].AddRange(newCombinations);
                    }
                }
            }
        }
    }

    return table[target.Length];
}


public string ToString(List<List<string>> listMatrix)
{
    if (listMatrix == null) return "null";
    var sb = new StringBuilder();
    sb.Append("[");
    foreach (var list in listMatrix)
    {
        sb.Append("[");
        foreach (var item in list)
        {
            sb.Append(item + ", ");
        }
        sb.Append("], ");
    }
    sb.Append("]");
    return sb.ToString();
}


Console.WriteLine("Running AllConstruct");
var stopwatch1 = new Stopwatch();
stopwatch1.Start();
Console.WriteLine(ToString(AllConstruct("hello", new string[] { "cat", "dog", "mouse" }))); // []
Console.WriteLine(ToString(AllConstruct("", new string[] { "cat", "dog", "mouse" }))); // [[]]
Console.WriteLine(ToString(AllConstruct("purple", new string[] { "purp", "p", "ur", "le", "purpl" }))); // 2
Console.WriteLine(ToString(AllConstruct("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd", "ef", "c" }))); // 4
Console.WriteLine(ToString(AllConstruct("skateboard", new string[] { "bo", "rd", "ate", "ska", "sk", "boar" }))); // 0
Console.WriteLine(ToString(AllConstruct("enterapotentpot", new string[] { "a", "p", "ent", "enter", "ot", "o", "t" }))); // 4
Console.WriteLine(ToString(AllConstruct("eeeeeeeeeeeeeeeeeeeeeeeeef", new string[] { "e", "ee", "eee", "eeee", "eeeee", "eeeeee" }))); // 0
stopwatch1.Stop();
Console.WriteLine(stopwatch1.ElapsedTicks);


Console.WriteLine("Running AllConstructMemo");
var stopwatch2 = new Stopwatch();
stopwatch2.Start();
Console.WriteLine(ToString(AllConstruct("hello", new string[] { "cat", "dog", "mouse" }, new Dictionary<string, List<List<string>>>()))); // []
Console.WriteLine(ToString(AllConstruct("", new string[] { "cat", "dog", "mouse" }, new Dictionary<string, List<List<string>>>()))); // [[]]
Console.WriteLine(ToString(AllConstruct("purple", new string[] { "purp", "p", "ur", "le", "purpl" }, new Dictionary<string, List<List<string>>>()))); // 2
Console.WriteLine(ToString(AllConstruct("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd", "ef", "c" }, new Dictionary<string, List<List<string>>>()))); // 4
Console.WriteLine(ToString(AllConstruct("skateboard", new string[] { "bo", "rd", "ate", "ska", "sk", "boar" }, new Dictionary<string, List<List<string>>>()))); // 0
Console.WriteLine(ToString(AllConstruct("enterapotentpot", new string[] { "a", "p", "ent", "enter", "ot", "o", "t" }, new Dictionary<string, List<List<string>>>()))); // 4
Console.WriteLine(ToString(AllConstruct("eeeeeeeeeeeeeeeeeeeeeeeeef", new string[] { "e", "ee", "eee", "eeee", "eeeee", "eeeeee" }, new Dictionary<string, List<List<string>>>()))); // 0
stopwatch2.Stop();
Console.WriteLine(stopwatch2.ElapsedTicks);


Console.WriteLine("Running AllConstructTabulation");
var stopwatch3 = new Stopwatch();
stopwatch3.Start();
Console.WriteLine(ToString(AllConstructTabulation("hello", new string[] { "cat", "dog", "mouse" }))); // []
Console.WriteLine(ToString(AllConstructTabulation("", new string[] { "cat", "dog", "mouse" }))); // [[]]
Console.WriteLine(ToString(AllConstructTabulation("purple", new string[] { "purp", "p", "ur", "le", "purpl" }))); // 2
Console.WriteLine(ToString(AllConstructTabulation("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd", "ef", "c" }))); // 4
Console.WriteLine(ToString(AllConstructTabulation("skateboard", new string[] { "bo", "rd", "ate", "ska", "sk", "boar" }))); // 0
Console.WriteLine(ToString(AllConstructTabulation("enterapotentpot", new string[] { "a", "p", "ent", "enter", "ot", "o", "t" }))); // 4
Console.WriteLine(ToString(AllConstructTabulation("eeeeeeeeeeeeeeeeeeeeeeeeef", new string[] { "e", "ee", "eee", "eeee", "eeeee", "eeeeee" }))); // 0
stopwatch3.Stop();
Console.WriteLine(stopwatch3.ElapsedTicks);



