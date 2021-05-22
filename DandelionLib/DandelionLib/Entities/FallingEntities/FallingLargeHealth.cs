using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib.Entities.FallingEntities
{
    class FallingLargeHealth : FallingHealth, ILargeEntity
    {
        public FallingLargeHealth(int healthValue) : base(healthValue)
        {
        }
    }
}
