public class Solution
{
    // Greedy
    // Time: O(n)
    // Space: O(1)
    public long MinimumHealth(int[] damage, int armor)
    {
        long ans = 1;
        // edge case
        if (armor == 0)
        {
            foreach (var d in damage)
                ans += d;
            return ans;
        }

        // find the level to use armor
        int n = damage.Length;
        int level = 0;
        int maxD = damage[0];
        for (int i = 0; i < n; i++)
        {
            if (damage[i] > maxD)
            {
                maxD = damage[i];
                level = i;
            }
        }
        // use armor
        damage[level] = Math.Max(0, damage[level] - armor);
        // calcuate ans
        foreach (var d in damage)
            ans += d;

        return ans;
    }

    public long MinimumHealth1(int[] damage, int armor)
    {
        long ans = 1;
        foreach (var d in damage)
            ans += d;

        int maxDamage = damage.Max();
        return ans - maxDamage + Math.Max(0, maxDamage - armor);
    }
}
