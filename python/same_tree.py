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

class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

def binary_insert(root, node):
    if root is None:
        root = node
    else:
        if root.val > node.val:
            if root.left == None:
                root.left = node
            else:
                binary_insert(root.left, node)
        else:
            if root.right == None:
                root.right = node
            else:
                binary_insert(root.right, node)

class Solution:
    # @param p, a tree node
    # @param q, a tree node
    # @return a boolean
    def is_same_tree(self, p, q):
        if p == None and q == None:
            return True
        if p and q and p.val == q.val:
            return self.is_same_tree(p.left, q.left) and self.is_same_tree(
                p.right, q.right)
        return False