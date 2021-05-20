using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib
{
    interface IEntityFactory
    {
        ILittleEntity CreateLittleEntity(int val);
        IMiddleEntity CreateMiddleEntity(int val);
        ILargeEntity CreateLargeEntity(int val);
        IUltimateEntity CreateUltimateEntity(int val);
    }
}
