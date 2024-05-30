using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace RFI.Models
{
    public static class StazioneFileManager
    {
        private static string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Stazioni.txt");

        public static List<Stazione> ReadStazioni()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found!");
                return new List<Stazione>();
            }

            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Stazione>>(json) ?? new List<Stazione>();
        }

        public static void WriteStazioni(List<Stazione> stazioni)
        {
            var json = JsonConvert.SerializeObject(stazioni, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}
