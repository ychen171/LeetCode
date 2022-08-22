public class ExamRoom
{
    // OrderedSet | SortedSet
    // Space: O(n)
    private int N;
    private Dictionary<int, int[]> startMap;
    private Dictionary<int, int[]> endMap;
    private SortedSet<int[]> ss;
    public ExamRoom(int n)
    {
        this.N = n;
        startMap = new Dictionary<int, int[]>();
        endMap = new Dictionary<int, int[]>();
        ss = new SortedSet<int[]>(new MyComparer(n));
        // intv = [x, y]
        AddInterval(new int[] { -1, N });
    }

    // Time: O(log n)
    public int Seat()
    {
        var longest = ss.Last();
        int x = longest[0];
        int y = longest[1];
        int seat;
        if (x == -1)
            seat = 0;
        else if (y == N)
            seat = N - 1;
        else
            seat = (y - x) / 2 + x;

        var left = new int[] { x, seat };
        var right = new int[] { seat, y };
        RemoveInterval(longest);
        AddInterval(left);
        AddInterval(right);
        return seat;
    }

    // Time: O(log n)
    public void Leave(int p)
    {
        var right = startMap[p];
        var left = endMap[p];
        var merged = new int[] { left[0], right[1] };
        RemoveInterval(left);
        RemoveInterval(right);
        AddInterval(merged);
    }

    private void AddInterval(int[] intv)
    {
        ss.Add(intv);
        startMap[intv[0]] = intv;
        endMap[intv[1]] = intv;
    }

    private void RemoveInterval(int[] intv)
    {
        ss.Remove(intv);
        startMap.Remove(intv[0]);
        endMap.Remove(intv[1]);
    }


}

public class MyComparer : IComparer<int[]>
{
    private int N;
    public MyComparer(int n)
    {
        this.N = n;
    }
    public int Compare(int[] a, int[] b)
    {
        int distA = Distance(a);
        int distB = Distance(b);
        if (distA == distB)
            return b[0] - a[0];
        return distA - distB;
    }
    private int Distance(int[] intv)
    {
        int x = intv[0];
        int y = intv[1];
        if (x == -1 || y == N) return y - x - 1;
        return (y - x) / 2;
    }
}

/**
 * Your ExamRoom object will be instantiated and called as such:
 * ExamRoom obj = new ExamRoom(n);
 * int param_1 = obj.Seat();
 * obj.Leave(p);
 */

var obj = new ExamRoom(10);
Console.WriteLine(obj.Seat());
Console.WriteLine(obj.Seat());
Console.WriteLine(obj.Seat());
Console.WriteLine(obj.Seat());
obj.Leave(4);
Console.WriteLine(obj.Seat());

