using Assets.DandelionLib.Enums;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assets.DandelionLib.Data
{
    static class RecordTable
    {
        static private List<Record> BestRecords { get; set; }

        static private readonly string fileName = "Results.txt";

        static RecordTable()
        {
            BestRecords = new List<Record>();
            DeserializeTable();
        }

        static public Record GetRecordByDifficultyType(DifficultyType type)
        {
            return BestRecords
                .Where(record => record.Type == type)
                .FirstOrDefault() ?? new Record { Score = 0 };
        }

        static public void ReplaceRecordInTable(Record record)
        {
            if (!BestRecords.Any(_ => _.Type == record.Type && _.Score >= record.Score))
            {
                BestRecords.RemoveAll(_ => _.Type == record.Type);
                BestRecords.Add(record);
                SerializeTable();
            }
        }

        static private void SerializeTable()
        {BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, BestRecords);
            }
        }

        static private void DeserializeTable()
        {
            FileInfo fileInfo = new FileInfo(fileName);
            if (fileInfo.Exists)
            {
                List<Record> records;
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    records = (List<Record>)(formatter.Deserialize(fs));
                    BestRecords = records;
                }
            }
        }
    }
}
