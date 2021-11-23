// This is ArrayReader's API interface.
// You should not implement it, or speculate about its implementation
class ArrayReader
{
    public int Get(int index) { return 0; }
    public ArrayReader() { }
}


class Solution
{
    // binary search
    public int Search(ArrayReader reader, int target)
    {
        int left = 0;
        int right = 10000 - 1;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            var guess = reader.Get(mid);
            if (guess == target)
                return mid;
            else if (guess < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }

    // set boundaries + binary search
    public int Search2(ArrayReader reader, int target)
    {
        // reader always returns value at index 0
        // early exits when value at index 0 matches
        if (reader.Get(0) == target) return 0;

        // set boundaries
        int right = 1;
        while (reader.Get(right) < target)
        {
            right = right << 1;
        }
        int left = right >> 1;

        // binary search
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            var midValue = reader.Get(mid);
            if (midValue == target)
                return mid;
            else if (midValue < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }
}

