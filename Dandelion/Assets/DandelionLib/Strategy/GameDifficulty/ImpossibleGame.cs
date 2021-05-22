using DandelionLib.Entities.FallingEntities;
using DandelionLib.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib.Strategy.GameDifficulty
{
    class ImpossibleGame : IGameDifficulty
    {
        public Queue<IFallingEntity> GetFallingEntitiesQueue(int size)
        {
            Queue<IFallingEntity> queue = new Queue<IFallingEntity>();

            for (int i = 0; i < size; i++)
            {
                int rndNum = Rnd.This.Next(100);
                if (NumSet.IsIn(0, 49, rndNum))
                {
                    queue.Enqueue(new FallingLittleHealth(15));
                }
                if (NumSet.IsIn(50, 100, rndNum))
                {
                    queue.Enqueue(new FallingUltimateBomb(100));
                }
            }
            return queue;
        }
    }
}
