using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsList.Models
{
    public class ContactModel
    {
        public string Number
        {
            get { return Number; }
            set { Number = "+" + value; }
        }

        public string Name { get; set; }
    }
}
