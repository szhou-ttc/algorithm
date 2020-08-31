using System.Collections.Generic;

namespace Algorithm
{
    public class BinaryTree
    {
        public Node Root { get; set; }
        public BinaryTree()
        {

        }

        public BinaryTree(int rootData)
        {
            Root = new Node { Data = rootData };
        }

        public void Insert(int data)
        {

            Node newNode = new Node
            {
                Data = data,
            };
            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                Node parent = Root;
                Node node = Root;
                while (node != null)
                {
                    parent = node;
                    if (node.Data < data)
                    {
                        node = node.Right;

                    }
                    else
                    {
                        node = node.Left;
                    }

                }
                if (parent.Data < data) parent.Right = newNode;
                else parent.Left = newNode;
            }

        }

        public void InsertRec(Node parent, Node newNode)
        {
            if (parent.Data < newNode.Data)
            {
                if (parent.Right == null) parent.Right = newNode;
                else InsertRec(parent.Right, newNode);
            }
            else
            {
                if (parent.Left == null) parent.Left = newNode;
                else InsertRec(parent.Left, newNode);
            }
        }

        public int GetHeight()
        {
            return getMaxDepth(Root) - 1;

        }

        public void SetLeft(Node node, int data)
        {
            node.Left = new Node { Data = data };
        }

        public void SetRight(Node node, int data)
        {
            node.Right = new Node { Data = data };
        }
        public List<int> Preorder(Node root)
        {
            List<int> result = new List<int>();
            if(root!=null)
            {
                result.Add(root.Data);
                result.AddRange(Preorder(root.Left));
                result.AddRange(Preorder(root.Right));
            }
            return result;
        }
        public List<int> Inorder(Node root)
        {
            List<int> result = new List<int>();
            if (root!=null)
            {
                result.AddRange(Inorder(root.Left));
                result.Add(root.Data);
                result.AddRange(Inorder(root.Right));

            }
            return result;
        }

        public List<int> Postorder(Node root)
        {
            List<int> result = new List<int>();
            if (root != null)
            {
                result.AddRange(Postorder(root.Left));
                result.AddRange(Postorder(root.Right));
                result.Add(root.Data);
                

            }
            return result;
        }

        private int getMaxDepth(Node root)
        {
            if (root == null) return 0;
            else
            {
                int leftDepth = getMaxDepth(root.Left);
                int rightDepth = getMaxDepth(root.Right);
                if (leftDepth > rightDepth) return leftDepth + 1;
                else return rightDepth + 1;
            }
        }
    }
}
