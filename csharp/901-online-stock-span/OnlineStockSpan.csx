public class StockSpanner 
{
    Stack<int> stack; // mono decreasing, element is index
    List<int> prices;
    public StockSpanner() 
    {
        stack = new Stack<int>();
        stack.Push(-1);
        prices = new List<int>();
    }
    
    public int Next(int price) 
    {
        prices.Add(price);
        while (stack.Count > 1 && prices[stack.Peek()] <= price)
            stack.Pop();
        int left = stack.Peek();
        int right = prices.Count - 1;
        stack.Push(right);
        return right - left;
    }
}
// Mono Stack
// Time: O(n)
// Space: O(n)

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */
