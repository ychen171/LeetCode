class Solution:
    # @param {string} s
    # @return {integer}
    def longestValidParentheses(self, s):
        left = 0
        right = 0
        if s == '':
            return 0
        for char in s:
            if (left > right):
                if char == '(':
                    left += 1
                if char == ')':
                    right += 1
            elif (left == right):
                if char == '(':
                    left += 1
        return right*2

s = ')()())'
# s = '('
# s = ''
s = '()(()'
sol = Solution()
print sol.longestValidParentheses(s)