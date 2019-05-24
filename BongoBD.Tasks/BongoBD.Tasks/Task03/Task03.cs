using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BongoBD.Tasks.Task03
{
    public class Task03
    {
        //Solution for Simple Least Common Ancestor without any recursion
        public static Node Lca1(Node node1, Node node2)
        {
            if (node1 == null || node2 == null) return null;

            Node node = node1;
            List<Node> ancestorsOfNode1 = new List<Node> { node };

            while (node.Parent != null)
            {
                node = node.Parent;
                ancestorsOfNode1.Add(node);
            }


            node = node2;
            List<Node> ancestorsOfNode2 = new List<Node> { node };

            while (node.Parent != null)
            {
                node = node.Parent;
                ancestorsOfNode2.Add(node);
            }

            //First common closest node will be LCA
            return ancestorsOfNode1.Intersect(ancestorsOfNode2)?.FirstOrDefault();
        }

        //Solution for Simple Least Common Ancestor with recursion
        public static Node Lca2(Node node1, Node node2)
        {
            if (node1 == null || node2 == null) return null;
            if (node1 == node2) return node1;

            return node1.Value < node2.Value ? Lca2(node1, node2.Parent) : Lca2(node1.Parent, node2);
        }        
    }
}
