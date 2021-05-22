using DandelionLib.Entities;
using DandelionLib.Entities.FallingEntities;
using DandelionLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib
{
    class EntityAdapter : IUnityEntityObject
    {
        public IEntity Adaptee { get; private set; }

        public EntityAdapter(IEntity adaptee)
        {
            Adaptee = adaptee;
        }

        public void Colide(ICanColideWithEntity colideble)
        {
            Adaptee.Colide(colideble);
        }

        public EntityType Id
        {
            get
            {
                switch (Adaptee)
                {
                    case FallingLittleBomb fallinglittleBomb:
                        return EntityType.FallingLittleBomb;
                    case FallingMiddleBomb fallingMiddleBomb:
                        return EntityType.FallingMiddleBomb;
                    case FallingLargeBomb fallingLargeBomb:
                        return EntityType.FallingLargeBomb;
                    case FallingUltimateBomb fallingUltimateBomb:
                        return EntityType.FallingUltimateBomb;
                    case FallingLittleHealth fallingLittleHealth:
                        return EntityType.FallingLittleHealth;
                    case FallingMiddleHealth fallingMiddleHealth:
                        return EntityType.FallingMiddleHealth;
                    case FallingLargeHealth fallingLargeHealth:
                        return EntityType.FallingLargeHealth;
                    case FallingUltimateHeath fallingUltimateHeath:
                        return EntityType.FallingUltimateHealth;
                    default: return EntityType.NonType;
                }
            }
        }
    }
}
