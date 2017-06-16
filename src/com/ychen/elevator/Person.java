package com.ychen.elevator;

public class Person {
  private int _weight;
  private int _targetFloor;
  private int _actualFloor;

  Person(int weight, int targetFloor, int actualFloor) {
    _weight = weight;
    _targetFloor = targetFloor;
    _actualFloor = actualFloor;
  }

  public int getWeight() { return _weight; }
  public int getActualFloor() { return _actualFloor; }
  public int getTargetFloor() { return _targetFloor; }
}
