class Solution:
    # @param {string} version1
    # @param {string} version2
    # @return {integer}
    def compareVersion(self, version1, version2):
        str1 = version1.split('.')
        str2 = version2.split('.')

        if (len(str1) > len(str2)):
            for i in xrange(len(str1)-len(str2)):
                str2.append('0')
        if (len(str1) < len(str2)):
            for i in xrange(len(str2)-len(str1)):
                str1.append('0')             
        for i in xrange(len(str1)):
            num1 = int(str1[i])
            num2 = int(str2[i])
            if (num1 > num2):
                return 1
            elif (num1 < num2):
                return -1
        return 0


sol = Solution()
print sol.compareVersion('0.1', '1.2')
print sol.compareVersion('1.1', '1.2')
print sol.compareVersion('13.37', '1.2')
print sol.compareVersion('1.1', '1')