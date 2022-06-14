public class StockPrice
{
    Dictionary<int, int> timePriceDict;
    SortedList<int, int> priceTimeList;
    int maxTimestamp;
    public StockPrice()
    {
        timePriceDict = new Dictionary<int, int>();
        priceTimeList = new SortedList<int, int>();
        maxTimestamp = -1;
    }

    public void Update(int timestamp, int price)
    {
        // update existing
        if (timePriceDict.ContainsKey(timestamp))
        {
            int existingPrice = timePriceDict[timestamp];

            priceTimeList[existingPrice]--;
            if (priceTimeList[existingPrice] == 0)
                priceTimeList.Remove(existingPrice);

            priceTimeList[price] = priceTimeList.GetValueOrDefault(price, 0) + 1;
            timePriceDict[timestamp] = price;
        }
        else // add new
        {
            priceTimeList[price] = priceTimeList.GetValueOrDefault(price, 0) + 1;
            timePriceDict[timestamp] = price;
        }

        maxTimestamp = Math.Max(maxTimestamp, timestamp);
    }

    public int Current()
    {
        return timePriceDict[maxTimestamp];
    }

    public int Maximum()
    {
        return priceTimeList.Keys.Last();
    }

    public int Minimum()
    {
        return priceTimeList.Keys.First();
    }
}

/**
 * Your StockPrice object will be instantiated and called as such:
 * StockPrice obj = new StockPrice();
 * obj.Update(timestamp,price);
 * int param_2 = obj.Current();
 * int param_3 = obj.Maximum();
 * int param_4 = obj.Minimum();
 */
