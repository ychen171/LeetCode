

// Brute force recursion
// m = target.Length
// n = words.Length
// Time: O(n^m * m)
// Space: O(m * m)
public int CountConstruct(string target, string[] words)
{
    if (string.IsNullOrEmpty(target)) return 1;

    int result = 0;
    foreach (var word in words)
    {
        // if target starts/ends with word, remove word from target and call the function again
        if (target.StartsWith(word))
        {
            var remainder = target.Remove(0, word.Length);
            result += CountConstruct(remainder, words);
        }
    }

    return result;
}

var stopwatch1 = new Stopwatch();
stopwatch1.Start();
Console.WriteLine(CountConstruct("purple", new string[] { "purp", "p", "ur", "le", "purpl" })); // 2
Console.WriteLine(CountConstruct("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd" })); // 1
Console.WriteLine(CountConstruct("skateboard", new string[] { "bo", "rd", "ate", "ska", "sk", "boar" })); // 0
Console.WriteLine(CountConstruct("enterapotentpot", new string[] { "a", "p", "ent", "enter", "ot", "o", "t" })); // 4
Console.WriteLine(CountConstruct("eeeeeeeeeeeeeeeeeeeeeeeeef", new string[] { "e", "ee", "eee", "eeee", "eeeee", "eeeeee" })); // 0
stopwatch1.Stop();
Console.WriteLine(stopwatch1.ElapsedTicks);


// Memoized recursion
// m = target.Length
// n = words.Length
// Time: O(n*m * m)
// Space: O(m * m)
public int CountConstruct(string target, string[] words, Dictionary<string, int> memo)
{
    if (memo.ContainsKey(target)) return memo[target];
    if (string.IsNullOrEmpty(target)) return 1;

    int result = 0;
    foreach (var word in words)
    {
        // if target starts/ends with word, remove word from target and call the function again
        if (target.StartsWith(word))
        {
            var remainder = target.Remove(0, word.Length);
            result += CountConstruct(remainder, words, memo);
        }
    }

    memo[target] = result;
    return result;
}

var stopwatch2 = new Stopwatch();
stopwatch2.Start();
Console.WriteLine(CountConstruct("purple", new string[] { "purp", "p", "ur", "le", "purpl" }, new Dictionary<string, int>())); // 2
Console.WriteLine(CountConstruct("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd" }, new Dictionary<string, int>())); // 1
Console.WriteLine(CountConstruct("skateboard", new string[] { "bo", "rd", "ate", "ska", "sk", "boar" }, new Dictionary<string, int>())); // 0
Console.WriteLine(CountConstruct("enterapotentpot", new string[] { "a", "p", "ent", "enter", "ot", "o", "t" }, new Dictionary<string, int>())); // 4
Console.WriteLine(CountConstruct("eeeeeeeeeeeeeeeeeeeeeeeeef", new string[] { "e", "ee", "eee", "eeee", "eeeee", "eeeeee" }, new Dictionary<string, int>())); // 0
stopwatch2.Stop();
Console.WriteLine(stopwatch2.ElapsedTicks);


// Tabulation Iteration
// m = target.Length
// n = words.Length
// Time: O(m*n*m)
// Space: O(m)
public int CountConstructTabulation(string target, string[] words)
{
    var table = new List<int>();
    // initialize the table with default value
    for (int i = 0; i <= target.Length; i++)
        table.Add(0);
    // seed the trivial answer into the table
    table[0] = 1;
    // fill further positions with current position
    for (int i = 0; i <= target.Length; i++)
    {
        if (table[i] > 0)
        {
            foreach (var word in words)
            {
                var nextIndex = i + word.Length;
                if (nextIndex <= target.Length)
                {
                    if (target.Substring(i).StartsWith(word))
                        table[nextIndex] += table[i];
                }
            }
        }
    }

    return table[target.Length];
}

var stopwatch3 = new Stopwatch();
stopwatch3.Start();
Console.WriteLine(CountConstructTabulation("purple", new string[] { "purp", "p", "ur", "le", "purpl" })); // 2
Console.WriteLine(CountConstructTabulation("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd" })); // 1
Console.WriteLine(CountConstructTabulation("skateboard", new string[] { "bo", "rd", "ate", "ska", "sk", "boar" })); // 0
Console.WriteLine(CountConstructTabulation("enterapotentpot", new string[] { "a", "p", "ent", "enter", "ot", "o", "t" })); // 4
Console.WriteLine(CountConstructTabulation("eeeeeeeeeeeeeeeeeeeeeeeeef", new string[] { "e", "ee", "eee", "eeee", "eeeee", "eeeeee" })); // 0
stopwatch3.Stop();
Console.WriteLine(stopwatch3.ElapsedTicks);


