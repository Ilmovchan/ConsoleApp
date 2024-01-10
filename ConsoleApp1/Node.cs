using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    public class Tree
    {
        public Node Root { get; set; }

        public Tree()
        {
            Root = null;
        }

        public void Insert(int data)
        {
            Root = InsertRecursive(Root, data);
        }

        private Node InsertRecursive(Node root, int data)
        {
            if (root == null) return new Node(data);

            else if (data < root.Data) root.Left = InsertRecursive(root.Left, data);
            else if (data > root.Data) root.Right = InsertRecursive(root.Right, data);

            return root;
        }

        public void DepthFirstSearch(Node root)
        {
            if (root == null) return;

            DepthFirstSearch(root.Left);
            Console.WriteLine(root.Data);
            DepthFirstSearch(root.Right);
        }

        public Node Search(Node root, int data)
        {
            if (root == null) return null;

            if (data == root.Data) return root;
            return (data < root.Data) ? Search(root.Left, data) : Search(root.Right, data);
        }

        public Node Min(Node root)
        {
            if (root == null) return null;

            if (root.Left == null) return root;
            return Min(root.Left);
        }

        public Node Max(Node root)
        {
            if (root == null) return null;

            if (root.Right == null) return root;
            return Min(root.Right);
        }

        public int Height(Node root)
        {
            if (root == null) return 0;

            else
            {
                int leftHeight = Height(root.Left);
                int rightHeight = Height(root.Right);
                return Math.Max(leftHeight, rightHeight) + 1;
            }
        }

        public void Leaves(Node root)
        {
            if (root == null) return;
            if (root.Left == null && root.Right == null) Console.WriteLine(root.Data);

            Leaves(root.Left);
            Leaves(root.Right);
        }

        public void BreathFirstSearch(Node root)
        {
            if (root == null) return;

            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();

                Console.WriteLine(current.Data);

                if (current.Left != null) queue.Enqueue(current.Left);
                if (current.Right != null) queue.Enqueue(current.Right);

            }
        }
    }
}
