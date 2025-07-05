using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Xml;
using TechStore.BL.Models;
using System.IO;
using Newtonsoft.Json;

namespace TechStore.DL
{
    public static class BatchFormPersistence
    {
        private static readonly string FilePath = "temp_batchdetail.json";

        public static void Save(TempBatchDetailDTO dto)
        {
            var json = JsonConvert.SerializeObject(dto, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }

        public static TempBatchDetailDTO Load()
        {
            if (!File.Exists(FilePath))
                return null;

            string json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<TempBatchDetailDTO>(json);
        }

        public static void Clear()
        {
            if (File.Exists(FilePath))
                File.Delete(FilePath);
        }
    }
}
