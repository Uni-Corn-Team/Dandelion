using Assets.DandelionLib.Enums;

namespace Assets.DandelionLib.Data
{
    class Record
    {
        public string Nickname { get; set; }
        public int Score { get; set; }
        public DifficultyType Type { get; set; }
    }
}
