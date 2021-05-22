using DandelionLib.Entities.FallingEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib.Entities.EntitiesFactory
{
    class FallingBombFactory : IEntityFactory
    {
        public ILargeEntity CreateLargeEntity(int val)
        {
            return new FallingLargeBomb(val);
        }

        public ILittleEntity CreateLittleEntity(int val)
        {
            return new FallingLittleBomb(val);
        }

        public IMiddleEntity CreateMiddleEntity(int val)
        {
            return new FallingMiddleBomb(val);
        }

        public IUltimateEntity CreateUltimateEntity(int val)
        {
            return new FallingUltimateBomb(val);
        }
    }
}
