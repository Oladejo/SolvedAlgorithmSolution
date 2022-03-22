using System;
using System.Collections.Generic;

namespace DepthBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Minimum Depth of Binary Tree");

            BinaryTree tree = new()
            {
                root = new Node(1)
            };
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);
            tree.root.left.left.left = new Node(6);

            Console.WriteLine("The minimum depth of binary tree is : " + tree.minimumDepth());


            TreeNode root = newNode(1);
            root.left = newNode(2);
            root.right = newNode(3);
            root.left.left = newNode(4);
            root.left.right = newNode(5);
            root.left.left.left = newNode(6);

            Console.WriteLine($"Traversal: {minDepth(root)}");
        }

        //Level Order Traversal
        static int minDepth(TreeNode root)
        {
            if (root == null) return 0;

            Queue<QueueItem> queueItems = new Queue<QueueItem>();

            // Enqueue Root and initialize depth as 1
            var qi = new QueueItem(root, 1);
            queueItems.Enqueue(qi);

            while (queueItems.Count != 0)
            {
                Console.WriteLine($"Queue Items count {queueItems.Count}");

                // Remove the front queue item
                qi = queueItems.Peek(); //O(1)
                queueItems.Dequeue();   //0(1)

                // Get details of the remove item
                TreeNode node = qi.node;
                int depth = qi.depth;

                if (node.left == null && node.right == null)
                    return depth;

                if (node.left != null)
                {
                    qi.node = node.left;
                    qi.depth = depth + 1;
                    queueItems.Enqueue(qi);
                }

                if (node.right != null)
                {
                    qi.node = node.right;
                    qi.depth = depth + 1;
                    queueItems.Enqueue(qi);
                }
            }

            return 0;
        }

        static TreeNode newNode(int data)
        {
            return new TreeNode
            {
                value = data,
                left = null,
                right = null
            };
        }
    }

    /* Class containing left and right child of current
     node and key value*/
    public class Node
    {
        public int data;
        public Node left, right;
        public Node(int item)
        {
            data = item;
            left = right = null;
        }
    }

    //Recursive Process
    public class BinaryTree
    {
        public Node root;

        public virtual int minimumDepth()
        {
            return minimumDepth(root);
        }

        //This is recursive process
        public virtual int minimumDepth(Node root)
        {
            // Corner case. Should never be hit unless the code is
            // called on root = NULL
            if (root == null) return 0;

            // Base case : Leaf Node. This accounts for height = 1.
            if (root.left == null && root.right == null) return 1;

            // If left subtree is NULL, recur for right subtree
            if (root.left == null) return minimumDepth(root.right) + 1;

            // If right subtree is NULL, recur for left subtree
            if (root.right == null) return minimumDepth(root.left) + 1;

            return Math.Min(minimumDepth(root.left), minimumDepth(root.right)) + 1;

        }
    }

    
    public class TreeNode
    {
        public int value;
        public TreeNode left, right;
    }

    // A queue item (Stores pointer to node and an integer)
    public class QueueItem
    {
        public TreeNode node;
        public int depth;
        public QueueItem(TreeNode _node, int _depth)
        {
            node = _node;
            depth = _depth;
        }
    }

}
