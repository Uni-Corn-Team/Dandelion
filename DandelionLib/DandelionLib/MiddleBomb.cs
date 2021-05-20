using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib
{
    class MiddleBomb: FallingBomb, IMiddleEntity
    {
        public MiddleBomb(int damageValue) : base(damageValue)
        {
        }
    }
}
