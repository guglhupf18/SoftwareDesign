using System;
using System.Collections;
using System.Collections.Generic;

namespace L06_GenericTree
{


    class TreeNode<T> : IEnumerable <TreeNode<T>>
    {
        public TreeNode<T> parent;
        public List<TreeNode<T>> children;
        public T value;

        public delegate void EventHandler();

        public Dictionary<string, EventHandler> listeners;


        public void AddListener(string type, EventHandler handler)
        {
            listeners.Add(type, handler);
        }

        public void RemoveListener(string type)
        {
            listeners.Remove(type);
        }

        public TreeNode(T value)
        {
            this.value = value;
            this.parent = null;
            this.children = new List<TreeNode<T>>();
            listeners = new Dictionary<string, EventHandler>();
        }


        public TreeNode<T> CreateNode(T value)
        {
            return new TreeNode<T>(value);
        }

        public void AppendChild(TreeNode<T> child)
        {
            // schau nach ob unter appendchild gewisse handler definiert wurden und aufrufen
            if (child.parent != null)
            {
                Console.WriteLine("You don't steal kids from their parents");
                return;
            }

            if (listeners.ContainsKey("AppendChild"))
            {
                EventHandler handler = listeners["AppendChild"];
                handler();
            }

            child.parent = this;
            this.children.Add(child);
        }

        public void RemoveChild(TreeNode<T> node)
        {
            if (listeners.ContainsKey("RemoveChild"))
            {
                EventHandler handler = listeners["RemoveChild"];
                handler();
            }

            node.parent = null;
            this.children.Remove(node);

        }

        public void PrintTree()
        {
            Console.WriteLine(this.value);

            PrintChildren("", this);
        }

        private void PrintChildren(string gen, TreeNode<T> parent)
        {
            gen += "*";

            foreach (TreeNode<T> child in parent.children)
            {
                Console.WriteLine(gen + child.value.ToString());

                PrintChildren(gen, child);
            }
        }

        public TreeNode<T> FindRoot()
        {
            if (parent == null)
                return this;
            else
                return parent.FindRoot();
        }


        public void ForEach(Action<TreeNode<T>> func)
        {
            func(this);

            foreach (var child in children)
            {
                child.ForEach(func);
            }
        }

        public IEnumerator<TreeNode<T>> GetEnumerator()
        {

            yield return this;
            foreach (TreeNode<T> node in this.children)
                foreach (TreeNode<T> child in node)
                    yield return child;

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
