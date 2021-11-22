# class Solution:
#     # @param {integer[]} nums
#     # @return {boolean}
#     def containsDuplicate(self, nums):
#         temp_list = []
#         for i in xrange(len(nums)):
#             temp_list.append(nums[i])
#         for i in xrange(len(nums)):
#             n = 0           
#             for j in xrange(len(temp_list)):
#                 if (nums[i] == temp_list[j]):
#                     n += 1
#                     if (n > 1):
#                         return True
#         return False

# sol = Solution()
# print sol.containsDuplicate([1, 2, 3, 4, 6, 6, 7])

# class Solution:
#     # @param {integer[]} nums
#     # @return {boolean}
#     def containsDuplicate(self, nums):
#         temp_list = []
#         while (nums != []):
#             num = nums.pop()
#             for i in xrange(len(temp_list)):
#                 if (temp_list[i] == num):
#                     return True
#             temp_list.append(num)
#         return False

# sol = Solution()
# print sol.containsDuplicate([1, 2, 3, 4, 6, 6, 7])

class Solution:
    # @param {integer[]} nums
    # @return {boolean}
    def containsDuplicate(self, nums):
        temp_Dict = {}
        for i in xrange(len(nums)):
            num = nums[i]
            if num in temp_Dict:
                return True
            else:
                temp_Dict[num] = 1
        return False

sol = Solution()
print sol.containsDuplicate([1, 2, 3, 4, 5, 6, 7])