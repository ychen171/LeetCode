package com.ychen.elevator;

import java.util.*;

public class Elevator {
  private int _maxWeight;
  private int _maxPassengers;
  private int _maxFloors;
  private Queue<Person> _people;
  private List<Person> _passengers;
  
  Elevator(int maxWeight, int maxPassengers, int maxFloors) {
    _maxWeight = maxWeight;
    _maxPassengers = maxPassengers;
    _maxFloors = maxFloors;
    _people = new LinkedList<>();
    _passengers = new ArrayList<>();
  }
  
  public int getMaxWeight() { return _maxWeight; }
  public int getMaxPassengers() { return _maxPassengers; }
  public int getMaxFloors() { return _maxFloors; }
  
  public void addPeople(Queue<Person> people) {
    for (Person p: people) {
      if (p.getTargetFloor() > this.getMaxFloors() ||
          p.getWeight() > this.getMaxWeight()) {
        throw new IllegalArgumentException();
      }
      this._people.add(p);
    }
  }
  
  public int calculateNumberOfStops() {
    int stops = 0;
    while (!this._people.isEmpty()) {
      while (this.isOneMore()) {
        this._passengers.add(this._people.poll());
      }
      ArrayList<Integer> targetFloors = new ArrayList<>();
      for (Person p: this._passengers) {
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
    for (Person p: this._passengers) {
      sum += p.getWeight();
    }
    return !this._people.isEmpty() &&
        sum + this._people.peek().getWeight() < this.getMaxWeight() &&
        this._passengers.size() < this.getMaxPassengers();
  }


  
  public static void main(String[] args) {
    Queue<Person> people = new LinkedList<Person>(){};
    people.add(new Person(60, 2, 0));
    people.add(new Person(80, 3, 0));
    people.add(new Person(40, 5, 0));
    
    Elevator elevator = new Elevator(200, 2, 5);
    elevator.addPeople(people);
    int stops = elevator.calculateNumberOfStops();
    System.out.println(stops);
  }
}
