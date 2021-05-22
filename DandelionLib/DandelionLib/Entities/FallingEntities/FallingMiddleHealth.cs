using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib.Entities.FallingEntities
{
    class FallingMiddleHealth : FallingHealth, IMiddleEntity
    {
        public FallingMiddleHealth(int healthValue) : base(healthValue)
        {
        }
    }
}
