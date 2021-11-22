class Solution:
    # @param {string} s
    # @return {integer}
    def titleToNumber(self, s):
    	result = 0
    	for x in xrange(len(s)):
    		char = s[x]
    		result += (ord(char) - 64) * 26 ** (len(s) - x - 1)
    	return result

sol = Solution()
print sol.titleToNumber("AB")