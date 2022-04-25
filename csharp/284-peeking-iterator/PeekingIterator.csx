// C# IEnumerator interface reference:
// https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerator?view=netframework-4.8


// Time: O(1)
// Space: O(1)
class PeekingIterator
{
    IEnumerator<int> iterator;
    bool isNext;
    // iterators refers to the first element of the array.
    public PeekingIterator(IEnumerator<int> iterator)
    {
        // initialize any member here.
        this.iterator = iterator;
        this.iterator.Reset();
        this.isNext = false;
    }

    // Returns the next element in the iteration without advancing the iterator.
    public int Peek()
    {
        if (HasNext())
        {
            return iterator.Current;
        }
        else
        {
            return -1;
        }
    }

    // Returns the next element in the iteration and advances the iterator.
    public int Next()
    {
        if (HasNext())
        {
            isNext = false;
            return iterator.Current;
        }
        else
        {
            return -1;
        }
    }

    // Returns false if the iterator is refering to the end of the array of true otherwise.
    public bool HasNext()
    {
        if (isNext)
            return true;
        else
        {
            if (iterator.MoveNext())
            {
                isNext = true;
                return true;
            }
            else
                return false;
        }
    }
}
