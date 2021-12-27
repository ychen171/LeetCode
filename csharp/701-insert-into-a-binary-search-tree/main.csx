#!/usr/bin/env dotnet-script


public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    // iterative
    // Time: O(N)
    // Space: O(1)
    public TreeNode InsertIntoBST(TreeNode root, int val)
    {
        var node = new TreeNode(val);
        if (root == null)
        {
            root = node;
        }
        else
        {
            TreeNode curr = root;
            TreeNode prev = null;
            while (curr != null)
            {
                prev = curr;
                if (curr.val > val)
                    curr = curr.left;
                else
                    curr = curr.right;
            }
            if (prev.val > val)
                prev.left = node;
            else
                prev.right = node;
        }
        return root;
    }

    // Recursive
    // Time: O(H): O(N) in worst, O(log N) in average
    // Space: O(H) O(N) in worst, O(log N) in average
    public TreeNode InsertIntoBSTRecursive(TreeNode root, int val)
    {
        if (root == null) return new TreeNode(val);
        if (root.val > val) 
            root.left = InsertIntoBSTRecursive(root.left, val);
        else
            root.right = InsertIntoBSTRecursive(root.right, val);
        return root;
    }
}







