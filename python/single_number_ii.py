# class Solution:
#     # @param {integer[]} nums
#     # @return {integer}
#     def singleNumber(self, nums):
#         sorted_nums = sorted(nums)
#         print sorted_nums
#         result = None
#         if len(nums) == 0:
#             return result
#         elif len(nums) < 3:
#             result = nums[0]
#             return result
#         else:
#             first1 = sorted_nums[0]
#             first2 = sorted_nums[1]
#             if (first1 != first2):
#                 return first1 
#             flag = 0
#             for i in xrange(1, len(sorted_nums)-1):
#                 prev = sorted_nums[i-1]
#                 curr = sorted_nums[i]
#                 if (prev != curr):
#                     flag += 1
#                 else:
#                     flag = 0
#                 if (flag == 2):
#                     result = prev
#                     return result
#             last2 = sorted_nums[len(sorted_nums)-2]
#             last1 = sorted_nums[len(sorted_nums)-1]
#             if (last2 != last1):
#                 return last1

# sol = Solution()

# print sol.singleNumber([-2,-2,1,1,-3,1,-3,-3,-4,-2])

class Solution:
    # @param {integer[]} nums
    # @return {integer}
    def singleNumber(self, nums):
        r = 0
        c = 0
        n = len(nums)
        while (n > 0):
            n -= 1
            t = 


sol = Solution()

print sol.singleNumber([-2,-2,1,1,-3,1,-3,-3,-4,-2])