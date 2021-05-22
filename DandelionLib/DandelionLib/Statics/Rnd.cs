using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib.Statics
{
    static class Rnd
    {
        public static Random This { get; private set; }

        static Rnd()
        {
            This = new Random((int)DateTime.Now.Ticks);
        }
    }
}
