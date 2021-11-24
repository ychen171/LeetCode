public class Solution
{
    public char NextGreatestLetter(char[] letters, char target)
    {
        var range = SearchRange(letters, target);
        var selectedIndex = range[1];
        if (letters[selectedIndex] > target)
            return letters[selectedIndex];
        else
            return selectedIndex == letters.Length - 1 ? letters[0] : letters[selectedIndex + 1];
    }

    public int[] SearchRange(char[] letters, char target)
    {
        var range = new int[] { 0, 0 };

        // search for the left one
        int left = 0;
        int right = letters.Length - 1;
        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (letters[mid] < target)
                left = mid + 1;
            else
                right = mid;
        }
        range[0] = left;

        // search for the right one
        right = letters.Length - 1;
        while (left < right)
        {
            var mid = left + (right - left) / 2 + 1;
            if (letters[mid] > target)
                right = mid - 1;
            else
                left = mid;
        }
        range[1] = right;

        return range;
    }

    public char NextGreatestLetter1(char[] letters, char target)
    {
        int left = 0;
        int right = letters.Length - 1;
        while (left < right)
        {
            var mid = left + (right - left) / 2 + 1;
            if (letters[mid] > target)
                right = mid - 1;
            else
                left = mid;
        }

        if (letters[left] > target)
            return letters[left];
        else
            return left == letters.Length - 1 ? letters[0] : letters[left + 1];
    }

    public char NextGreatestLetter2(char[] letters, char target)
    {
        int left = 0;
        int right = letters.Length;
        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (letters[mid] > target)
                right = mid;
            else
                left = mid + 1;
        }

        return letters[left % letters.Length];
    }
}


var s = new Solution();
Console.WriteLine(s.NextGreatestLetter(new char[] { 'c', 'f', 'j' }, 'a'));
Console.WriteLine(s.NextGreatestLetter(new char[] { 'c', 'f', 'j' }, 'c'));
Console.WriteLine(s.NextGreatestLetter(new char[] { 'c', 'f', 'j' }, 'g'));
Console.WriteLine(s.NextGreatestLetter(new char[] { 'c', 'f', 'j' }, 'k'));
Console.WriteLine(s.NextGreatestLetter(new char[] { 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'n', 'n', 'n', 'n', 'n' }, 'e'));

Console.WriteLine(s.NextGreatestLetter1(new char[] { 'c', 'f', 'j' }, 'a'));
Console.WriteLine(s.NextGreatestLetter1(new char[] { 'c', 'f', 'j' }, 'c'));
Console.WriteLine(s.NextGreatestLetter1(new char[] { 'c', 'f', 'j' }, 'g'));
Console.WriteLine(s.NextGreatestLetter1(new char[] { 'c', 'f', 'j' }, 'k'));
Console.WriteLine(s.NextGreatestLetter1(new char[] { 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'n', 'n', 'n', 'n', 'n' }, 'e'));

Console.WriteLine(s.NextGreatestLetter2(new char[] { 'c', 'f', 'j' }, 'a'));
Console.WriteLine(s.NextGreatestLetter2(new char[] { 'c', 'f', 'j' }, 'c'));
Console.WriteLine(s.NextGreatestLetter2(new char[] { 'c', 'f', 'j' }, 'g'));
Console.WriteLine(s.NextGreatestLetter2(new char[] { 'c', 'f', 'j' }, 'k'));
Console.WriteLine(s.NextGreatestLetter2(new char[] { 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'n', 'n', 'n', 'n', 'n' }, 'e'));



