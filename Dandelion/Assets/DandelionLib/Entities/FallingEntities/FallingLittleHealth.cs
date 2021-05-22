using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib.Entities.FallingEntities
{
    class FallingLittleHealth : FallingHealth, ILittleEntity
    {
        public FallingLittleHealth(int healthValue) : base(healthValue)
        {
        }
    }
}
