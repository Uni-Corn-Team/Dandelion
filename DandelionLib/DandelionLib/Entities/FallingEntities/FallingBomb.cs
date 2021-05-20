using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib.Entities.FallingEntities
{
    abstract class FallingBomb : IFallingEntity
    {
        public int ColideValue { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="damageValue">positive num</param>
        public FallingBomb(int damageValue)
        {
            ColideValue = -1 * damageValue;
        }

        public void Colide(ICanColideWithEntity colideble)
        {
            colideble.ChangeHealth(ColideValue);
        }
    }
}
