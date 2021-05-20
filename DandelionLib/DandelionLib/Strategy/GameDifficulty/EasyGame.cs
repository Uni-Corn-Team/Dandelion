using DandelionLib.Entities.FallingEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandelionLib.Strategy.GameDifficulty
{
    class EasyGame : IGameDifficulty
    {
        public Queue<IFallingEntity> GetFallingEntitiesQueue(int size)
        {
            throw new NotImplementedException();
        }
    }
}
