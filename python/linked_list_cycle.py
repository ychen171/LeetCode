#!/usr/bin/env python
# -*- coding: utf-8 -*-
# Yu Chen
#
# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, x):
#         self.val = x
#         self.next = None

class Solution:
    # @param head, a ListNode
    # @return a boolean
    def has_cycle(self, head):
        if head == None:
            return False
        slow = head     # Move one step each time
        fast = head     # Move two steps each time

        while fast.next != None and fast.next.next != None:
            slow = slow.next
            fast = fast.next.next

            if slow == fast:
                return True

        # fast reach the end. Limited list never has cycle.
        return False
