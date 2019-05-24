using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BongoBD.Tasks.Task03
{
    public class Node
    {
        public Node Parent { get; set; }
        public int Value { get; set; }

        public Node(Node parent, int d)
        {
            this.Parent = parent;
            this.Value = d;
        }
    }
}
