using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib
{
    class UltimateBomb : FallingBomb, IUltimateEntity
    {
        public UltimateBomb(int damageValue): base(damageValue)
        {
        }
    }
}
