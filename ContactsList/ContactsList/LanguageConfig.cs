using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsList
{
    [Serializable]
    public class LanguageConfig
    {
        public string Culture { get; set; }
        public char CharMin { get; set; }
        public char CharMax { get; set; }
    }
}
