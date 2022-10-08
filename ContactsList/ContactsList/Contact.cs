using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsList
{
    public class Contact
    {
        private const string DefaultName = "";
        private const string DefaultNumber = "";

        private string _name;
        private string _number;
        public Contact()
            : this(DefaultName, DefaultNumber)
        {
        }

        public Contact(int number)
            : this(DefaultName, number)
        {
        }

        public Contact(string name)
            : this(name, DefaultNumber)
        {
        }

        public Contact(string name, int number)
        {
            _name = name;
            _number = "+" + number.ToString();
        }

        public string Number
        {
            get
            {
                return _number;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }
    }
}
