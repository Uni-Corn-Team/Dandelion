using DandelionLib.Entities.FallingEntities;
using DandelionLib.Statics;
using System.Collections.Generic;

namespace DandelionLib.Strategy.GameDifficulty
{
    class HardGame : IGameDifficulty
    {
        public Queue<IFallingEntity> GetFallingEntitiesQueue(int size)
        {
            Queue<IFallingEntity> queue = new Queue<IFallingEntity>();

            for (int i = 0; i < size; i++)
            {
                int rndNum = Rnd.This.Next(100);
                if (NumSet.IsIn(0, 14, rndNum))
                {
                    queue.Enqueue(new FallingLittleHealth(12));
                }
                if (NumSet.IsIn(15, 21, rndNum))
                {
                    queue.Enqueue(new FallingMiddleHealth(27));
                }
                if (NumSet.IsIn(22, 28, rndNum))
                {
                    queue.Enqueue(new FallingLargeHealth(45));
                }
                if (NumSet.IsIn(29, 32, rndNum))
                {
                    queue.Enqueue(new FallingUltimateHeath(100));
                }
                if (NumSet.IsIn(33, 44, rndNum))
                {
                    queue.Enqueue(new FallingLittleBomb(20));
                }
                if (NumSet.IsIn(45, 71, rndNum))
                {
                    queue.Enqueue(new FallingMiddleBomb(35));
                }
                if (NumSet.IsIn(72, 91, rndNum))
                {
                    queue.Enqueue(new FallingLargeBomb(55));
                }
                if (NumSet.IsIn(91, 100, rndNum))
                {
                    queue.Enqueue(new FallingUltimateBomb(100));
                }
            }
            return queue;
        }
    }
}
