using System;
using System.Collections.Generic;
using System.Text;

namespace L06_GenericTree
{
    class Tree
    {
        static void Main(string[] args)
        {
            var tree = new TreeNode<String>("tree");
            var root = tree.CreateNode("root");

            var child1 = tree.CreateNode("child1");
            child1.AddListener("AppendChild", HandleAppendChild);
            child1.AddListener("RemoveChild", HandleRemoveChild);
            var child2 = tree.CreateNode("child2");
            root.AppendChild(child1);
            root.AppendChild(child2);
            var grand11 = tree.CreateNode("grand11");
            var grand12 = tree.CreateNode("grand12");
            var grand13 = tree.CreateNode("grand13");
            child1.AppendChild(grand11);
            child1.AppendChild(grand12);
            child1.AppendChild(grand13);

            var grand21 = tree.CreateNode("grand21");
            child2.AppendChild(grand21);
            child1.RemoveChild(grand12);

            root.PrintTree();

            // root.ForEach(Func);

            foreach (TreeNode<String> node in root)
                Console.WriteLine(node.value.ToString());
        }
        static void Func(TreeNode<string> treeNode)
        {
            Console.Write(treeNode.value + " | ");
        }
        
        static void HandleAppendChild()
        {
            Console.WriteLine("Child added");
        }
        static void HandleRemoveChild()
        {
            Console.WriteLine("Child removed");
        }
    }

}
