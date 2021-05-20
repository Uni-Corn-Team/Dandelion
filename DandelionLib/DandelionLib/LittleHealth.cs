using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib
{
    class LittleHealth: FallingHealth, ILittleEntity
    {
        public LittleHealth(int healthValue) : base(healthValue)
        {
        }
    }
}
