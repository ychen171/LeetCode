class Solution:
    # @param {integer} n
    # @return {string[]}
    def generateParenthesis(self, n):
        left = 0
        right = 0
        s = ''
        results = []
        self.process(s, left, right, n, results)
        return results
 
    def process(self, s, left, right, n, results):       
        if (left < n):
            if (left >= right):
                self.process(s + '(', left+1, right, n, results)
                self.process(s + ')', left, right+1, n, results)              
        elif (left == n):
            if (left > right):
                self.process(s + ')', left, right+1, n, results)
            elif (left == right):
                results.append(s)

sol = Solution()
print sol.generateParenthesis(3)
