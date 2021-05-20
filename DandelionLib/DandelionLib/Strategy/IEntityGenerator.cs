using DandelionLib.Entities;
using DandelionLib.Strategy.GameDifficulty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
