using Assets.DandelionLib.Enums;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assets.DandelionLib.Data
{
    static class RecordTable
    {
        static private readonly string fileName = "Results.txt";
        static private List<Record> BestRecords { get; set; }// = DeserializeBestRecords(fileName);

        static RecordTable()
        {
            BestRecords = DeserializeBestRecords(fileName);
        }

        static public bool ReplaceRecordInBest(Record record)
        {
            if (!BestRecords.Any(_ => _.Type == record.Type && _.Score > record.Score))
            {
                BestRecords.RemoveAll(_ => _.Type == record.Type);
                BestRecords.Add(record);
            }
            return SerializeBestRecords();
        }

        static public Record GetBestRecordByType(DifficultyType type)
        {
            return BestRecords.Where(_ => _.Type == type).FirstOrDefault() ?? new Record() { Score = 0 };
        }

        static public bool SerializeBestRecords()
        {
            bool flag = false;
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                flag = true;
                formatter.Serialize(fs, BestRecords);
            }
            return flag;
        }

        static private List<Record> DeserializeBestRecords(string fileName)
        {
            FileInfo fileInf = new FileInfo(fileName);
            if (fileInf.Exists)
            {
                List<Record> records;
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    records = (List<Record>)(formatter.Deserialize(fs));
                    //BestRecords = records;
                }
                return records ?? new List<Record>();
            }
            else
            {;
                return new List<Record>();
            }
        }
    }
}
