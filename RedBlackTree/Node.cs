using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTree
{
    public class Node<T> where T : IComparable<T>
    {
        public T Key { get; set;}

        public Node<T> Parent { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public ColorEnum Color { get; set; }
    }
}
