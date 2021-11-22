#!/usr/bin/env python
# -*- coding: utf-8 -*-
# Yu Chen
#

class Solution:
    # @param prices, a list of integer
    # @return an integer
    def max_profit(self, prices):
        profit = 0
        for i in range(len(prices)-1):
            if prices[i+1] > prices[i]:
                profit += prices[i+1]-prices[i]
        return profit

def main():
    prices = [1,5,2,7,4,8,4,87,4,6,9,24]
    s = Solution()
    profit = s.max_profit(prices)
    print profit

if __name__ == '__main__':
    main()