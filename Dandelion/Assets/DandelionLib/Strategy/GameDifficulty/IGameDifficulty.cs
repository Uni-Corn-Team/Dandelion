using DandelionLib.Entities.FallingEntities;
using System.Collections.Generic;

namespace DandelionLib.Strategy.GameDifficulty
{
    interface IGameDifficulty
    {
        Queue<IFallingEntity> GetFallingEntitiesQueue(int size);
    }
}
