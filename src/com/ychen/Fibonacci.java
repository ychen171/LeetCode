package com.ychen;


import java.util.Scanner;

public class Fibonacci {
  public static void main(String[] args) {
    Scanner input = new Scanner(System.in);
    System.out.print("Enter n: ");
    int n = input.nextInt();
    System.out.println("Print " + n + " Fibonacci numbers: " );
    for (int i=1; i<=n; i++) {
      System.out.print(fibonacciRecursion(i) + " ");
    }
    System.out.println();
//    int a = 0;
//    int b = 1;
//    while (a < n) {
//      a = a + b;
//      System.out.print(b + " ");
//      System.out.print(a + " ");
//      b = a + b;
//    }
    fibonacciLoop(n);
  }
  
  public static int fibonacciRecursion(int n) {
    if (n == 1 || n == 2) return 1;
    return fibonacciRecursion(n - 1) + fibonacciRecursion(n - 2);
  }
  
  public static void fibonacciLoop(int n) {
    int a = 1;
    int b = 1;
    while (b <= n) {
      System.out.print(a + " ");
      System.out.print(b + " ");
      a = a + b;
      b = a + b;
    }
  }
}
