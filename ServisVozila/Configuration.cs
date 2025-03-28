using System.IO;
using System.Text.Json;

namespace ServisVozila
{
    public class Configuration
    {
        public static string ConnectionStringTemplate { get; private set; }

        static Configuration()
        {
            // Load the JSON file at startup
            string json = File.ReadAllText("settings.json");
            var config = JsonSerializer.Deserialize<Config>(json);

            ConnectionStringTemplate = config.ConnectionStringTemplate;
        }

        private class Config
        {
            public string ConnectionStringTemplate { get; set; }
        }
    }
}
