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
        public LanguageConfigModel Extract(string changedCulture)
        {
            LanguageConfigModel languageConfig;
            string path = Directory.GetCurrentDirectory() + Config.DefaultPath;
            string neededFile = path + Config.DefaultLanguagePack + Config.TypeFiles;
            string[] files = Directory.GetFiles(path);
            string changedFile = path + changedCulture + Config.TypeFiles;
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
                languageConfig = JsonSerializer.Deserialize<LanguageConfigModel>(reader.ReadToEnd());
            }

            return languageConfig;
        }
    }
}