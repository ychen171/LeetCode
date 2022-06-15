public class SnapshotArray
{
    // Space: O(N) ~ O(M * N)
    // N is the length of array
    // M is the total numebr of snap calls
    List<int>[] vals;
    int currId;
    public SnapshotArray(int length)
    {
        vals = new List<int>[length];
        currId = 0;
    }

    // Time: O(M)
    // M is the total number of snap calls
    public void Set(int index, int val)
    {
        if (index >= vals.Length)
            return;

        if (vals[index] == null)
            vals[index] = new List<int>();
        var history = vals[index];
        var lastId = history.Count - 1;
        if (lastId == currId) // history contains currId, alter val at currId
        {
            history[lastId] = val;
        }
        else // history doesn't contain currId, fill the history and add val at currId
        {
            if (lastId == -1) // no previous version, fill history with 0 val
            {
                for (int i = 0; i < currId; i++)
                    history.Add(0);
            }
            else // fill history with the last val
            {
                for (int i = lastId + 1; i < currId; i++)
                    history.Add(history[lastId]);
            }
            // add val at currId
            history.Add(val);
        }
    }

    // Time: O(1)
    public int Snap()
    {
        return currId++;
    }

    // Time: O(1)
    public int Get(int index, int snap_id)
    {
        if (snap_id > currId)
            return 0;
        if (index >= vals.Length)
            return 0;
        if (vals[index] == null)
            return 0;
        var history = vals[index];
        var lastId = history.Count - 1; // lastId <= currId
        // [lastId, currId]
        if (lastId == -1)
            return 0;

        return history[Math.Min(lastId, snap_id)];
    }
}

/**
 * Your SnapshotArray object will be instantiated and called as such:
 * SnapshotArray obj = new SnapshotArray(length);
 * obj.Set(index,val);
 * int param_2 = obj.Snap();
 * int param_3 = obj.Get(index,snap_id);
 */

var s = new SnapshotArray(3);
s.Set(0, 5);
Console.WriteLine(s.Snap());
s.Set(0, 6);
Console.WriteLine(s.Get(0, 0));


// var s1 = new SnapshotArray(4);
// Console.WriteLine(s1.Snap());
// Console.WriteLine(s1.Snap());
// Console.WriteLine(s1.Get(3, 1));
// s1.Set(2, 4);
// Console.WriteLine(s1.Snap());
// s1.Set(1, 4);