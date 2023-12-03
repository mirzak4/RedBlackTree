using Newtonsoft.Json;
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
        public Node() 
        {
            Left = new Node<T>(true)
            {
                Parent = this
            };
            Right = new Node<T>(true)
            {
                Parent = this
            };
        }

        internal Node(bool isNill)
        {
            IsNill = isNill;
            Color = ColorEnum.Black;
        }

        public T Key { get; set; }

        [JsonIgnore]
        public Node<T> Parent { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public ColorEnum Color { get; set; }

        public bool IsNill { get; set; }
    }
}
