class Solution:
    # @param n, an integer
    # @return an integer
    def hammingWeight(self, n):
        s = "{0:b}".format(n)
        result = 0
        print s
        for i in xrange(len(s)):
        	if s[i] == '1':
        		result += 1
        		print result
        return result

sol = Solution()
print sol.hammingWeight(10)