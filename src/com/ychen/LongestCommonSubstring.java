package com.ychen;


public class LongestCommonSubstring {
  public static String getLongestCommonSubstring(String s, String t) {
    int m = s.length();
    int n = t.length();
    int max = 0;
    int[][] dp = new int[m][n];
    String sub = "";
    
    for (int i=0; i<m; i++) {
      for (int j=0; j<n; j++) {
        if (s.charAt(i) == t.charAt(j)) {
          if (i == 0 || j == 0) dp[i][j] = 1;
          else dp[i][j] = dp[i-1][j-1] + 1;
          if (dp[i][j] > max) max = dp[i][j];
          if (dp[i][j] == max) sub = s.substring(i-max+1, i+1);
        } else {
          dp[i][j] = 0;
        }
      }
    }
    return sub;
  }
  
  public static void main(String[] args) {
    String s = "abcdaf";
    String t = "zbcdf";
    String sub = getLongestCommonSubstring(s, t);
    System.out.println(sub);
  }
}
