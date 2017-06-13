package com.ychen

data class Person(val name: String, val age: Int)

fun getPeople(): List<Person> {
    return listOf(Person("Alice", 29), Person("Bob", 31))
}

fun main(args: Array<String>) {
    val people = getPeople()
    println(people[0].name)
    println(people[0].age)
    println(people[1].name)
    println(people[1].age)
}