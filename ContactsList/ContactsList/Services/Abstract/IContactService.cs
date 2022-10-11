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
        public ContactModel AddContact(string firstName, string secondName, string number);
        public ContactModel RenameFirstNameContact(ContactModel contact, string newName);
        public ContactModel RenameLastNameContact(ContactModel contact, string newName);
        public ContactModel RechangeContactNumber(ContactModel contact, string newNumber);
    }
}
