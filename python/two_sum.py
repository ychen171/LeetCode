# class Solution:
#     # @param {integer[]} nums
#     # @param {integer} target
#     # @return {integer[]}
#     def twoSum(self, nums, target):
#         length = len(nums)
#         for i in xrange(length):
#             num1 = nums[i]
#             for j in xrange(i, length):
#                 num2 = nums[j]
#                 if (num1 + num2 == target):
#                     if (num1 < num2):
#                         index1 = i+1
#                         index2 = j+1
#                     else:
#                         index1 = j+1
#                         index2 = i+1
#                     return [index1, index2]
#                 else:
#                     continue
#         return []

# numbers = [2, 7, 11, 15]
# target = 9

# sol = Solution()
# print sol.twoSum(numbers, target)



class Solution:
    # @param {integer[]} nums
    # @param {integer} target
    # @return {integer[]}
    def twoSum(self, nums, target):
        length = len(nums)
        mapping = {}
        for i in xrange(length):
            num1 = nums[i]
            num2 = target - num1
            if num2 in mapping:
                return [mapping[num2]+1, i+1]
            else:
                mapping[num1] = i
                
numbers = [2, 7, 11, 15]
target = 9

sol = Solution()
print sol.twoSum(numbers, target)
