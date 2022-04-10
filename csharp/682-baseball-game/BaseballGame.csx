public class Solution
{
    // Time: O(n)
    // Space: O(n)
    public int CalPoints(string[] ops)
    {
        // list
        // ops = [5, 2, C, D, +]
        // score = 0
        // 5            
        // 5 2
        // 5 2 C
        // 5
        // 5 D     
        // 5 10
        // 5 10 + 
        // 5 10 15

        // score = sum(list)

        var list = new List<int>();
        for (int i = 0; i < ops.Length; i++)
        {
            string op = ops[i];
            switch (op)
            {
                case "C":
                    list.RemoveAt(list.Count - 1);
                    break;
                case "D":
                    list.Add(list[list.Count - 1] * 2);
                    break;
                case "+":
                    list.Add(list[list.Count - 1] + list[list.Count - 2]);
                    break;
                default:
                    list.Add(int.Parse(op));
                    break;
            }
        }

        return list.Sum();
    }
}