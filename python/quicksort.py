#!/usr/bin/env python
# -*- coding: utf-8 -*-
# Yu Chen
#

def quicksort(my_list, start, end):
    if start < end:
        # partition the list 
        pivot = partition(my_list, start, end)
        # sort both halves
        quicksort(my_list, start, pivot-1)
        quicksort(my_list, pivot+1, end)
    return my_list

def partition(my_list, start, end):
    pivot = my_list[start]
    left = start + 1
    right = end
    done = False
    while not done:
        while left <= right and my_list[left] <= pivot:
            left += 1
        while my_list[right] >= pivot and right >= left:
            right -= 1
        if right < left:
            done = True
        else:
            # swap places
            temp = my_list[left]
            my_list[left] = my_list[right]
            my_list[right] = temp
    # swap start with my_list[right]
    temp = my_list[start]
    my_list[start] = my_list[right]
    my_list[right] = temp
    return right

def main():
    my_list = [1,5,2,7,4,8,4,87,4,6,9,24]
    start = 0
    end = len(my_list)-1
    sorted_list = quicksort(my_list, start, end)
    print sorted_list
    return sorted_list

if __name__ == '__main__':
    main()
    