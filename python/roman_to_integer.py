# I II III IV V VI VII VIII IX X XI XII XIII XIV
# MMMCMXCIX 3999

class Solution:
    numerals = { 'M':1000, 'D':500, 'C':100, 'L':50, 'X':10, 'V':5, 'I':1 }
    # @param {string} s
    # @return {integer}
    def romanToInt(self, s):
        result = 0
        while s:
            first_num = self.numerals[s[0]]
            second_num = self.numerals[s[1]] if len(s) > 1 else -1
            if first_num >= second_num:
                result += first_num
                s = s[1:]
            else:
                result += second_num - first_num
                s = s[2:]
        return result
        
sol = Solution()
print sol.romanToInt('MMMCMXCIX')