import timeit

class Solution:
    # @param {integer} rowIndex
    # @return {integer[]}
    def getRow(self, rowIndex):
        if (rowIndex == 0):
            return [1]         
        if (rowIndex == 1):
            return [1,1]
        result = [1] * ((rowIndex + 2) * (rowIndex + 1) / 2)  
        if (rowIndex > 1):
            start = 1
            for i in range(2, rowIndex+1):
                for j in range(i-1):
                    result[start+i+1+j] = result[start+j]+result[start+1+j]
                start += i
            result = result[start:start+rowIndex+1]
            return result

sol = Solution()
start = timeit.timeit()
print sol.getRow(1)
end = timeit.timeit()
print end - start
