using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib.Entities.FallingEntities
{
    class FallingUltimateBomb : FallingBomb, IUltimateEntity
    {
        public FallingUltimateBomb(int damageValue): base(damageValue)
        {
        }
    }
}
