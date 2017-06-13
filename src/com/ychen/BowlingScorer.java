package com.ychen;


import java.util.Scanner;

public class BowlingScorer {
  private int[] _pins;
  private int[] _scores;
  private int[] _accScores;
  private int _count;
  
  BowlingScorer() {
    _pins = new int[21];
    _scores = new int[10];
    _accScores = new int[10];
    _count = 0;
  }
  
  public int[] getPins() { return _pins; }
  
  public int[] getScores() { return _scores; }
  
  public int[] getAccScores() { return _accScores; }
  
  public void setPins(int[] values) { 
    int j=0;
    for (int i=0; i<21; i++) {
      if (j < values.length) {
        _pins[i] = values[j];
        j++;
        if (_pins[i] == 10 && i%2 == 0) {
          i++;
          _pins[i] = -1;
        }
      }
    }
  }

  public void setPins() {
    System.out.println("Enter # of pin for each round: ");
    Scanner input = new Scanner(System.in);
    for (int i=0; i<21; i++) {
      _pins[i] = input.nextInt();
      if (_pins[i] == 10 && i%2 == 0) {
        i++;
        _pins[i] = -1;
      }
    }
  }
  
  public void calc() {
    for (int i=0; i<20; i++) {
      if (i%2 != 0) {
        if (_pins[i] >= 0) {
          if (_pins[i] + _pins[i-1] == 10) {
            _scores[i/2] = _pins[i] + _pins[i-1] + _pins[i+1];
          } else {
            _scores[i/2] = _pins[i] + _pins[i-1];
          }
        } else {
          _scores[i/2] = _count = 0;
          for (int j = i; _count < 2 && j < 21; j++) {
            if (_pins[j] >= 0) {
              _count++;
              _scores[i/2] += _pins[j];
            }
          }
          _scores[i/2] += _pins[i-1];
        }
      }
    }

    _accScores[0] = _scores[0];
    for (int i=1; i<10; i++) {
      _accScores[i] = _accScores[i-1] + _scores[i];
    }
  }
  
  public void printScores() {
    // Print out the score of every round
    for (int i=0; i<10; i++) {
      System.out.print(_scores[i] + "\t\t");
    }
    System.out.println();
    // Print out the cumulative score of every round
    for (int i=0; i<10; i++) {
      System.out.print(_accScores[i] + "\t\t");
    }
    System.out.println();
  }
  
  public static void main(String[] args) {
    BowlingScorer bs = new BowlingScorer();
    bs.setPins();
    bs.calc();
    bs.printScores();
    
//    int[] pins = new int[21];
//    int[] scores = new int[10];
//    int[] accScores = new int[10]; 
//    int count;

//    Scanner input = new Scanner(System.in);
//    for (int i=0; i<21; i++) {
//      pins[i] = input.nextInt();
//      if (pins[i] == 10 && i%2 == 0) {
//        i++;
//        pins[i] = -1;
//      }
//    }
    
//    for (int i=0; i<20; i++) {
//      if (i%2 != 0) {
//        if (pins[i] >= 0) {
//          if (pins[i] + pins[i-1] == 10) {
//            scores[i/2] = pins[i] + pins[i-1] + pins[i+1];
//          } else {
//            scores[i/2] = pins[i] + pins[i-1];
//          }
//        } else {
//          scores[i/2] = count = 0;
//          for (int j = i; count < 2 && j < 21; j++) {
//            if (pins[j] >= 0) {
//              count++;
//              scores[i/2] += pins[j];
//            }
//          }
//          scores[i/2] += pins[i-1];
//        }
//      }
//    }
//    // Print out the score of every round
//    for (int i=0; i<10; i++) {
//      System.out.print(scores[i] + " ");
//    }
//    System.out.println();
//    // Print out the cumulative score of every round
//    accScores[0] = scores[0];
//    System.out.print(accScores[0] + " ");
//    for (int i=1; i<10; i++) {
//      accScores[i] = accScores[i-1] + scores[i];
//      System.out.print(accScores[i] + " ");
//    }
//    System.out.println();
  }
}
