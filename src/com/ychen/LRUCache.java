package com.ychen;

import java.util.HashMap;

public class LRUCache<K, V> {
  class Node<K, V> {
    Node<K, V> previous;
    Node<K, V> next;
    K key;
    V value;
    
    public Node(Node<K, V> previous, Node<K, V> next, K key, V value) {
      this.previous = previous;
      this.next = next;
      this.key = key;
      this.value = value;
    }
  }
  
  private HashMap<K, Node<K, V>> cache;
  private Node<K, V> leastRecentlyUsed;
  private Node<K, V> mostRecentlyUsed;
  private int maxSize;
  private int curSize;
    
  public LRUCache(int maxSize) {
    this.maxSize = maxSize;
    this.curSize = 0;
    leastRecentlyUsed = mostRecentlyUsed = new Node<K, V>(null, null, null, null);
    cache = new HashMap();
    
  }
  
  public V get(K key) {
    Node<K, V> tempNode = cache.get(key);
    if (tempNode == null) return null;
    
    // if MRU, leave the list as it is
    if (tempNode.key == mostRecentlyUsed.key) return mostRecentlyUsed.value;
    
    // get the next and previous nodes
    Node<K, V> nextNode = tempNode.next;
    Node<K, V> previousNode = tempNode.previous;
    // if at the left-most, update LRU
    if (tempNode.key == leastRecentlyUsed.key) {
      nextNode.previous = null;
      leastRecentlyUsed = nextNode;
    } else if (tempNode.key != mostRecentlyUsed.key) {
      // if in the middle, update the nodes before and after the current node
      nextNode.previous = previousNode;
      previousNode.next = nextNode;
    }
    
    // move the current node to MRU
    tempNode.previous = mostRecentlyUsed;
    mostRecentlyUsed.next = tempNode;
    mostRecentlyUsed = tempNode;
    mostRecentlyUsed.next = null;
    
    return tempNode.value;
  }
  
  public void put(K key, V value) {
    if (cache.containsKey(key)) return;
    
    // put the new node at MRU
    Node<K, V> node = new Node(mostRecentlyUsed, null, key, value);
    mostRecentlyUsed.next = node;
    cache.put(key, node);
    mostRecentlyUsed = node;
    
    // delete the left-most node, update LRU
    if (curSize == maxSize) {
      cache.remove(leastRecentlyUsed.key);
      leastRecentlyUsed = leastRecentlyUsed.next;
      leastRecentlyUsed.previous = null;
    } else if (curSize < maxSize) {
      // update cache, update LRU
      if (curSize == 0) leastRecentlyUsed = node;
      curSize++;
    }
  }
}
