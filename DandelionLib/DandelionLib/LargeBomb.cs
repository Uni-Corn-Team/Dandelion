using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib
{
    class LargeBomb: FallingBomb, ILargeEntity
    {
        public LargeBomb(int damageValue) : base(damageValue)
        {
        }
    }
}
