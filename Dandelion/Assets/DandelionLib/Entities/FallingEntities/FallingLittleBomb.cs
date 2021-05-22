using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib.Entities.FallingEntities
{
    class FallingLittleBomb : FallingBomb, ILittleEntity
    {
        public FallingLittleBomb(int damageValue) : base(damageValue)
        {
        }
    }
}
