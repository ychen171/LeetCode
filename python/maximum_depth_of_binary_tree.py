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

def in_order_print(root):
    if not root:
        return 
    in_order_print(root.left)
    print root.val
    in_order_print(root.right)

def pre_order_print(root):
    if not root:
        return
    print root.val
    pre_order_print(root.left)
    pre_order_print(root.right)

def tree_example():
    t = TreeNode(8)
    binary_insert(t, TreeNode(3))
    binary_insert(t, TreeNode(10))
    binary_insert(t, TreeNode(1))
    binary_insert(t, TreeNode(6))
    binary_insert(t, TreeNode(14))
    binary_insert(t, TreeNode(4))
    binary_insert(t, TreeNode(7))
    binary_insert(t, TreeNode(13))

    print "in order: "
    in_order_print(t)

    print "pre order: "
    pre_order_print(t)

    return t

class Solution:
    # @param root, a tree node
    # @return an integer
    def max_depth(self, root):
        if root == None: 
            return 0
        else:
            return 1 + max(self.max_depth(root.left), \
                self.max_depth(root.right))

if __name__ == "__main__":

    t = tree_example()

    s = Solution()
    print 'the maximum depth of binary tree:', s.max_depth(t)