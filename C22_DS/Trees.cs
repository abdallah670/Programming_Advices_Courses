using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C22_DS
{
    public class TreeNode<T>
    {
        public T Value;
        public List<TreeNode<T>> Children { get; set; }
        public TreeNode(T value) { Value = value; Children = new List<TreeNode<T>>(); }
        public void AddChild(TreeNode<T> child)
        {
            Children.Add(child);
        }
        public TreeNode<T> FindNode(TreeNode<T> node, T value)
        {
            if (this == null)
                return null;
            if (EqualityComparer<T>.Default.Equals(Value, value))
            {
                return this;
            }
            foreach (var child in Children)
            {
                var foundNode = child.FindNode(child, value);
                if (foundNode != null)
                {
                    return foundNode;
                }
            }
            return null; // Not found
        }

    }
    public class Tree<T>
    {
        public TreeNode<T> Root { get; set; }
        public Tree(T value)
        {
            Root = new TreeNode<T>(value);
        }
        public void AddChild(TreeNode<T> parent, T value)
        {
            TreeNode<T> child = new TreeNode<T>(value);
            parent.AddChild(child);
        }
        public void PrintTree(TreeNode<T> node, string indent = "")
        {
            Console.WriteLine(indent + node.Value);


            foreach (var child in node.Children)
            {
                PrintTree(child, indent + "  ");
            }
        }
        public TreeNode<T> Find(T value)
        {
            return
            Root?.FindNode(Root, value); // Call the FindNode method on the root node
        }
       

    }
    //Binary Tree Node
    public class BinaryTreeNode<T>
    {
        public T Value;
        public BinaryTreeNode<T> Left;
        public BinaryTreeNode<T> Right;

        public BinaryTreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }
    //Binary Tree
    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root;

        public BinaryTree(T value)
        {
            Root = new BinaryTreeNode<T>(value);
        }
        private void insert(BinaryTreeNode<T> node, BinaryTreeNode<T> newNode)
        {
            if (Comparer<T>.Default.Compare(newNode.Value, node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = newNode;
                }
                else
                {
                    insert(node.Left, newNode);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = newNode;
                }
                else
                {
                    insert(node.Right, newNode);
                }
            }
        }
        public void insert(T value)
        {
            BinaryTreeNode<T> newNode = new BinaryTreeNode<T>(value);
            if (Root == null)
            {
                Root = newNode;
            }
            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                BinaryTreeNode<T> current = queue.Dequeue();
                if (current.Left == null)
                {
                    current.Left = newNode;
                    return;
                }
                else
                {
                    queue.Enqueue(current.Left);
                }
                if (current.Right == null)
                {
                    current.Right = newNode;
                    return;
                }
                else
                {
                    queue.Enqueue(current.Right);
                }
            }
        }
        public void PrintTree(BinaryTreeNode<T> node, int level)
        {
            if (node == null)
                return;

            PrintTree(node.Right, level + 1);
            Console.WriteLine(new string(' ', 4 * level) + node.Value);
            PrintTree(node.Left, level + 1);
        }
        public void PreorderTraversal(BinaryTreeNode<T> node)
        {
            if (node == null)
                return;
            Console.Write(node.Value + " ");
            PreorderTraversal(node.Left);
            PreorderTraversal(node.Right);
        }
        public void InorderTraversal(BinaryTreeNode<T> node)
        {
            if (node == null)
                return;
            InorderTraversal(node.Left);
            Console.Write(node.Value + " ");
            InorderTraversal(node.Right);
        }
        public void PostorderTraversal(BinaryTreeNode<T> node)
        {
            if (node == null)
                return;
            PostorderTraversal(node.Left);
            PostorderTraversal(node.Right);
            Console.Write(node.Value + " ");
        }
        public void PrintTree()
        {
            PrintTree(Root, 0);
        }
    }
    //BST

    
    // Example usage
    public class ExampleofTree
    {
        public static void ExampleofGeneralTree()
        {
            // Create just one tree
            Tree<string> familyTree = new Tree<string>("Salih");

            // Add children directly to the tree
            var sadiq = new TreeNode<string>("Sadiq");
            var wathiq = new TreeNode<string>("Wathiq");
            var hafidh = new TreeNode<string>("Hafidh");
            var riyadh = new TreeNode<string>("Riyadh");

            familyTree.Root.AddChild(sadiq);
            familyTree.Root.AddChild(wathiq);
            familyTree.Root.AddChild(hafidh);
            familyTree.Root.AddChild(riyadh);

            // Add grandchildren
            sadiq.AddChild(new TreeNode<string>("Mustafa"));
            sadiq.AddChild(new TreeNode<string>("Omar"));

            wathiq.AddChild(new TreeNode<string>("Mohammed"));
            wathiq.AddChild(new TreeNode<string>("Abdul Salam"));
            wathiq.AddChild(new TreeNode<string>("Ahmed"));
            // ... rest of your family tree

            // Now search will work correctly
            string searchValue = "Ahmed";
            TreeNode<string> foundNode = familyTree.Find(searchValue);

            Console.WriteLine(
                foundNode != null ? $"Node with value '{searchValue}' found." : $"Node with value '{searchValue}' not found.");
        }
        public static void ExampleofBinaryTree()
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>(10);
            binaryTree.insert(5);
            binaryTree.insert(15);
            binaryTree.insert(3);
            binaryTree.insert(7);
            binaryTree.insert(12);
            binaryTree.insert(18);
            // Print the tree structure
            binaryTree.PrintTree();
            Console.WriteLine("Preorder Traversal:");
            binaryTree.PreorderTraversal(binaryTree.Root);
            Console.WriteLine("\nInorder Traversal:");
            binaryTree.InorderTraversal(binaryTree.Root);
            Console.WriteLine("\nPostorder Traversal:");
            binaryTree.PostorderTraversal(binaryTree.Root);
        }


    }
   
}
