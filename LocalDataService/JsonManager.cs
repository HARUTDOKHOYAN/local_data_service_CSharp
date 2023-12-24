using Newtonsoft.Json;

namespace LocalDataService
{
    public class JsonManager<T> where T : new()
    {
        private DirectoryInfo _jsonDirectory = Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "JSonData"));

        public void Serializ(T data, string dataName)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(_jsonDirectory.FullName, dataName + ".txt")))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(outputFile, data);
            }
        }
        public T DeSerializ(string dataName)
        {
            var path = Path.Combine(_jsonDirectory.FullName, dataName + ".txt");

            if (!File.Exists(path))
                Serializ(new T(), dataName);

            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
