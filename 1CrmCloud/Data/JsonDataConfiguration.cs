using Newtonsoft.Json;
using System;
using System.IO;

namespace CRMCloud.Data
{
    public class JsonDataConfiguration
    {
        public dynamic ConfigureJsonData<T>(string dataFile)
        {
            dynamic data = JsonConvert.DeserializeObject<T>(File.ReadAllText(FilePath(dataFile)).ToString());
            return data;
        }

        public string FilePath(string dataFile)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data/JsonDataFiles/", dataFile) + ".json";
            return path;
        }
    }
}
