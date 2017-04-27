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
        public static Node CreateTree(string[] ops, ref int i)
        {
            int val;
            if (int.TryParse(ops[i], out val))
            {
                i++;
                return new Node(val);
            }
            else
            {
                var root = new Node();

                if (ops[i] == "+")
                    root = new Node(-1);
                if (ops[i] == "-")
                    root = new Node(-2);
                if (ops[i] == "*")
                    root = new Node(-3);
                i++;

                root.Right = CreateTree(ops, ref i);
                root.Left = CreateTree(ops, ref i);


                return root;
            }
        }

        public static void ReverseTree(Node n)
        {
            if (n == null) return;

            var t = n.Left;
            n.Left = n.Right;
            n.Right = t;
            ReverseTree(n.Left);
            ReverseTree(n.Right);
        }

        public static void Solve()
        {
            Task("Tree77");

            int i = 0;

            GetString();
            var s = new string(GetString().ToArray());
            var tree = CreateTree(s.Split(' '), ref i);
            ReverseTree(tree);

            Put(tree);

        }
    }
}
