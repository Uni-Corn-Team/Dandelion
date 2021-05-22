using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib.Entities.FallingEntities
{
    class FallingUltimateHeath : FallingHealth, IUltimateEntity
    {
        public FallingUltimateHeath(int healthValue) : base(healthValue)
        {
        }
    }
}
