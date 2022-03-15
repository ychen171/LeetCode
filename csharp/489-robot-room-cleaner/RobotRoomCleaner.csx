
// This is the robot's control interface.
// You should not implement it, or speculate about its implementation
interface Robot
{
    // Returns true if the cell in front is open and robot moves into the cell.
    // Returns false if the cell in front is blocked and robot stays in the current cell.
    public bool Move();

    // Robot will stay in the same cell after calling turnLeft/turnRight.
    // Each turn will be 90 degrees.
    public void TurnLeft();
    public void TurnRight();

    // Clean the current cell.
    public void Clean();
}


class Solution
{
    // contrained programming + backtracking
    // Time: O(N-M)
    // N is a number of cells in the room
    // M is a number of obstacles
    // Space: O(N-M)
    Robot robot;
    // which direction it should go forward: up, right, down, left
    int[,] directions = new int[,] { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };
    HashSet<Tuple<int, int>> visited = new HashSet<Tuple<int, int>>();
    public void CleanRoom(Robot robot)
    {
        this.robot = robot;
        Backtrack(0, 0, 0);
    }

    public void GoBack()
    {
        robot.TurnRight();
        robot.TurnRight();
        robot.Move();
        robot.TurnRight();
        robot.TurnRight();
    }
    // d means the direction the robot is currently facing
    public void Backtrack(int row, int col, int d)
    {
        visited.Add(new Tuple<int, int>(row, col));
        robot.Clean();

        for (int i = 0; i < 4; i++)
        {
            // which cell is the next cell to move (go forward) 
            // given the current direction the robot is facing
            int newD = (d + i) % 4;
            int newRow = row + directions[newD, 0];
            int newCol = col + directions[newD, 1];

            if (!visited.Contains(new Tuple<int, int>(newRow, newCol)) && robot.Move())
            {
                Backtrack(newRow, newCol, newD);
                GoBack();
            }
            robot.TurnRight();
        }
    }
}
