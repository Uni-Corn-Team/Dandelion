using DandelionLib.Entities.FallingEntities;
using DandelionLib.Statics;
using System.Collections.Generic;

namespace DandelionLib.Strategy.GameDifficulty
{
    class EasyGame : IGameDifficulty
    {
        public Queue<IFallingEntity> GetFallingEntitiesQueue(int size)
        {
            Queue<IFallingEntity> queue = new Queue<IFallingEntity>();

            for(int i = 0; i < size; i++)
            {
                int rndNum = Rnd.This.Next(100);
                if (NumSet.IsIn(0, 26, rndNum))
                {
                    queue.Enqueue(new FallingLittleHealth(15));
                }
                if (NumSet.IsIn(27, 47, rndNum))
                {
                    queue.Enqueue(new FallingMiddleHealth(30));
                }
                if (NumSet.IsIn(48, 63, rndNum))
                {
                    queue.Enqueue(new FallingLargeHealth(50));
                }
                if (NumSet.IsIn(64, 68, rndNum))
                {
                    queue.Enqueue(new FallingUltimateHeath(100));
                }
                if (NumSet.IsIn(69, 86, rndNum))
                {
                    queue.Enqueue(new FallingLittleBomb(12));
                }
                if (NumSet.IsIn(87, 96, rndNum))
                {
                    queue.Enqueue(new FallingMiddleBomb(27));
                }
                if (NumSet.IsIn(96, 100, rndNum))
                {
                    queue.Enqueue(new FallingLargeBomb(45));
                }
            }
            return queue;
        }
    }
}
