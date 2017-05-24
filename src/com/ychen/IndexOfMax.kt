package com.ychen

fun indexOfMax(a: IntArray): Int? {
    var max = Integer.MIN_VALUE
    var idx = 0
    if (a.size == 0) return null
    for (i in 0..a.size-1) {
        if (a[i] >= max) {
            max = a[i]
            idx = i
        }
        
    }
    return idx
}



fun main(args: Array<String>) {
    val a = intArrayOf(1, 3, 2, 1)
    val maxIdx = indexOfMax(a)
    println(maxIdx)
}
