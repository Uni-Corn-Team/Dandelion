using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib.Entities.FallingEntities
{
    class FallingMiddleBomb : FallingBomb, IMiddleEntity
    {
        public FallingMiddleBomb(int damageValue) : base(damageValue)
        {
        }
    }
}
