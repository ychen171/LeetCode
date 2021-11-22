#!/usr/bin/env python
# -*- coding: utf-8 -*-
# Yu Chen
#

class Solution:
    # @param A, a list of integer
    # @return an integer
    def single_number(self, A):
        return reduce(lambda x,y:x^y, A)

A = [1,2,2,3,3,4,4,5,5,6,6,7,7,8,8,9,9]

s = Solution()
print s.single_number(A)