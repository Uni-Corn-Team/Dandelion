using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib.Entities.FallingEntities
{
    class FallingLargeBomb : FallingBomb, ILargeEntity
    {
        public FallingLargeBomb(int damageValue) : base(damageValue)
        {
        }
    }
}
