

// Brute force recursion
// m = target.Length
// n = words.Length
// Time: O(n^m * m)
// Space: O(m * m)
public bool CanConstruct(string target, string[] words)
{
    if (string.IsNullOrEmpty(target)) return true;

    foreach (var word in words)
    {
        // if target starts/ends with word, remove word from target and call the function again
        if (target.StartsWith(word))
        {
            var remainder = target.Remove(0, word.Length);
            var result = CanConstruct(remainder, words);
            if (result == true)
                return true;
        }
    }
    return false;
}

var stopwatch1 = new Stopwatch();
stopwatch1.Start();
Console.WriteLine(CanConstruct("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd" })); // true
Console.WriteLine(CanConstruct("skateboard", new string[] { "bo", "rd", "ate", "ska", "sk", "boar" })); // false
Console.WriteLine(CanConstruct("enterapotentpot", new string[] { "a", "p", "ent", "enter", "ot", "o", "t" })); // true
Console.WriteLine(CanConstruct("eeeeeeeeeeeeeeeeeeeeeeeeef", new string[] { "e", "ee", "eee", "eeee", "eeeee", "eeeeee" })); // false
stopwatch1.Stop();
Console.WriteLine(stopwatch1.ElapsedTicks);



// Memoized recursion
// m = target.Length
// n = words.Length
// Time: O(n*m * m)
// Time: O(m * m)
public bool CanConstruct(string target, string[] words, Dictionary<string, bool> memo)
{
    if (memo.ContainsKey(target)) return memo[target];
    if (string.IsNullOrEmpty(target)) return true;

    foreach (var word in words)
    {
        // if target starts/ends with str, remove str from target and call the function again
        if (target.StartsWith(word))
        {
            var remainder = target.Remove(0, word.Length);
            var result = CanConstruct(remainder, words, memo);
            if (result == true)
            {
                memo[remainder] = true;
                return true;
            }

        }
    }
    memo[target] = false;
    return false;
}


var stopwatch2 = new Stopwatch();
stopwatch2.Start();
Console.WriteLine(CanConstruct("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd" }, new Dictionary<string, bool>())); // true
Console.WriteLine(CanConstruct("skateboard", new string[] { "bo", "rd", "ate", "ska", "sk", "boar" }, new Dictionary<string, bool>())); // false
Console.WriteLine(CanConstruct("enterapotentpot", new string[] { "a", "p", "ent", "enter", "ot", "o", "t" }, new Dictionary<string, bool>())); // true
Console.WriteLine(CanConstruct("eeeeeeeeeeeeeeeeeeeeeeeeef", new string[] { "e", "ee", "eee", "eeee", "eeeee", "eeeeee" }, new Dictionary<string, bool>())); // false
stopwatch2.Stop();
Console.WriteLine(stopwatch2.ElapsedTicks);


// Tabulation Iteration
// m = target.Length
// n = words.Length
// Time: O(n*m * m)
// Time: O(m)
public bool CanConstructTabulation(string target, string[] words)
{
    var table = new List<bool>();
    // initialize the table with default value
    for (int i = 0; i <= target.Length; i++)
        table.Add(false);
    // seed the trivial answer into the table
    table[0] = true;
    // fill further positions with the current position
    for (int i = 0; i <= target.Length; i++)
    {
        if (table[i] == true)
        {
            foreach (var word in words)
            {
                var nextIndex = i + word.Length;
                if (nextIndex <= target.Length)
                {
                    if (target.Substring(i).StartsWith(word))
                        table[nextIndex] = true;
                }
            }
        }
    }

    return table[target.Length];
}

var stopwatch3 = new Stopwatch();
stopwatch3.Start();
Console.WriteLine(CanConstructTabulation("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd" })); // true
Console.WriteLine(CanConstructTabulation("skateboard", new string[] { "bo", "rd", "ate", "ska", "sk", "boar" })); // false
Console.WriteLine(CanConstructTabulation("enterapotentpot", new string[] { "a", "p", "ent", "enter", "ot", "o", "t" })); // true
Console.WriteLine(CanConstructTabulation("eeeeeeeeeeeeeeeeeeeeeeeeef", new string[] { "e", "ee", "eee", "eeee", "eeeee", "eeeeee" })); // false
stopwatch3.Stop();
Console.WriteLine(stopwatch3.ElapsedTicks);



