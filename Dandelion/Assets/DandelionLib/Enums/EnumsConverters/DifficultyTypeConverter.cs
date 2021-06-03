using DandelionLib.Strategy.GameDifficulty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DandelionLib.Enums.EnumsConverters
{
    public static class DifficultyTypeConverter
    {
        public static IGameDifficulty ToIGameDifficulty(DifficultyType type)
        {
            switch (type)
            {
                case DifficultyType.EasyGame:
                    return new EasyGame();
                case DifficultyType.NormalGame:
                    return new NormalGame();
                case DifficultyType.HardGame:
                    return new HardGame();
                case DifficultyType.ImpossibleGame:
                    return new ImpossibleGame();
                default:
                    return new NormalGame();
            }
        }

        public static DifficultyType ToDifficultyType(IGameDifficulty type)
        {
            switch (type)
            {
                case EasyGame easyGame:
                    return DifficultyType.EasyGame;
                case NormalGame normalGame:
                    return DifficultyType.NormalGame;
                case HardGame hardGame:
                    return DifficultyType.HardGame;
                case ImpossibleGame impossibleGame:
                    return DifficultyType.ImpossibleGame;
                default:
                    return DifficultyType.NormalGame;
            }
        }
    }
}
