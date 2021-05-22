using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib.Statics
{
    static class NumSet
    {
        /// <summary>
        /// is c between a and b (incl)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsIn(int a, int b, int c)
        {
            return c <= b && c >= a;
        }
    }
}
