
// Definition for an Interval.
public class Interval
{
    public int start;
    public int end;

    public Interval() { }
    public Interval(int _start, int _end)
    {
        start = _start;
        end = _end;
    }
}


public class Solution
{
    // Sorting + Merging
    // Time: O(n log n)
    // Space: O(n)
    public IList<Interval> EmployeeFreeTime(IList<IList<Interval>> schedule)
    {
        // edge case
        if (schedule == null || schedule.Count == 0)
            return new List<Interval>();

        // add all intervals into a list
        var allIntervals = new List<Interval>();
        foreach (List<Interval> employSchedule in schedule)
        {
            allIntervals.AddRange(employSchedule);
        }
        // sort the list by start
        allIntervals.Sort((a, b) => a.start - b.start);

        // iterate through the list and merge intervals
        var mergedIntervals = new List<Interval>();
        mergedIntervals.Add(allIntervals[0]);
        for (int i = 1; i < allIntervals.Count; i++)
        {
            var prevInterval = mergedIntervals.Last();
            int prevStart = prevInterval.start;
            int prevEnd = prevInterval.end;
            var currInterval = allIntervals[i];
            int currStart = currInterval.start;
            int currEnd = currInterval.end;
            // overlapped, merge
            if (currStart <= prevEnd)
            {
                mergedIntervals.Last().end = Math.Max(prevEnd, currEnd);
            }
            else // add to the list
            {
                mergedIntervals.Add(currInterval);
            }
        }

        // interate trhough the merged list
        // find all the available intervals
        var result = new List<Interval>();
        if (mergedIntervals.Count == 1)
        {
            return result;
        }

        for (int i = 1; i < mergedIntervals.Count; i++)
        {
            var prevInterval = mergedIntervals[i - 1];
            int prevEnd = prevInterval.end;
            var currInterval = mergedIntervals[i];
            int currStart = currInterval.start;
            result.Add(new Interval(prevEnd, currStart));
        }

        return result;
    }
}


var s = new Solution();
var schedule = new List<IList<Interval>>
{
    new List<Interval>(){new Interval(1, 2), new Interval(5,6)},
    new List<Interval>(){new Interval(1,3)},
    new List<Interval>(){new Interval(4,10)},
};

var result = s.EmployeeFreeTime(schedule);
Console.WriteLine(result);
