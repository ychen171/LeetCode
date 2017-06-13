package com.ychen

fun findPairless(a: IntArray): Int {
    var map = HashMap<Int, Int?>()
    for (item in a) {
        if (map.containsKey(item))
            map[item] = map[item]?.plus(1)
        else map[item] = 1
    }
    for (k in map.keys) {
        if (map[k]?.rem(2) != 0)
            return k
    }
    return 0
}

fun main(args: Array<String>) {
    val a = intArrayOf(1, 2, 1, 2)
    println(findPairless(a))
}
