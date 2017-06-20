package com.ychen;

public class Merge {
  private static void merge(Comparable[] a, Comparable[] aux, int lo, int mid, int hi) {
    for (int k=lo; k<=hi; k++)
      aux[k] = a[k];

    int i = lo, j = mid+1;
    for (int k=lo; k<=hi; k++) {
      if      (i > mid)                         a[k] = aux[j++];
      else if (j > hi)                          a[k] = aux[i++];
      else if (aux[j].compareTo(aux[i]) == -1)  a[k] = aux[j++];
      else                                      a[k] = aux[i++];
    }
  }

  private static void sort(Comparable[] a, Comparable[] aux, int lo, int hi) {
    if (hi <= lo) return;
    int mid = lo + (hi - lo) / 2;
    sort(a, aux, lo, mid);
    sort(a, aux, mid+1, hi);
    if (a[mid].compareTo(a[mid+1]) == -1) return;
    merge(a, aux, lo, mid, hi);
  }

  public static void sort(Comparable[] a) {
    Comparable[] aux = new Comparable[a.length];
    sort(a, aux, 0, a.length - 1);
  }
}
