# I II III IV V VI VII VIII IX X XI XII XIII XIV
# MMMCMXCIX 3999

class Solution:
    roman_numeral_map = (('M', 1000), ('CM', 900), 
        ('D', 500), ('CD', 400), 
        ('C', 100), ('XC', 90), 
        ('L', 50), ('XL', 40), 
        ('X', 10), ('IX', 9), 
        ('V', 5), ('IV', 4), 
        ('I', 1))
    # @param {integer} num
    # @return {string}
    def intToRoman(self, num):
        result = ""
        for numeral, integer in self.roman_numeral_map:
            while num >= integer:
                result += numeral
                num -= integer
        return result

sol = Solution()
print sol.intToRoman(3999)