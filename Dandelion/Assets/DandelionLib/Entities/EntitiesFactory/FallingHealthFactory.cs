using DandelionLib.Entities.FallingEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib.Entities.EntitiesFactory
{
    class FallingHealthFactory: IEntityFactory
    {
        public ILargeEntity CreateLargeEntity(int val)
        {
            return new FallingLargeHealth(val);
        }

        public ILittleEntity CreateLittleEntity(int val)
        {
            return new FallingLittleHealth(val);
        }

        public IMiddleEntity CreateMiddleEntity(int val)
        {
            return new FallingMiddleHealth(val);
        }

        public IUltimateEntity CreateUltimateEntity(int val)
        {
            return new FallingUltimateHeath(val);
        }
    }
}
