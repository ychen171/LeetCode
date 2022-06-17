
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
    // DFS | Recursion | Bottom-up
    // Time: O(n)
    // Space: O(h)
    int cameraCount = 0;
    public int MinCameraCover(TreeNode root)
    {
        var rootState = Helper(root);
        if (rootState == State.UNCOVERED)
            cameraCount++;
        return cameraCount;
    }

    private State Helper(TreeNode node)
    {
        // base case: if there is no node then it's already covered
        if (node == null)
            return State.COVERED;

        // recursive case
        // try left child and right child
        var leftState = Helper(node.left);
        var rightState = Helper(node.right);

        // if any one of the direct children is uncovered, we must place a camera at current node
        if (leftState == State.UNCOVERED || rightState == State.UNCOVERED)
        {
            cameraCount++;
            return State.CAMERA;
        }
        // If any one of the direct children has camera, the currnt node is covered
        if (leftState == State.CAMERA || rightState == State.CAMERA)
        {
            return State.COVERED;
        }
        // if none of the direct children can cover the current node, ask the parent to cover
        return State.UNCOVERED;
    }
}

public enum State { CAMERA, COVERED, UNCOVERED }
