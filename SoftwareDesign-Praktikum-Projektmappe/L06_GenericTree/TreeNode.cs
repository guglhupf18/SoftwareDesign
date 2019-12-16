using System;
using System.Collections;
using System.Collections.Generic;

namespace L06_GenericTree
{
        

    class TreeNode<T> : IEnumerator<TreeNode<T>>
    {
        public T parent;
        public List<TreeNode<T>> children;

        public TreeNode<T> Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public delegate void Listener();

        public void AddListener(string type, Listener handler)
        {
            Console.WriteLine(type, handler);
        }

        static void HandleAppendChild(TreeNode<T> child)
        {
            Console.WriteLine("Child added" + child.ToString());
        }


        public TreeNode()
        {
            this.children = new List<TreeNode<T>>();
        }
         
        public TreeNode(T node)
        {
            this.parent = node;
            this.children = new List<TreeNode<T>>();

        }

        public TreeNode<T> CreateNode(T node)
        {
            return new TreeNode<T>(node);
        }

        public void AppendChild(TreeNode<T> child)
        {
            // schau nach ob unter appendchild gewisse handler definiert wurden und aufrufen
            children.Add(child);
        }

        public void RemoveChild(TreeNode<T> node)
        {
            children.Remove(node);
 
        }

        public void PrintTree()
        {
            
            Console.WriteLine("Parent:" + this.parent);

            PrintChildren(this);
           

        }

        void PrintChildren(TreeNode<T> node)
        {            
            foreach (TreeNode<T> child in node.children)
            {

                Console.WriteLine(child.parent.ToString());
            }
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
