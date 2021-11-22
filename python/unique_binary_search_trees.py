#!/usr/bin/env python
# -*- coding: utf-8 -*-
# Yu Chen
#
class Solution:
    # @return an integer
    def num_trees(self, n):
        # num_of_trees[i] == j means for n is i, there are j unique
        # binary search trees for it. 
        num_of_trees = [1, 1, 2]

        next_trying = len(num_of_trees)
        while next_trying <= n:
            # Compute how many unique binary search trees are there for
            # n == next_trying.
            count = 0
            for center in xrange(next_trying):
                # num_of_trees[center] is the number of unique binary search
                #   trees in the left son
                # num_of_trees[next_trying-center-1] is the number of unique
                #   binary search trees in the right son
                # num_of_trees[center] * num_of_trees[next_trying-center-1] is
                #   the number of unique binary search trees with "center"
                #   being the root.
                count += num_of_trees[center] * num_of_trees[next_trying-center-1]
            num_of_trees.append(count)
                # I don't understand this. 
            next_trying += 1
        return num_of_trees[n]