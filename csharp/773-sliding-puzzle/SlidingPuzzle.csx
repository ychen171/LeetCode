public class Solution
{
    // BFS
    // Time: O((r*c) * (r*c)!)
    // Space: O((r*c) * (r*c)!)
    public int SlidingPuzzle(int[][] board)
    {
        var queue = new Queue<int[]>(); // element is 1d board
        var visited = new HashSet<int>();
        // start from current board
        var nums = new int[6];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int index = i * 3 + j;
                nums[index] = board[i][j];
            }
        }

        // BFS
        int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
        queue.Enqueue(nums);
        visited.Add(GetHashCode(nums));

        int move = 0;
        while (queue.Count != 0)
        {
            int levelLen = queue.Count;
            for (int i = 0; i < levelLen; i++)
            {
                nums = queue.Dequeue();
                // return answer
                if (IsSolved(nums))
                    return move;

                var index = FindIndexOf(nums, 0);
                var r = index / 3;
                var c = index % 3;
                foreach (var dir in directions)
                {
                    int nr = r + dir[0];
                    int nc = c + dir[1];
                    if (nr < 0 || nr >= 2 || nc < 0 || nc >= 3) // invalid
                        continue;

                    // create new nums
                    var newNums = new int[6];
                    for (int j = 0; j < 6; j++)
                        newNums[j] = nums[j];
                    var newIndex = nr * 3 + nc;
                    Swap(newNums, index, newIndex);

                    var hashCode = GetHashCode(newNums);
                    if (visited.Contains(hashCode)) // visited
                        continue;

                    queue.Enqueue(newNums);
                    visited.Add(hashCode);
                }
            }
            move++;
        }

        return -1;
    }

    private int FindIndexOf(int[] nums, int val)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == val)
                return i;
        }

        return -1;
    }

    private bool IsSolved(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != (i + 1) % 6)
            {
                return false;
            }
        }
        return true;
    }

    private void Swap(int[] nums, int i, int j)
    {
        var temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }

    private int GetHashCode(int[] nums)
    {
        int hashCode = 0;
        foreach (var num in nums)
            hashCode = hashCode * 10 + num;
        return hashCode;
    }
}

var sln = new Solution();
var board = new int[][] { new int[] { 4, 1, 2 }, new int[] { 5, 0, 3 } };
var result = sln.SlidingPuzzle(board);
Console.WriteLine(result);

