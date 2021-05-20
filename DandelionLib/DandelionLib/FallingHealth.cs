using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib
{
    abstract class FallingHealth : IFallingEntity
    {
        public int ColideValue { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="healthValue">positive num</param>
        public FallingHealth(int healthValue)
        {
            ColideValue = healthValue;
        }

        public void Colide(ICanColideWithEntity colideble)
        {
            colideble.ChangeHealth(ColideValue);
        }
    }
}
