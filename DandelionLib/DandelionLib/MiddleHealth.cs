using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib
{
    class MiddleHealth: FallingHealth, IMiddleEntity
    {
        public MiddleHealth(int healthValue) : base(healthValue)
        {
        }
    }
}
