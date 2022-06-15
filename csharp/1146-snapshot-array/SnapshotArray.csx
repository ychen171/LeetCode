public class SnapshotArray
{
    // Space: O(N * M)
    // N is the length of the array
    // M is the total number of snap calls
    int[] vals;
    IList<int[]> snapList;
    public SnapshotArray(int length)
    {
        vals = new int[length];
        snapList = new List<int[]>();
    }

    public void Set(int index, int val)
    {
        if (index >= vals.Length)
            return;
        vals[index] = val;
    }

    // Time: O(N)
    // N is the length of the array
    public int Snap()
    {
        var valsCopy = new int[vals.Length];
        Array.Copy(vals, valsCopy, vals.Length);
        snapList.Add(valsCopy);
        return snapList.Count - 1;
    }

    // Time: O(1)
    public int Get(int index, int snap_id)
    {
        if (snap_id >= snapList.Count)
            return -1;
        if (index >= snapList[snap_id].Length)
            return -1;

        return snapList[snap_id][index];
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
// Console.WriteLine();