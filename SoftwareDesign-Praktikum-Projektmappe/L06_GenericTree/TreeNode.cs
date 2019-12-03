using System;
using System.Collections.Generic;

namespace L06_GenericTree
{
    class TreeNode<T>
    {
        TreeNode<T> parent;
        List<TreeNode<T>> children;
        TreeNode<T> root;

        public TreeNode<T> CreateNode(TreeNode<T> node)
        {
            return node;
        }
        public void AppendChild(TreeNode<T> child)
        {
            parent = this;
            children.Add(child);            
                      
        }

        public void RemoveChild(TreeNode<T> node)
        {
            children.Remove(node);
 
        }

        public void PrintTee()
        {
            Console.WriteLine("Parent: " + parent);
            for (int i = 0; i < children.Count; i++)
                Console.WriteLine("Children" + children[i] + "\n");
            Console.WriteLine("Root:" + root);
        }
    }
}
