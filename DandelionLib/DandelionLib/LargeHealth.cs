using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib
{
    class LargeHealth: FallingHealth, ILargeEntity
    {
        public LargeHealth(int healthValue) : base(healthValue)
        {
        }
    }
}
