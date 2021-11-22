# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, x):
#         self.val = x
#         self.next = None

class Solution:
    # @param {ListNode} head
    # @return {ListNode}
    def deleteDuplicates(self, head):
        if (head == None or head.next == None):
            return head
        pre = head
        cur = head.next
        while (cur != None):
            if (pre.val == cur.val):
                cur = cur.next
                pre.next = cur
            pre = pre.next
            cur = cur.next
        return head