class Solution:
    # @param {string} a
    # @param {string} b
    # @return {string}
    def addBinary(self, a, b):
        len_a = len(a)
        len_b = len(b)
        int_a = 0
        int_b = 0
        for i in xrange(len_a):
            int_a += int(a[i]) * 2**(len_a-1-i)
        for i in xrange(len_b):
            int_b += int(b[i]) * 2**(len_b-1-i)
        int_c = int_a + int_b
        return "{0:b}".format(int_c)


a = '11'
b = '1'
sol = Solution()
print sol.addBinary(a, b)