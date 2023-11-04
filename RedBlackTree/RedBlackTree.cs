using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTree
{
    public class RedBlackTree<T> where T : IComparable<T>, IEquatable<T>
    {
        public Node<T> Root { get; set; }

        public void LeftRotate(Node<T> x)
        {
            var y = x.Right;

            x.Right = y.Left;

            if (!y.Left.IsNill())
            {
                y.Left.Parent = x;
            }

            y.Parent = x.Parent;

            if (x.Parent.IsNill())
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

            if (!x.Right.IsNill())
            {
                x.Right.Parent = y;
            }

            x.Parent = y.Parent;

            if (y.Parent.IsNill())
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
            Node<T> y = null;

            while (!x.IsNill())
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

            if (y.IsNill())
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
            while (!z.Parent.IsNill() && !z.Parent.Parent.IsNill() && z.Parent.Color == ColorEnum.Red)
            {
                // If z's parent left child of its parent
                if (z.Parent == z.Parent.Parent.Left)
                {
                    // Uncle is on the right side
                    var y = z.Parent.Parent.Right;

                    // Nill nodes are considered as black
                    if (!y.IsNill() && y.Color == ColorEnum.Red)
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

                    if (!y.IsNill() && y.Color == ColorEnum.Red)
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
            if (u.Parent.IsNill())
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

        public Node<T> TreeMinimum(Node<T> parent)
        {
            return null;
        }

        public void Delete(Node<T> z)
        {
            var y = z;
            Node<T> x = null;
            var originalColorY = y.Color;

            if (z.Left.IsNill())
            {
                x = z.Right;
                Transplant(z, z.Right);
            }
            else if (z.Right.IsNill()) 
            {
                x = z.Left;
                Transplant(z, z.Left);
            }
            else
            {
                y = TreeMinimum(z.Right);
                originalColorY = y.Color;
                
                x = y.Right;

                if (y.Parent == z)
                {
                    x.Parent = y;
                }
                else
                {
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
            
        }

        public List<Node<T>> InOrderTraversal()
        {
            return InOrderTraversalInner(new List<Node<T>>(), Root);
        }

        private List<Node<T>> InOrderTraversalInner(List<Node<T>> traversedNodes ,Node<T> parent)
        {
            if (parent != null)
            {
                traversedNodes.AddRange(InOrderTraversalInner(new List<Node<T>>(), parent.Left));

                traversedNodes.Add(parent);

                traversedNodes.AddRange(InOrderTraversalInner(new List<Node<T>>(), parent.Right));
            }

            return traversedNodes;
        }
    }
}
