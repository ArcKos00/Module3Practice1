using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsList.Services.Abstract
{
    public interface IJsonConfigService
    {
        public LanguageConfig Extract();
    }
}
