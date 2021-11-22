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
    def pre_order_traversal(self, root):
        # Empty tree
        if root == None: 
            return []

        result = []
        stack = [root]

        while len(stack) != 0:
            # Access the root firstly
            current = stack.pop()
            result.append(current.val)

            # Then we are going to access its left son and right son.
            if current.right != None: 
                stack.append(current.right)
            if current.left != None: 
                stack.append(current.left)

        return result
        