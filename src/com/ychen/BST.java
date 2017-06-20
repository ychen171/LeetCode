package com.ychen;

public class BST<K extends Comparable<K>, V> {
  private class Node {
    private K key;
    private V val;
    private Node left, right;
    private int N;

    public Node(K key, V val, int N) {
      this.key = key;
      this.val = val;
      this.N = N;
    }
  }

  private Node root;

  public int size() { return size(root); }
  private int size(Node x) {
    if (x == null) return 0;
    else return x.N;
  }
  public V get(K key) { return get(root, key); }
  private V get(Node x, K key) {
    if (x == null) return null;
    int cmp = key.compareTo(x.key);
    if      (cmp < 0) return get(x.left, key);
    else if (cmp > 0) return get(x.right, key);
    else return x.val;
  }

  public void put(K key, V val) { root = put(root, key, val); }
  private Node put(Node x, K key, V val) {
    if (x == null) return new Node(key, val, 1);
    int cmp = key.compareTo(x.key);
    if      (cmp < 0) return x.left = put(x.left, key, val);
    else if (cmp > 0) return x.right= put(x.right,key, val);
    else x.val = val;
    x.N = size(x.left) + size(x.right) + 1;
    return x;
  }
}
