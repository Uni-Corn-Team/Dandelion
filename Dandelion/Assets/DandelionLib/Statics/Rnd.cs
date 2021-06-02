using System;

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
