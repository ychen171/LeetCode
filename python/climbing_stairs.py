class Solution:
    # @param n, an integer
    # @return an integer
    def climbStairs(self, n):
        f1=1
        f2=2
        if n<3:
            return n
        for i in xrange(3,n+1):
            f2 = f1+f2
            f1 = f2-f1
        return f2

sol = Solution()
print sol.climbStairs(5)