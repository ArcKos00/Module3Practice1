using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.Json;
using ContactsList.Models;

namespace ContactsList.Services
{
    public class JsonConfigService
    {
        private const string DefaultPath = "\\Cultures\\";
        private const string TypeFiles = ".json";
        private const string DefaultLanguagePack = "en-US";
        public LanguageConfigModel Extract(string changedCulture)
        {
            LanguageConfigModel config;
            string path = Directory.GetCurrentDirectory() + DefaultPath;
            string neededFile = path + DefaultLanguagePack + TypeFiles;
            string[] files = Directory.GetFiles(path);
            string changedFile = path + changedCulture + TypeFiles;
            foreach (var file in files)
            {
                if (file == changedFile)
                {
                    neededFile = file;
                    break;
                }
            }

            using (var reader = new StreamReader(neededFile))
            {
                config = JsonSerializer.Deserialize<LanguageConfigModel>(reader.ReadToEnd());
            }

            return config;
        }

        public string ViewFiles()
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + DefaultPath);
            Console.WriteLine("Введите язык из перечисленых вариантов");
            foreach (var file in files)
            {
                string shortFile = Path.GetFileName(file);
                shortFile = shortFile.Split('.')[0];
                Console.Write(shortFile + "    ");
            }

            return Console.ReadLine();
        }
    }
}