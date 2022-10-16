using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsList.Models;

namespace ContactsList.Services.Abstract
{
    public interface IJsonConfigService
    {
        public LanguageConfigModel Extract(string defaultLanguage);
    }
}
