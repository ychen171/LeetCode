class Solution:
    # @param {string[]} strs
    # @return {string}
    def longestCommonPrefix(self, strs):
        length = 0
        found = False
        while not found:
            length += 1         
            for i in xrange(len(strs)-1):
                pre = strs[i]
                next = strs[i+1]
                if length > len(pre) or length > len(next):
                    length -= 1
                    found = True
                    break;
                if pre[length-1] != next[length-1]:
                    length -= 1
                    found = True
                    break;
        return strs[0][:length]

sol = Solution()
print sol.longestCommonPrefix(["abc", "abcde", "abcdefg"])
