class Solution:
    # @param {integer[]} nums
    # @return {integer}
    # def maxSubArray(self, nums):
    #     max_ending_here = max_so_far = 0
    #     for x in nums:
    #         max_ending_here = max(0, max_ending_here + x)
    #         max_so_far = max(max_so_far, max_ending_here)
    #     return max_so_far

    def maxSubArray(self, nums):
        max_ending_here = max_so_far = nums[0]
        for x in nums[1:]:
            max_ending_here = max(x, max_ending_here + x)
            max_so_far = max(max_so_far, max_ending_here)
        return max_so_far        

sol = Solution()
print sol.maxSubArray([-2,1,-3,4,-1,2,1,-5,4])