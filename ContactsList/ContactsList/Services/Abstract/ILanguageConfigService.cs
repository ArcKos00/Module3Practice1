using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsList.Models;

namespace ContactsList.Services.Abstract
{
    public interface ILanguageConfigService
    {
        public LanguageConfigModel GetLanguage(CultureInfo culture);
    }
}
