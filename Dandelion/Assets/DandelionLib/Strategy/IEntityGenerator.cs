using DandelionLib.Entities;
using DandelionLib.Strategy.GameDifficulty;
using System.Collections.Generic;

namespace DandelionLib.Strategy
{
    interface IEntityGenerator
    {
        Queue<IEntity> EntitiesQueue { get; }

        IGameDifficulty GameDifficulty { get; }

        IEntity GetNext();

        void AddEntities(int count);

        void Reset();

        void ChangeLevel(IGameDifficulty newDifficulty);
    }
}
