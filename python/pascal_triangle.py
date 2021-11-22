class Solution:
    # @param {integer} numRows
    # @return {integer[][]}
    def generate(self, numRows):
        result = []
        for i in xrange(numRows):
            row = []
            for j in xrange(i+1):
                if j == 0:
                    row.append(1)
                elif j == i:
                    row.append(1)
                else:
                    row.append(result[i-1][j-1]+result[i-1][j])
            result.append(row)
        return result

sol = Solution()
print sol.generate(5)