package com.ychen;

public class Customer {
  private int _weight;
  private int _targetFloor;
  private int _actualFloor;

  Customer(int weight, int targetFloor, int actualFloor) {
    _weight = weight;
    _targetFloor = targetFloor;
    _actualFloor = actualFloor;
  }

  public int getWeight() { return _weight; }
  public int getActualFloor() { return _actualFloor; }
  public int getTargetFloor() { return _targetFloor; }
}
