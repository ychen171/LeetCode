class Solution:
    # @param s, a string
    # @param wordDict, a set<string>
    # @return a boolean
    # def wordBreak(self, s, wordDict):
    #     begin = 0
    #     end = 0
    #     for end in xrange(len(s)+1):
    #         seg = s[begin:end]
    #         if seg in wordDict:
    #             # wordDict.remove(seg)
    #             begin = end
    #     if (begin == end):
    #         return True
    #     else:
    #         return False

    def wordBreak(self, s, wordDict):
        length = len(s)
        if length==0:
            return False
        stack = [] # Stack to track the last character in each word
        stack.append(-1)  # So that the program checks if the whole string is just one word
        for i in range(length):
            for j in stack[::-1]:
                if s[j+1:i+1] in wordDict:
                    stack.append(i)
                    break
        if length-1 in stack:
            return True
        else:
            return False


# s = 'leetcode'
# wordDict = ['leet', 'code']
s = 'aaaaaaa'
wordDict = ['aaaa', 'aaa']
# s = 'bb'
# wordDict = ['a', 'b', 'bbb', 'bbbb']
sol = Solution()
print sol.wordBreak(s, wordDict)