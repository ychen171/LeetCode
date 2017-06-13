package com.ychen

fun isPalindrome(s: String): Boolean {
    for (i in 0..s.length/2-1) {
        if (!s[i].equals(s[s.length-1-i]))
            return false
    }
    return true
}

fun main(args: Array<String>) {
    val s = "abcba"
    println(isPalindrome(s))
}
