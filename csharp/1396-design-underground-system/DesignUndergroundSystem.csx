public class UndergroundSystem
{
    // Space: O(S^2 + P)
    // S = the numbers of stations
    // P = the number of passengers during peak time
    Dictionary<int, List<KeyValuePair<string, int>>> idStationTimeDict;
    Dictionary<string, KeyValuePair<int, int>> travelTimeDict;
    public UndergroundSystem()
    {
        idStationTimeDict = new Dictionary<int, List<KeyValuePair<string, int>>>();
        travelTimeDict = new Dictionary<string, KeyValuePair<int, int>>();
    }

    // Time: O(1)
    public void CheckIn(int id, string stationName, int t)
    {
        idStationTimeDict[id] = new List<KeyValuePair<string, int>>();
        idStationTimeDict[id].Add(new KeyValuePair<string, int>(stationName, t));
    }

    // Time: O(1)
    public void CheckOut(int id, string stationName, int t)
    {
        idStationTimeDict[id].Add(new KeyValuePair<string, int>(stationName, t));
        var timeList = idStationTimeDict[id];
        string travelKey = $"{timeList[0].Key},{timeList[1].Key}";
        int time = timeList[1].Value - timeList[0].Value;

        if (!travelTimeDict.ContainsKey(travelKey))
            travelTimeDict[travelKey] = new KeyValuePair<int, int>(0, 0);
        int totalTime = travelTimeDict[travelKey].Key;
        int totalTrips = travelTimeDict[travelKey].Value;
        travelTimeDict[travelKey] = new KeyValuePair<int, int>(totalTime + time, totalTrips + 1);
    }

    // Time: O(1)
    public double GetAverageTime(string startStation, string endStation)
    {
        string travelKey = $"{startStation},{endStation}";
        double totalTime = travelTimeDict[travelKey].Key;
        double totalTrips = travelTimeDict[travelKey].Value;
        return totalTime / totalTrips;
    }
}

/**
 * Your UndergroundSystem object will be instantiated and called as such:
 * UndergroundSystem obj = new UndergroundSystem();
 * obj.CheckIn(id,stationName,t);
 * obj.CheckOut(id,stationName,t);
 * double param_3 = obj.GetAverageTime(startStation,endStation);
 */