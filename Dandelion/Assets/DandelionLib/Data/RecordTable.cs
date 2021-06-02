using Assets.DandelionLib.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assets.DandelionLib.Data
{
    [Serializable]
    class RecordTable
    {
        private List<Record> Records { get; set; }

        [NonSerialized]
        private readonly string fileName = "Results.txt";

        public RecordTable()
        {
            Records = new List<Record>();
            DeserializeTable();
        }

        public List<Record> GetRecordsByDifficultyType(DifficultyType type)
        {
            return Records.Where(record => record.Type == type).ToList();
        }

        public void AddRecordToTable(Record record)
        {
            Records.Add(record);
        }

        public void SerializeTable()
        {
            FileInfo fileInf = new FileInfo(fileName);
            if (!(fileInf.Exists))
            {
                fileInf.Create();
            }

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this);
            }
        }

        private void DeserializeTable()
        {
            List<Record> records;
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                records = (List<Record>)(formatter.Deserialize(fs));
                this.Records = records;
            }
        }
    }
}
