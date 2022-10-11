using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsList.Models
{
    [Serializable]
    public class LanguageConfigModel
    {
        public int LCID { get; set; }
        public char LowerCharMin { get; set; }
        public char LowerCharMax { get; set; }
        public char UpperCharMin { get; set; }
        public char UpperCharMax { get; set; }
    }
}
