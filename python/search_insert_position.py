class Solution:
    # @param {integer[]} nums
    # @param {integer} target
    # @return {integer}
    def searchInsert(self, nums, target):
        index = 0
        for i in xrange(len(nums)):
            source = nums[i]
            if (source < target):
                index = i + 1
            else:
                return i
        return index

sol = Solution()
print sol.searchInsert([1, 3, 5, 6], 0)