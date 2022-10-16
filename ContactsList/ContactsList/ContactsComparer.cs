using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsList.Models;

namespace ContactsList
{
    public class ContactsComparer : IComparer<ContactModel>
    {
        public int Compare(ContactModel x, ContactModel y)
        {
            if (x.FullName.CompareTo(y.FullName) < 0)
            {
                return -1;
            }
            else if (x.FullName.CompareTo(y.FullName) > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
