package com.ychen;

import java.util.*;

public class Elevator {
  private int _maxWeight;
  private int _maxPassengers;
  private int _maxFloors;
  private LinkedList<Customer> _customers;
  private ArrayList<Customer> _passengers;
  
  Elevator(int maxWeight, int maxPassengers, int maxFloors) {
    _maxWeight = maxWeight;
    _maxPassengers = maxPassengers;
    _maxFloors = maxFloors;
    _customers = new LinkedList<Customer>();
    _passengers = new ArrayList<Customer>();
  }
  
  public int getMaxWeight() { return _maxWeight; }
  public int getMaxPassengers() { return _maxPassengers; }
  public int getMaxFloors() { return _maxFloors; }
  
  public void setCustomers(Queue<Customer> customers) {
    for (Customer c: customers) {
      if (c.getTargetFloor() > this.getMaxFloors() || 
          c.getWeight() > this.getMaxWeight()) {
        throw new IllegalArgumentException();
      }
      this._customers.add(c);
    }
  }
  
  public int calculateNumberOfStops() {
    int stops = 0;
    while (!this._customers.isEmpty()) {
      while (this.isOneMore()) {
        this._passengers.add(this._customers.poll());
      }
      ArrayList<Integer> targetFloors = new ArrayList<Integer>();
      for (Customer p: this._passengers) {
        int tf = p.getTargetFloor();
        if (!targetFloors.contains(tf)) stops++;
      }
      this._passengers.clear();
      stops++;
    }
    return stops;
  }
  
  private boolean isOneMore() {
    int sum = 0;
    for (Customer p: this._passengers) {
      sum += p.getWeight();
    }
    return !this._customers.isEmpty() &&
        sum + this._customers.peek().getWeight() < this.getMaxWeight() &&
        this._passengers.size() < this.getMaxPassengers();
  }


  
  public static void main(String[] args) {
    LinkedList<Customer> customers = new LinkedList<Customer>(){};
    customers.add(new Customer(60, 2, 0));
    customers.add(new Customer(80, 3, 0));
    customers.add(new Customer(40, 5, 0));
    
    Elevator elevator = new Elevator(200, 2, 5);
    elevator.setCustomers(customers);
    int stops = elevator.calculateNumberOfStops();
    System.out.println(stops);
  }
}
