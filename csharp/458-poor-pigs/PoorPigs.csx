public class Solution
{
    // Math
    // Time: O(1)
    // Space: O(1)
    public int PoorPigs(int buckets, int minutesToDie, int minutesToTest)
    {
        /* if one pig has two avaiable states: 1. alive 2. dead after first test
            x pigs can test 2^x buckets
        
            if one pig has s avaiable states: 1. alive 2. dead after first test 3. dead after second test, ... n+1. dead after n test
            x pigs can test s^x buckets

            find mininum x so that
                s^x >= buckets
                s = minutesToTest / minutesToDie + 1
            
            x >= log buckets / log s
        */
        int states = minutesToTest / minutesToDie + 1;
        return (int)Math.Ceiling(Math.Log(buckets) / Math.Log(states));
    }
}
