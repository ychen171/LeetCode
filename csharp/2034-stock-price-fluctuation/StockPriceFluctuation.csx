public class StockPrice
{
    Dictionary<int, int> timePriceDict;
    SortedDictionary<int, int> priceTimeDict;
    int maxTimestamp;
    public StockPrice()
    {
        timePriceDict = new Dictionary<int, int>();
        priceTimeDict = new SortedDictionary<int, int>();
        maxTimestamp = -1;
    }

    // Time: O(log n)
    // Space: O(n)
    public void Update(int timestamp, int price)
    {
        // update existing
        if (timePriceDict.ContainsKey(timestamp))
        {
            int existingPrice = timePriceDict[timestamp];

            priceTimeDict[existingPrice]--;
            if (priceTimeDict[existingPrice] == 0)
                priceTimeDict.Remove(existingPrice);

            priceTimeDict[price] = priceTimeDict.GetValueOrDefault(price, 0) + 1;
            timePriceDict[timestamp] = price;
        }
        else // add new
        {
            priceTimeDict[price] = priceTimeDict.GetValueOrDefault(price, 0) + 1;
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
        return priceTimeDict.Keys.Last();
    }

    public int Minimum()
    {
        return priceTimeDict.Keys.First();
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
