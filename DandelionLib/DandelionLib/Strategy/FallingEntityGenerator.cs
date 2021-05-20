using DandelionLib.Entities;
using DandelionLib.Strategy.GameDifficulty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib.Strategy
{
    class FallingEntityGenerator : IEntityGenerator
    {
        public FallingEntityGenerator(IGameDifficulty gameDifficulty)
        {
            GameDifficulty = gameDifficulty;
        }

        public Queue<IEntity> EntitiesQueue { get; private set; } = new Queue<IEntity>();

        public IGameDifficulty GameDifficulty { get; private set; }

        public void AddEntities(int count)
        {
            foreach(var entity in GameDifficulty.GetFallingEntitiesQueue(count))
            {
                EntitiesQueue.Enqueue(entity);
            }            
        }

        public void ChangeLevel(IGameDifficulty newDifficulty)
        {
            GameDifficulty = newDifficulty;
        }

        public IEntity GetNext()
        {
            if(EntitiesQueue.Count < 5)
            {
                AddEntities(5);
            }
            return EntitiesQueue.Dequeue();
        }

        public void Reset()
        {
            EntitiesQueue = new Queue<IEntity>();
        }
    }
}
