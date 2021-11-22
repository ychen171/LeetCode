# class Solution:
#     # @param {integer} x
#     # @return {boolean}
#     def isPalindrome(self, x):
#         source = str(x)
#         length = len(source)
#         for i in xrange(length/2):
#             if (source[i] == source[length-1-i]):
#                 continue
#             else:
#                 return False
#         return True

# x = 12321
# sol = Solution()
# print sol.isPalindrome(x)


class Solution:
    # @param {integer} x
    # @return {boolean}
    def isPalindrome(self, x):
        old = x
        new = 0
        while (x != 0):
            digit = x % 10
            x /= 10
            new = (new * 10 + digit)
        if (new == old):
            return True
        else:
            return False


x = 12344321
sol = Solution()
print sol.isPalindrome(x)