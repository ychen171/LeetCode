public class Solution
{
    // Brute force
    // Time: O(rows * cols)
    // Space: O(1)
    public int WordsTyping(string[] sentence, int rows, int cols)
    {
        int answer = 0;
        int sentenceLen = sentence.Length;
        int rowIndex = 0, colIndex = 0;
        int wordIndex = 0;
        while (rowIndex < rows)
        {
            var word = sentence[wordIndex];
            var wordLen = word.Length;

            if (colIndex != 0) wordLen++;
            Console.WriteLine($"row: {rowIndex}, col: {colIndex}");
            Console.WriteLine($"wordLen: {wordLen}");
            Console.WriteLine($"colIndex + wordLen = {colIndex + wordLen} vs cols = {cols}");
            if (colIndex + wordLen <= cols)
            {
                Console.WriteLine($"row: {rowIndex}, col: {colIndex}, word: {word}");
                colIndex += wordLen;
                wordIndex++;
                if (wordIndex == sentenceLen)
                {
                    answer++;
                    wordIndex = 0;
                }
            }
            else
            {
                rowIndex++;
                colIndex = 0;
            }
        }

        return answer;
    }

    // Greedy
    // Time: O(m * rows)
    // m: length of sentence by char
    // Space: O(m)
    public int WordsTyping1(string[] sentence, int rows, int cols)
    {
        var wholeSentence = string.Join(" ", sentence) + " ";
        int len = wholeSentence.Length;
        int count = 0;
        int[] map = new int[len];
        for (int i = 1; i < len; i++)
        {
            map[i] = wholeSentence[i] == ' ' ? 1 : map[i - 1] - 1;
        }
        for (int i = 0; i < rows; i++)
        {
            count += cols;
            count += map[count % len];
        }

        return count / len;
    }
}

var s = new Solution();
Console.WriteLine(s.WordsTyping(new string[] { "a", "bcd", "e" }, 3, 6));
Console.WriteLine(s.WordsTyping(new string[] { "i", "had", "apple", "pie" }, 4, 5));
