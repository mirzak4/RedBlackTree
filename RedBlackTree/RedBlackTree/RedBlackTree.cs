using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTree
{
    public class RedBlackTree<T> where T : IComparable<T>, IEquatable<T>
    {
        public RedBlackTree() 
        {
            Root = new Node<T>(true);
        }
        public Node<T> Root { get; set; }

        public void LeftRotate(Node<T> x)
        {
            var y = x.Right;

            x.Right = y.Left;

            if (!y.Left.IsNill)
            {
                y.Left.Parent = x;
            }

            y.Parent = x.Parent;

            if (x.Parent.IsNill)
            {
                Root = y;
            }
            else if (x == x.Parent.Left)
            {
                x.Parent.Left = y;
            }
            else 
            {
                x.Parent.Right = y;
            }

            y.Left = x;
            x.Parent = y;
        }

        public void RightRotate (Node<T> y)
        {
            var x = y.Left;

            y.Left = x.Right;

            if (!x.Right.IsNill)
            {
                x.Right.Parent = y;
            }

            x.Parent = y.Parent;

            if (y.Parent.IsNill)
            {
                Root = x;
            }
            else if (y == y.Parent.Left)
            {
                y.Parent.Left = x;
            }
            else
            {
                y.Parent.Right = x;
            }

            x.Right = y;
            y.Parent = x;
        }

        public void Insert(Node<T> z)
        {
            var x = Root;
            Node<T> y = new Node<T>(true);

            while (!x.IsNill)
            {
                y = x;

                if (z.Key.CompareTo(x.Key) < 0)
                {
                    x = x.Left;
                }
                else 
                {
                    x = x.Right;
                }
            }

            z.Parent = y;

            if (y.IsNill)
            {
                Root = z;
            }
            else if (z.Key.CompareTo(y.Key) < 0)
            {
                y.Left = z;
            }
            else
            {
                y.Right = z;
            }

            z.Color = ColorEnum.Red;
            InsertFixUp(z);
        }

        private void InsertFixUp(Node<T> z)
        {
            while (!z.Parent.IsNill && !z.Parent.Parent.IsNill && z.Parent.Color == ColorEnum.Red)
            {
                // If z's parent left child of its parent
                if (z.Parent == z.Parent.Parent.Left)
                {
                    // Uncle is on the right side
                    var y = z.Parent.Parent.Right;

                    // Nill nodes are considered as black
                    if (y.Color == ColorEnum.Red)
                    {
                        z.Parent.Color = ColorEnum.Black;
                        y.Color = ColorEnum.Black;
                        z.Parent.Parent.Color = ColorEnum.Red;
                        z = z.Parent.Parent;
                    }
                    else
                    {
                        if (z == z.Parent.Right)
                        {
                            z = z.Parent;
                            LeftRotate(z);
                        }

                        z.Parent.Color = ColorEnum.Black;
                        z.Parent.Parent.Color = ColorEnum.Red;
                        RightRotate(z.Parent.Parent);
                    }
                }
                else
                {
                    // Uncle is now on the left side
                    var y = z.Parent.Parent.Left;

                    if (y.Color == ColorEnum.Red)
                    {
                        z.Parent.Color = ColorEnum.Black;
                        y.Color = ColorEnum.Black;
                        z.Parent.Parent.Color = ColorEnum.Red;
                        z = z.Parent.Parent;
                    }
                    else
                    {
                        if (z == z.Parent.Left)
                        {
                            z = z.Parent;
                            RightRotate(z);
                        }

                        z.Parent.Color = ColorEnum.Black;
                        z.Parent.Parent.Color = ColorEnum.Red;
                        LeftRotate(z.Parent.Parent);
                    }
                }
            }

            Root.Color = ColorEnum.Black;
        }

        public void Transplant(Node<T> u, Node<T> v)
        {
            if (u.Parent.IsNill)
            {
                Root = v;
            }
            else if (u == u.Parent.Left)
            {
                u.Parent.Left = v;
            }
            else
            {
                u.Parent.Right = v;
            }

            v.Parent = u.Parent;
        }

        public Node<T> TreeMinimum(Node<T> x)
        {
            while (!x.Left.IsNill)
            {
                x = x.Left;
            }
            return x;
        }

        public void Delete(Node<T> z)
        {
            var y = z;
            var originalColorY = y.Color;

            Node<T> x;
            if (z.Left.IsNill)
            {
                // z has only right child
                x = z.Right;
                Transplant(z, z.Right);
            }
            else if (z.Right.IsNill)
            {
                // z has only left child
                x = z.Left;
                Transplant(z, z.Left);
            }
            else
            {
                // z has both children, find smallest element in the z's right subtree
                y = TreeMinimum(z.Right);
                originalColorY = y.Color;

                x = y.Right;

                if (y.Parent == z)
                {
                    // Since y is now taking place of z, and x will be its right child,
                    // we don't want Transplant method to set x parent reference to removed node z
                    x.Parent = y;
                }
                else
                {
                    // y is placed on the last left node of z's right subtree
                    // make sure y's right child takes y's place
                    Transplant(y, y.Right);
                    y.Right = z.Right;
                    y.Right.Parent = y;
                }

                Transplant(z, y);

                y.Left = z.Left;
                y.Left.Parent = y;
                y.Color = z.Color;
            }

            if (originalColorY == ColorEnum.Black)
            {
                DeleteFixUp(x);
            }
        }

        public void DeleteFixUp (Node<T> x) 
        {
            while (x != Root && x.Color == ColorEnum.Black)
            {
                if (x == x.Parent.Left)
                {
                    Node<T> w = x.Parent.Right;

                    // 1st case: x's sibling w is red - convert to case 2/3/4
                    if (w.Color == ColorEnum.Red)
                    {
                        w.Color = ColorEnum.Black;
                        x.Parent.Color = ColorEnum.Red;
                        LeftRotate(x.Parent);
                        w = x.Parent.Right;
                    }

                    // 2nd case: w's both childs are black
                    if ((w.Left.Color == ColorEnum.Black) && (w.Right.Color == ColorEnum.Black))
                    {
                        w.Color = ColorEnum.Red;
                        x = x.Parent;
                    }
                    else
                    {
                        // 3rd case: w's right child is black and left child is red - conver to case 4
                        if (w.Right.Color == ColorEnum.Black)
                        {
                            w.Left.Color = ColorEnum.Black;
                            w.Color = ColorEnum.Red;
                            RightRotate(w);
                            w = x.Parent.Right;
                        }
                        // 4th case: w's right child is red
                        w.Color = x.Parent.Color;
                        x.Parent.Color = ColorEnum.Black;
                        w.Right.Color = ColorEnum.Black;
                        LeftRotate(x.Parent);
                        x = Root;
                    }
                }
                else
                {
                    // Same but symetric
                    Node<T> w = x.Parent.Left;

                    // 1st case: x's sibling w is red - convert to case 2/3/4
                    if (w.Color == ColorEnum.Red)
                    {
                        w.Color = ColorEnum.Black;
                        x.Parent.Color = ColorEnum.Red;
                        RightRotate(x.Parent);
                        w = x.Parent.Left;
                    }

                    // 2nd case: w's both childs are black
                    if ((w.Left.Color == ColorEnum.Black) && (w.Right.Color == ColorEnum.Black))
                    {
                        w.Color = ColorEnum.Red;
                        x = x.Parent;
                    }
                    else
                    {
                        // 3rd case: w's left child is black and right child is red - conver to case 4
                        if (w.Left.Color == ColorEnum.Black)
                        {
                            w.Right.Color = ColorEnum.Black;
                            w.Color = ColorEnum.Red;
                            LeftRotate(w);
                            w = x.Parent.Left;
                        }
                        // 4th case: w's left child is red
                        w.Color = x.Parent.Color;
                        x.Parent.Color = ColorEnum.Black;
                        w.Left.Color = ColorEnum.Black;
                        RightRotate(x.Parent);
                        x = Root;
                    }
                }
            }

            x.Color = ColorEnum.Black;
        }

        public Node<T> Find(T key)
        {
            return FindInner(Root, key);
        }
        private Node<T> FindInner(Node<T> parent, T key)
        {
            // Base Cases: root is nill or key is present at root
            if (parent.IsNill || parent.Key.CompareTo(key) == 0)
                return parent;

            // Key is greater than root's key
            if (parent.Key.CompareTo(key) < 0)
                return FindInner(parent.Right, key);

            // Key is smaller than root's key
            return FindInner(parent.Left, key);
        }

        public List<Node<T>> InOrderTraversal()
        {
            return InOrderTraversalInner(new List<Node<T>>(), Root);
        }

        private List<Node<T>> InOrderTraversalInner(List<Node<T>> traversedNodes ,Node<T> parent)
        {
            if (!parent.IsNill)
            {
                traversedNodes.AddRange(InOrderTraversalInner(new List<Node<T>>(), parent.Left));

                traversedNodes.Add(parent);

                traversedNodes.AddRange(InOrderTraversalInner(new List<Node<T>>(), parent.Right));
            }

            return traversedNodes;
        }
    }
}
