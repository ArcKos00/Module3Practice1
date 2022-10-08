using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsList.Models;

namespace ContactsList.Services.Abstract
{
    public interface IContactService
    {
        public ContactModel AddContact(string name, string number);
        public ContactModel RenameContact(ContactModel contact, string newName);
        public ContactModel RechangeContactNumber(ContactModel contact, string newName);
    }
}
