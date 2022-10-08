using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.Json;
using Newtonsoft.Json;

namespace ContactsList.Services
{
    public class JsonConfigService
    {
        public LanguageConfig Extract()
        {
            return new LanguageConfig();
        }

        public void WriteLanguageConfigInJson()
        {
            CultureInfo culture = CultureInfo.GetCultureInfo(0x00000C0A);
            string filename = "hhh.json";
            var json = JsonConvert.SerializeObject(culture);
            File.WriteAllText(filename, json);
        }
    }
}