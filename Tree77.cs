using PT4;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void AddNode(String s, ref Node node)
        {
            if (s == "+")
            {
                node.Left=new Node(-1);
                node.Left.Parent = node;
                node = node.Left;
                return;
            }
            if (s == "-")
            {
                node.Left = new Node(-2);
                node.Left.Parent = node;
                node = node.Left;
                return;
            }
            if (s == "*")
            {
                node.Left = new Node(-3);
                node.Left.Parent = node;
                node = node.Left;
                return;
            }
            if (node.Right == null)
            {
                node.Right = new Node(Int32.Parse(s));
                node.Right.Parent = node;
                return;
            }
            if (node.Left == null)
            {
                node.Left = new Node(Int32.Parse(s));
                node.Left.Parent = node;
                return;
            }
            node = node.Parent;
            AddNode(s, ref node);
        }
        static void Recur(Node r)
        {
            if (r == null) return;
            //Put(r);

            Recur(r.Left);
            Recur(r.Right);

        }

        public static void Solve()
        {
            Task("Tree77");
            var ss = GetString();
            var record = GetString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Node root = new Node();
            if (record[0] == "+") root.Data = -1;
            else if (record[0] == "-") root.Data = -2;
            else if (record[0] == "*") root.Data = -3;
            else root.Data=Int32.Parse(record[0]);
            for (int i=1; i<record.Length; i++)
            {
                AddNode(record[i],ref root);

            }
            //Recur(root);
            Put(root);
            /*
             * var fst = numbers.Dequeue();
            var snd = numbers.Dequeue();
            var op = operation.Pop();
            ShowLine(fst);
            ShowLine(snd);
            ShowLine(op);
            */

        }
    }
}
