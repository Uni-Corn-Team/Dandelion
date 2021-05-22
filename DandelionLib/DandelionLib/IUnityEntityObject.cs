using DandelionLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib
{
    interface IUnityEntityObject
    {
        EntityType Id { get; }
        void Colide(ICanColideWithEntity colideble);
    }
}
