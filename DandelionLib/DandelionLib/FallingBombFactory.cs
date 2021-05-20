using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib
{
    class FallingBombFactory : IEntityFactory
    {
        public ILargeEntity CreateLargeEntity(int val)
        {
            return new LargeBomb(val);
        }

        public ILittleEntity CreateLittleEntity(int val)
        {
            return new LittleBomb(val);
        }

        public IMiddleEntity CreateMiddleEntity(int val)
        {
            return new MiddleBomb(val);
        }

        public IUltimateEntity CreateUltimateEntity(int val)
        {
            return new UltimateBomb(val);
        }
    }
}
