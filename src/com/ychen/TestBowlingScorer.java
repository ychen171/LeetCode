package com.ychen;

import junit.framework.TestCase;
import org.junit.Test;

public class TestBowlingScorer extends TestCase {
  @Test
  public void testFourRounds() {
    int[] pins = new int[]{1, 2, 4, 1};
    BowlingScorer bs = new BowlingScorer();
    bs.setPins(pins);
    bs.calc();
    int[] actual = bs.getAccScores();
    int[] expected = new int[]{3, 8};

    for (int i = 0; i < expected.length; i++) {
      assertEquals(expected[i], actual[i]);
    }
  }

  @Test
  public void testSpareMissMiss() {
    int[] pins = new int[]{6, 4, 3, 4, 5, 2};
    BowlingScorer bs = new BowlingScorer();
    bs.setPins(pins);
    bs.calc();
    int[] actual = bs.getAccScores();
    int[] expected = new int[]{13, 20, 27};

    for (int i = 0; i < expected.length; i++) {
      assertEquals(expected[i], actual[i]);
    }
  }
  
  @Test 
  public void testMissSpareMiss() {
    int[] pins = new int[]{6, 3, 4, 6, 5, 2};
    BowlingScorer bs = new BowlingScorer();
    bs.setPins(pins);
    bs.calc();
    int[] actual = bs.getAccScores();
    int[] expected = new int[]{9, 24, 31};

    for (int i = 0; i < expected.length; i++) {
      assertEquals(expected[i], actual[i]);
    }
  }

  @Test
  public void testMissMissSpare() {
    int[] pins = new int[]{6, 3, 3, 4, 8, 2, 4};
    BowlingScorer bs = new BowlingScorer();
    bs.setPins(pins);
    bs.calc();
    int[] actual = bs.getAccScores();
    int[] expected = new int[]{9, 16, 30};

    for (int i = 0; i < expected.length; i++) {
      assertEquals(expected[i], actual[i]);
    }
  }

  @Test
  public void testSpareSpareMiss() {
    int[] pins = new int[]{6, 4, 3, 7, 5, 2};
    BowlingScorer bs = new BowlingScorer();
    bs.setPins(pins);
    bs.calc();
    int[] actual = bs.getAccScores();
    int[] expected = new int[]{13, 28, 35};

    for (int i = 0; i < expected.length; i++) {
      assertEquals(expected[i], actual[i]);
    }
  }

  @Test
  public void testMissSpareSpare() {
    int[] pins = new int[]{6, 3, 3, 7, 8, 2, 4};
    BowlingScorer bs = new BowlingScorer();
    bs.setPins(pins);
    bs.calc();
    int[] actual = bs.getAccScores();
    int[] expected = new int[]{9, 27, 41};

    for (int i = 0; i < expected.length; i++) {
      assertEquals(expected[i], actual[i]);
    }
  }

  @Test
  public void testSpare0SpareMiss() {
    int[] pins = new int[]{6, 4, 0, 10, 5, 2};
    BowlingScorer bs = new BowlingScorer();
    bs.setPins(pins);
    bs.calc();
    int[] actual = bs.getAccScores();
    int[] expected = new int[]{10, 25, 32};

    for (int i = 0; i < expected.length; i++) {
      assertEquals(expected[i], actual[i]);
    }
  }

  @Test
  public void testMissStrikeMiss() {
    int[] pins = new int[]{6, 2, 10, 5, 4};
    BowlingScorer bs = new BowlingScorer();
    bs.setPins(pins);
    bs.calc();
    int[] actual = bs.getAccScores();
    int[] expected = new int[]{8, 27, 36};

    for (int i = 0; i < expected.length; i++) {
      assertEquals(expected[i], actual[i]);
    }
  }

  @Test
  public void testSpareStrikeMiss() {
    int[] pins = new int[]{7, 3, 10, 5, 4};
    BowlingScorer bs = new BowlingScorer();
    bs.setPins(pins);
    bs.calc();
    int[] actual = bs.getAccScores();
    int[] expected = new int[]{20, 39, 48};

    for (int i = 0; i < expected.length; i++) {
      assertEquals(expected[i], actual[i]);
    }
  }

  @Test
  public void testStrikeSpareSpareStrike() {
    int[] pins = new int[]{10, 7, 3, 8, 2, 10};
    BowlingScorer bs = new BowlingScorer();
    bs.setPins(pins);
    bs.calc();
    int[] actual = bs.getAccScores();
    int[] expected = new int[]{20, 38, 58, 68};

    for (int i = 0; i < expected.length; i++) {
      assertEquals(expected[i], actual[i]);
    }
  }

  @Test
  public void testStrikeMissStrikeSpare() {
    int[] pins = new int[]{10, 7, 2, 10, 6, 4};
    BowlingScorer bs = new BowlingScorer();
    bs.setPins(pins);
    bs.calc();
    int[] actual = bs.getAccScores();
    int[] expected = new int[]{19, 28, 48, 58};

    for (int i = 0; i < expected.length; i++) {
      assertEquals(expected[i], actual[i]);
    }
  }

  @Test
  public void testStrikeMissStrikeMiss() {
    int[] pins = new int[]{10, 7, 2, 10, 6, 3};
    BowlingScorer bs = new BowlingScorer();
    bs.setPins(pins);
    bs.calc();
    int[] actual = bs.getAccScores();
    int[] expected = new int[]{19, 28, 47, 56};

    for (int i = 0; i < expected.length; i++) {
      assertEquals(expected[i], actual[i]);
    }
  }

  @Test
  public void testStrike00Miss() {
    int[] pins = new int[]{10, 0, 0, 4, 3};
    BowlingScorer bs = new BowlingScorer();
    bs.setPins(pins);
    bs.calc();
    int[] actual = bs.getAccScores();
    int[] expected = new int[]{10, 10, 17};

    for (int i = 0; i < expected.length; i++) {
      assertEquals(expected[i], actual[i]);
    }
  }

  @Test
  public void testStrike60Miss() {
    int[] pins = new int[]{10, 6, 0, 4, 3};
    BowlingScorer bs = new BowlingScorer();
    bs.setPins(pins);
    bs.calc();
    int[] actual = bs.getAccScores();
    int[] expected = new int[]{16, 22, 29};

    for (int i = 0; i < expected.length; i++) {
      assertEquals(expected[i], actual[i]);
    }
  }

  @Test
  public void testStrike06Miss() {
    int[] pins = new int[]{10, 0, 6, 4, 3};
    BowlingScorer bs = new BowlingScorer();
    bs.setPins(pins);
    bs.calc();
    int[] actual = bs.getAccScores();
    int[] expected = new int[]{16, 22, 29};

    for (int i = 0; i < expected.length; i++) {
      assertEquals(expected[i], actual[i]);
    }
  }

  @Test
  public void testAll5Strikes() {
    int[] pins = new int[]{10, 10, 10, 10, 10};
    BowlingScorer bs = new BowlingScorer();
    bs.setPins(pins);
    bs.calc();
    int[] actual = bs.getAccScores();
    int[] expected = new int[]{30, 60, 90, 110, 120};

    for (int i = 0; i < expected.length; i++) {
      assertEquals(expected[i], actual[i]);
    }
  }

  @Test
  public void testStrikeStrikeMiss() {
    int[] pins = new int[]{10, 10, 3, 4};
    BowlingScorer bs = new BowlingScorer();
    bs.setPins(pins);
    bs.calc();
    int[] actual = bs.getAccScores();
    int[] expected = new int[]{23, 40, 47};

    for (int i = 0; i < expected.length; i++) {
      assertEquals(expected[i], actual[i]);
    }
  }

  @Test
  public void testSpareStrikeStrikeSpare() {
    int[] pins = new int[]{6, 4, 10, 10, 3, 7};
    BowlingScorer bs = new BowlingScorer();
    bs.setPins(pins);
    bs.calc();
    int[] actual = bs.getAccScores();
    int[] expected = new int[]{20, 43, 63};

    for (int i = 0; i < expected.length; i++) {
      assertEquals(expected[i], actual[i]);
    }
  }

  @Test
  public void testSpareStrikeStrikeMiss() {
    int[] pins = new int[]{6, 4, 10, 10, 3, 4};
    BowlingScorer bs = new BowlingScorer();
    bs.setPins(pins);
    bs.calc();
    int[] actual = bs.getAccScores();
    int[] expected = new int[]{20, 43, 60};

    for (int i = 0; i < expected.length; i++) {
      assertEquals(expected[i], actual[i]);
    }
  }
}
