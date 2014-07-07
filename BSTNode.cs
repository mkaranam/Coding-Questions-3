using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    class BSTNode
    {
        public int data { get; set; }
        public BSTNode LeftChild { get; set; }
        public BSTNode RightChild { get; set; }
        public BSTNode Parent { get; set; }
    }
}
