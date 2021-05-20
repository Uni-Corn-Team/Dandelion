using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib
{
    class LittleBomb: FallingBomb, ILittleEntity
    {
        public LittleBomb(int damageValue) : base(damageValue)
        {
        }
    }
}
