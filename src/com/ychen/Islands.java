package com.ychen;

public class Islands {
  static final int ROW = 5, COL = 5;
  static final int[] ROW_NBR = new int[] {-1, -1, -1,  0, 0,  1, 1, 1};
  static final int[] COL_NBR = new int[] {-1,  0,  1, -1, 1, -1, 0, 1};
  
  private boolean isSafe(int[][] m, int row, int col, boolean[][] visited) {
    return row >= 0 && row < ROW 
        && col >= 0 && col < COL 
        && m[row][col] == 1 
        && !visited[row][col];
  }
  
  private void DFS(int[][] m, int row, int col, boolean[][] visited) {
    // mark this cell as visited
    visited[row][col] = true;
    
    // recur for all 8 neighbours
    for (int i=0; i<8; i++) {
      int nextRow = row + ROW_NBR[i];
      int nextCol = col + COL_NBR[i];
      if (isSafe(m, nextRow, nextCol, visited)) 
        DFS(m, nextRow, nextCol, visited);
    }
  }
  
  // returns count of islands in given boolean 2D matrix
  int countIslands(int[][] m) {
    // a boolean 2D array for marking visited cells
    // initialize all cells are unvisited
    boolean[][] visited = new boolean[ROW][COL];
    // initialize count as 0
    int count = 0;
    // traverse through all cells
    for (int i=0; i<ROW; i++) {
      for (int j=0; j<COL; j++) {
        if (m[i][j] == 1 && !visited[i][j]) {
          DFS(m, i, j, visited);
          count++;
        }
      }
    }
    return count;
  }
  
  public static void main(String[] args) {
    int[][] m = new int[][] {
        {1, 1, 0, 0, 0}, 
        {0, 1, 0, 0, 1}, 
        {1, 0, 0, 1, 1}, 
        {0, 0, 0, 0, 0}, 
        {1, 0, 1, 0, 1}};
    Islands islands = new Islands();
    System.out.println("Number of islands is: " + islands.countIslands(m));
  }
}
