class Solution:
    # @param {integer[]} nums
    # @return {string}
    def largestNumber(self, nums):
        result = ''
        largest = '0'
        for x in nums:
            if (str(x)[0] > largest):
                largest = x
            elif (str(x)[])
