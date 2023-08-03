namespace Leetcode150;

public static class Trees
{
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val=0, TreeNode left=null, TreeNode right=null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }


    public static TreeNode InvertTree(TreeNode root)
    {
        if (root == null) return root;
        if (root.left != null || root.right != null)
        {
            var tmp = root.left;
            root.left = root.right;
            root.right = tmp;
            InvertTree(root.left);
            InvertTree(root.right);
        }

        return root;
    }

    public static int MaxDepth(TreeNode root)
    {
        int Loop(TreeNode root, int acc)
        {
            if (root == null) return acc;
            return Math.Max(Loop(root.left, acc + 1), Loop(root.right, acc + 1));
        }

        return Loop(root, 0);
    }

    public static int DiameterOfBinaryTree(TreeNode root)
    {
        var diameter = 0;
        
        int Loop(TreeNode root)
        {
            if (root == null) return 0;
            
            var leftDepth = Loop(root.left);
            var rightDepth = Loop(root.right);
            
            diameter = Math.Max(diameter, leftDepth + rightDepth);
            return Math.Max(leftDepth, rightDepth) + 1;
        }

        Loop(root);

        return diameter;
    }
    
}