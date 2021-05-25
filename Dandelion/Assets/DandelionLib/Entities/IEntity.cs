using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib.Entities
{
    public interface IEntity
    {
        int ColideValue { get; }

        void Colide(ICanColideWithEntity colideble);
    }
}
