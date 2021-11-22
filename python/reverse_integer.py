#!/usr/bin/env python
# -*- coding: utf-8 -*-
# Yu Chen
#
class Solution:
    # @return an integer
    def reverse(self, x):
        if x < 0:
            result = int(str(x)[1:][::-1])*(-1)
        else:
            result = int(str(x)[::-1])
        return result

# class Solution:
#     # @return an integer
#     def reverse(self, x):
#         digits = []
#         while True:
#             if x / 10:
#                 digits.append(x % 10)
#                 x /= 10
#             else:
#                 digits.append(x)
#                 break
        
#         result = 0
#         for i in range(len(digits)):
#             result += digits[i] * 10 ** i

#         return result

def main(x):
    s = Solution()
    print s.reverse(x)

if __name__ == '__main__':
    main(123)
    main(100)
    main(1000000003)