using DandelionLib.Entities.FallingEntities;
using DandelionLib.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib.Strategy.GameDifficulty
{
    class NormalGame : IGameDifficulty
    {
        public Queue<IFallingEntity> GetFallingEntitiesQueue(int size)
        {
            Queue<IFallingEntity> queue = new Queue<IFallingEntity>();

            for (int i = 0; i < size; i++)
            {
                int rndNum = Rnd.This.Next(100);
                if (NumSet.IsIn(0, 16, rndNum))
                {
                    queue.Enqueue(new FallingLittleHealth(15));
                }
                if (NumSet.IsIn(17, 31, rndNum))
                {
                    queue.Enqueue(new FallingMiddleHealth(30));
                }
                if (NumSet.IsIn(31, 40, rndNum))
                {
                    queue.Enqueue(new FallingLargeHealth(50));
                }
                if (NumSet.IsIn(41, 49, rndNum))
                {
                    queue.Enqueue(new FallingUltimateHeath(100));
                }
                if (NumSet.IsIn(50, 61, rndNum))
                {
                    queue.Enqueue(new FallingLittleBomb(15));
                }
                if (NumSet.IsIn(62, 83, rndNum))
                {
                    queue.Enqueue(new FallingMiddleBomb(30));
                }
                if (NumSet.IsIn(84, 95, rndNum))
                {
                    queue.Enqueue(new FallingLargeBomb(50));
                }
                if (NumSet.IsIn(95, 100, rndNum))
                {
                    queue.Enqueue(new FallingUltimateBomb(100));
                }
            }
            return queue;
        }
    }
}
