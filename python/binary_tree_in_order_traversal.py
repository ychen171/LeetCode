#!/usr/bin/env python
# -*- coding: utf-8 -*-
# Yu Chen
#
# Definition for a  binary tree node
# class TreeNode:
#     def __init__(self, x):
#         self.val = x
#         self.left = None
#         self.right = None

class Solution:
    # @param root, a tree node
    # @return a list of integers
    def in_order_traversal(self, root):
        # Empty tree
        if root == None:
            return []

        result = []
        stack = [root]
        current = root.left

        while len(stack) != 0 or current != None:
            # Find the leftmost node among all the un-accessed ones.
            while current != None:
                stack.append(current)
                current = current.left

            # Fetch the value in currently leftmost node
            current = stack.pop()
            result.append(current.val)

            # Try the right son of current node
            current = current.right

        return result
