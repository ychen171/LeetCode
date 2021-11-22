# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, x):
#         self.val = x
#         self.left = None
#         self.right = None

# class Solution:
#     # @param {TreeNode} root
#     # @param {integer} sum
#     # @return {boolean}
#     def hasPathSum(self, root, sum):
#         temp = 0
#         result = False
#         self.add(root, sum, temp, result)
#         return result

#     def add(self, root, sum, temp, result):
#         if root == None:
#             if (temp == sum and result != True):
#                 result = True
#         else:
#             temp += root.val
#             self.add(root.left, sum, temp, result)
#             self.add(root.right, sum, temp, result)


class Solution:
    # @param {TreeNode} root
    # @param {integer} sum
    # @return {boolean}
    def hasPathSum(self, root, sum):
        if root is None:
            return False
        cur_sum = sum - root.val
        if cur_sum == 0 and self.is_leaf(root):
            return True

        result = self.hasPathSum(root.left, cur_sum) or self.hasPathSum(root.right, cur_sum)
        return result

    def is_leaf(self, root):
        return not root.left and not root.right