using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsList.Services.Abstract
{
    public interface IRandomService<T>
        where T : MyContactsCollection
    {
        public string RandNum(int count);
        string RandName(int count);
        public string RandNameEng(int count);
        public void RandomContacts9(ref T contacts, int minCount, int maxCount);
    }
}
