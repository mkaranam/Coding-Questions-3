using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    class BST
    {
        private BSTNode root;
        public int size { get; set; }

        public BST()
        {
            root = new BSTNode();
        }

        public void put(int d)
        {
            if (size == 0)
            {
                root.data = d;
                size++;
                return;
            }
            put(root, d);
        }

        private void put(BSTNode n, int d)
        {
            if (n == null) return;
            if (d <= n.data)
            {
                //Use left child
                if (n.LeftChild == null)
                {
                    BSTNode b = new BSTNode();
                    b.data = d;
                    n.LeftChild = b;
                    b.Parent = n;
                    size++;
                    return;
                }
                else
                {
                    put(n.LeftChild, d);
                }
            }
            else
            {
                //Use right child
                if (n.RightChild == null)
                {
                    BSTNode b = new BSTNode();
                    b.data = d;
                    n.RightChild = b;
                    b.Parent = n;
                    size++;
                    return;
                }
                else
                {
                    put(n.RightChild, d);
                }
            }
        }

        public bool remove(int d)
        {
            BSTNode n = find(d);
            if (n == null) return false;
            BSTNode rN = getLeaf(n.RightChild, true);
            if (rN == null) n = null;
            else
            {
                n.data = rN.data;
                rN = null;
            }
            size--;
            return true;
        }

        public BSTNode find(int d)
        {
            return find(root, d);
        }

        private BSTNode find(BSTNode n, int d)
        {
            if (n == null) return null;
            if (n.data == d) return n;
            if (d < n.data) return find(n.LeftChild, d);
            return find(n.RightChild, d);
        }

        private BSTNode getLeaf(BSTNode n, Boolean isleft)
        {
            if (n == null) return null;
            if (isleft)
            {
                if (n.LeftChild == null) return n;
                return getLeaf(n.LeftChild, isleft);
            }
            else
            {
                if (n.RightChild == null) return n;
                return getLeaf(n.RightChild, isleft);
            }
        }

        public bool IsBalanced()
        {
            int height = 0;
            return isBalanced(root, ref height);
        }

        private bool isBalanced(BSTNode node, ref int height)
        {
            if (node == null)
            {
                height = 0;
                return true;
            }
            if (node.LeftChild == null && node.RightChild == null)
            {
                height = 1;
                return true;
            }
            int lH, rH;
            lH = rH = 0;
            if (!(isBalanced(node.LeftChild, ref lH) && isBalanced(node.RightChild, ref rH)))
            {
                height = -1;
                return false;
            }
            if (Math.Abs(lH - rH) > 1)
            {
                height = -1;
                return false;
            }
            height = 1 + Math.Max(lH, rH);
            return true;
        }


        public void createTree(int[] input)
        {
            if (input.Length == 0) return;
            root = createTree(input, 0, input.Length - 1);

        }

        private BSTNode createTree(int[] input, int low, int high)
        {
            if (low > high) return null;
            if (low == high)
            {
                BSTNode node = new BSTNode();
                node.data = input[low];
                return node;
            }

            int mid = (low + high) / 2;
            BSTNode localRoot = new BSTNode();
            localRoot.data = input[mid];
            BSTNode leftChild = createTree(input, low, mid - 1);
            BSTNode rightChild = createTree(input, mid + 1, high);
            
            if(leftChild!=null) leftChild.Parent = localRoot;
            if(rightChild!=null) rightChild.Parent = localRoot;
            localRoot.LeftChild = leftChild;
            localRoot.RightChild = rightChild;

            return localRoot;
        }

        public List<List<BSTNode>> LevelOrderTraversal()
        {
            List<List<BSTNode>> levels = new List<List<BSTNode>>();
            List<BSTNode> curLevel = new List<BSTNode>();
            curLevel.Add(root);
            while (curLevel.Count > 0)
            {
                List<BSTNode> nextLevel = new List<BSTNode>();
                foreach (BSTNode node in curLevel)
                {
                    if (node.LeftChild != null) nextLevel.Add(node.LeftChild);
                    if (node.RightChild != null) nextLevel.Add(node.RightChild);
                }
                levels.Add(curLevel);
                curLevel = nextLevel;
            }
            return levels;
        }

        public void NextNode(int data)
        {
            BSTNode node = find(data);
            node = NextNode(node);
            if (node != null) Console.WriteLine("Next node is {0}", node.data);
            else Console.WriteLine("This is the last node");
        }

        public BSTNode NextNode(BSTNode node)
        {
            if (node == null) return null;
            //If has left child return
            if (node.LeftChild != null) return node.LeftChild;
            //If no left child, but has right child return left most child in the right tree
            if (node.RightChild != null)
            {
                BSTNode next = node.RightChild;
                while (next.LeftChild != null) next = next.LeftChild;
                return next;
            }

            //No children, so most recent ancestor not in the left subtree
            BSTNode current = node;
            BSTNode parent = current.Parent;
            while (parent != null)
            {
                if (parent.LeftChild == current)
                {
                    return parent;
                }
                current = parent;
                parent = parent.Parent;
            }
            return null;
        }

        public String FindPath(int m, int n)
        {
            BSTNode node1 = find(m);
            BSTNode node2 = find(n);
            if (node1 == null || node2 == null) throw new System.ArgumentNullException();
            if (node1 == node2) return node1.data.ToString();
            BSTNode LCA = CommonAncestor(root, node1, node2);
            StringBuilder sb1 = new StringBuilder();
            BSTNode parent = node1.Parent;
            sb1.Append(node1.data + " ");
            while (parent != LCA)
            {
                sb1.Append(parent.data + " ");
                parent = parent.Parent;
            }
            parent = node2.Parent;
            StringBuilder sb2 = new StringBuilder();
            sb2.Append(node2.data + " ");
            while (parent != LCA)
            {
                sb2.Append(parent.data + " ");
                parent = parent.Parent;
            }
            return sb1.Append(LCA.data+ " "+ sb2.ToString()).ToString();
        }

        private BSTNode CommonAncestor(BSTNode localroot, BSTNode n1, BSTNode n2)
        {
            if (n1.Parent == localroot || n2.Parent == localroot) return localroot;
            int lCount = covers(localroot.LeftChild, n1, n2);
            int rCount = covers(localroot.RightChild, n1, n2);
            if (lCount == 2) return CommonAncestor(localroot.LeftChild, n1, n2);
            else if (rCount == 2) return CommonAncestor(localroot.RightChild, n1, n2);
            else return localroot;
        }

        private int covers(BSTNode localroot, BSTNode n1, BSTNode n2)
        {
            int foundCount = 0;
            if (find(localroot, n1.data) != null) foundCount++;
            if (find(localroot, n2.data) != null) foundCount++;
            return foundCount;
        }
    }
}
