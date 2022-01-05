

public string ReverseString(string input)
{
    // what is the base case?
    if (string.IsNullOrEmpty(input)) return string.Empty;
    // what is the smallest amount of work I can do in each iteration?
    return ReverseString(input.Substring(1)) + input[0];
}


Console.WriteLine(ReverseString("abc"));

public string FindBinary(int num, string result)
{
    if (num == 0) return result;
    result = num % 2 + result;
    return FindBinary(num / 2, result);
}

Console.WriteLine(FindBinary(233, ""));


public int RecursiveSummation(int num)
{
    if (num <= 1) return num;
    return num + RecursiveSummation(num - 1);
}

Console.WriteLine(RecursiveSummation(10));





