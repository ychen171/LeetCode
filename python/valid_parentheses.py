class Solution:
    # @param {string} s
    # @return {boolean}
    def isValid(self, s):
        buff = []
        for x in s:
            if (x == '(' or x == '{' or x == '['):
                buff.append(x)
            elif x == ')':
                if buff != [] and buff[-1] == '(':
                    del buff[-1]
                    continue
                else:
                    return False
            elif x == '}':
                if buff != [] and buff[-1] == '{':
                    del buff[-1]
                    continue
                else:
                    return False
            elif x == ']':
                if buff != [] and buff[-1] == '[':
                    del buff[-1]
                    continue
                else:
                    return False
            else:
                continue
        if (buff == []):
            return True
        else:
            return False