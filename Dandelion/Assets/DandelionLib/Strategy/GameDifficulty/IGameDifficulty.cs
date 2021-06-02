using DandelionLib.Entities.FallingEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib.Strategy.GameDifficulty
{
    interface IGameDifficulty
    {
        Queue<IFallingEntity> GetFallingEntitiesQueue(int size);
    }
}
