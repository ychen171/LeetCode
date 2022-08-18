public class Solution
{
    // Math | Sum the products from all pairs of digits
    // Time: O(n1 * n2)
    // Space: O(n1 + n2)
    public string Multiply(string num1, string num2)
    {
        int n1 = num1.Length;
        int n2 = num2.Length;
        var result = new int[n1 + n2];
        for (int i = n1 - 1; i >= 0; i--)
        {
            for (int j = n2 - 1; j >= 0; j--)
            {
                int d1 = num1[i] - '0';
                int d2 = num2[j] - '0';
                int mul = d1 * d2;
                int p1 = i + j;
                int p2 = i + j + 1;
                int sum = result[p2] + mul;
                result[p2] = sum % 10;
                result[p1] = result[p1] + sum / 10;
            }
        }
        // convert int array to string
        int k = 0;
        while (k < result.Length && result[k] == 0)
            k++;
        var sb = new StringBuilder();
        while (k < result.Length)
        {
            sb.Append(result[k]);
            k++;
        }

        return sb.Length == 0 ? "0" : sb.ToString();
    }
}
