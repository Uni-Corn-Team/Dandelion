using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib
{
    class FallingHealthFactory: IEntityFactory
    {
        public ILargeEntity CreateLargeEntity(int val)
        {
            return new LargeHealth(val);
        }

        public ILittleEntity CreateLittleEntity(int val)
        {
            return new LittleHealth(val);
        }

        public IMiddleEntity CreateMiddleEntity(int val)
        {
            return new MiddleHealth(val);
        }

        public IUltimateEntity CreateUltimateEntity(int val)
        {
            return new UltimateHeath(val);
        }
    }
}
