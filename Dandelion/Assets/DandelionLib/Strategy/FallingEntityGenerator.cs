using DandelionLib.Entities;
using DandelionLib.Strategy.GameDifficulty;
using System.Collections.Generic;

namespace DandelionLib.Strategy
{
    class FallingEntityGenerator : IEntityGenerator
    {
        private const int LIMIT_COUNT = 10;

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
            Reset();
        }

        public IEntity GetNext()
        {
            if(EntitiesQueue.Count < LIMIT_COUNT / 2)
            {
                AddEntities(LIMIT_COUNT / 2);
            }
            return EntitiesQueue.Dequeue();
        }

        public void Reset()
        {
            EntitiesQueue = new Queue<IEntity>();
            AddEntities(LIMIT_COUNT);
        }
    }
}
