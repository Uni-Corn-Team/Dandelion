using Assets.DandelionLib.Enums;
using System;

namespace Assets.DandelionLib.Data
{
    [Serializable]
    class Record
    {
        public string Nickname { get; set; }
        public int Score { get; set; }
        public DifficultyType Type { get; set; }
    }
}
