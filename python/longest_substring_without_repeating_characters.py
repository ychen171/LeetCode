class Solution:
    # @param {string} s
    # @return {integer}
    def lengthOfLongestSubstring(self, s):
        ls = []
        substr = ""
        count = 0
        ls.append(count)
        for x in s:
            if x not in substr:
                substr += x
                ls[-1] += 1
            else:
                index = substr.find(x)
                substr = substr[index+1:] + x
                # print substr
                count = len(substr)
                ls.append(count)
        result = 0
        if ls != []:
            result = max(ls)
        return result

# s = "pwwkew"
# s = ""
# s = "c"
s = "dvdf"
sol = Solution()
print sol.lengthOfLongestSubstring(s)
