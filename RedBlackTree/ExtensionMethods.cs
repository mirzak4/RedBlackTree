using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTree
{
    public static class ExtensionMethods
    {
        public static bool IsNill<T>(this T obj) where T : class
        {
            return obj == null;
        }
    }
}
