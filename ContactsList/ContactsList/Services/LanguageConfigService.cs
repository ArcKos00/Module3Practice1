using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsList.Models;
using ContactsList.Services.Abstract;

namespace ContactsList.Services
{
    public class LanguageConfigService : ILanguageConfigService
    {
        public LanguageConfigModel GetLanguage(CultureInfo culture)
        {
            return new JsonConfigService().Extract(culture.Name);
        }
    }
}
