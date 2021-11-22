# class Solution:
#     # @param triangle, a list of lists of integers
#     # @return an integer
#     def minimumTotal(self, triangle):
#         i = 0
#         j = 0
#         total = triangle[i][j]
#         while (i < len(triangle)-1):
#             i += 1
#             if (triangle[i][j] > triangle[i][j+1]):
#                 j += 1
#             total += triangle[i][j]
#         return total


# http://fisherlei.blogspot.com/2013/01/leetcode-triangle.html
class Solution:
    # @param triangle, a list of lists of integers
    # @return an integer
    def minimumTotal(self, triangle):
        row = len(triangle)
        if (row == 0):
            return 0
        minV = [0] * len(triangle[row-1])
        for i in xrange(row-1, -1, -1):
            col = len(triangle[i])
            for j in xrange(col):
                if (i == row-1):
                    minV[j] = triangle[i][j]
                    continue
                minV[j] = min(minV[j], minV[j+1]) + triangle[i][j]
        return minV[0]


sol = Solution()
tri1 = [[2], [3, 4], [6, 5, 7], [4, 1, 8, 3]]
tri2 = [[-1],[2,3],[1,-1,-3]]
print sol.minimumTotal(tri1)
print sol.minimumTotal(tri2)



