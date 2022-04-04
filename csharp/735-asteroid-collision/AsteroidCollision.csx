public class Solution
{
    // Stack
    // Time: O(n)
    // Space: O(n)
    public int[] AsteroidCollision(int[] asteroids)
    {
        // Stack: contains the remaining asteroids so far 
        var stack = new Stack<int>();
        int n = asteroids.Length;
        for (int i = 0; i < n; i++)
        {
            var curr = asteroids[i];
            while (stack.Count != 0 && curr * stack.Peek() < 0 && curr < 0)
            {
                var top = stack.Peek();
                var absTop = Math.Abs(top);
                var absCurr = Math.Abs(curr);
                if (absCurr > absTop)
                {
                    stack.Pop();
                    continue;
                }
                else if (absCurr == absTop)
                {
                    stack.Pop();
                    curr = 0;
                    break;
                }
                else
                {
                    curr = 0;
                    break;
                }
            }
            if (curr != 0)
                stack.Push(curr);
        }

        return stack.Reverse().ToArray();
    }
}
