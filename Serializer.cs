using Newtonsoft.Json;
using System;
using System.IO;

namespace Fire_Emblem_Three_Houses_Randomizer_V2
{
    public class Serializer
    {

        public static void SaveProperties(Settings settings, string filePath)
        {
            string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static Settings LoadProperties(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<Settings>(json);
            } catch (Exception e)
            {
                return new Settings();
            }
        }
    }
}
