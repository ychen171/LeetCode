class Solution:
    # @param {integer[]} nums
    # @return {integer}
    def majorityElement(self, nums):
        d = {}
        n = len(nums)/2
        for x in nums:
            if x in d:
                d[x] += 1
            else:
                d[x] = 1

            if d[x] > n:              
                return x

sol = Solution()
print sol.majorityElement([1, 2, 2, 2, 2, 2, 2, 3, 4, 5])