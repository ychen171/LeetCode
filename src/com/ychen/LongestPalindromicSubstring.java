package com.ychen;

public class LongestPalindromicSubstring {

  public static void main(String[] args) {
    String s = "abbc";
    LongestPalindromicSubstring lps = new LongestPalindromicSubstring();
    System.out.println(lps.longestPalindrome(s));
  }

  public String longestPalindrome(String s) {
    int targetLen = 0;
    int totalLen = s.length();
    int begin = 0;
    int end = totalLen;
    for (int i = 0; i < totalLen; i++) {
      for (int j = i + targetLen + 1; j <= totalLen; j++) {
        int partLen = j - i;
        if (partLen > targetLen) {
          if (isPalindrome(s, i, j)) {
            targetLen = partLen;
            begin = i;
            end = j;
          }
        }
      }
    }
    return s.substring(begin, end);
  }

  private boolean isPalindrome(String s, int begin, int end) {
    int len = end - begin;
    for (int i = 0; i < len; i++) {
      if (s.charAt(begin + i) != s.charAt(end - i - 1)) {
        return false;
      }
    }
    return true;
  }

//  public String longestPalindrome(String s) {
//    if (s == null || s.length() == 0) {
//      return "";
//    }
//
//    int length = s.length();
//    int max = 0;
//    String result = "";
//    for (int i = 1; i <= 2 * length - 1; i++) {
//      int count = 1;
//      while (i - count >= 0 && i + count <= 2 * length && get(s, i - count) == get(s, i + count)) {
//        count++;
//      }
//      count--; // there will be one extra count for the outbound #
//      if (count > max) {
//        result = s.substring((i - count) / 2, (i + count) / 2);
//        max = count;
//      }
//    }
//
//    return result;
//  }
//
//  private char get(String s, int i) {
//    if (i % 2 == 0)
//      return '#';
//    else
//      return s.charAt(i / 2);
//  }
}
