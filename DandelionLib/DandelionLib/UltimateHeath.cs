using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib
{
    class UltimateHeath: FallingHealth, IUltimateEntity
    {
        public UltimateHeath(int healthValue) : base(healthValue)
        {
        }
    }
}
