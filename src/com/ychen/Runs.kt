package com.ychen

fun runs(a: IntArray): Int {
    if (a.size == 0) return 0
    var cnt = 1
    var last = a[0]
    for (i in 1..a.size-1) {
        if (a[i] != last) {
            cnt++
            last = a[i]
        }
    }
    return cnt
}

fun main(args: Array<String>) {
    val a = intArrayOf(0)
    println(runs(a))
}
