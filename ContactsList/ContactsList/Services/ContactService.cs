using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsList.Models;
using ContactsList.Services.Abstract;

namespace ContactsList.Services
{
    public class ContactService : IContactService
    {
        public ContactModel AddContact(string name, string number)
        {
            return new ContactModel() { Name = name, Number = number };
        }

        public ContactModel RenameContact(ContactModel contact, string newName)
        {
            return new ContactModel() { Name = newName, Number = contact.Number };
        }

        public ContactModel RechangeContactNumber(ContactModel contact, string newNumber)
        {
            return new ContactModel() { Name = contact.Name, Number = newNumber };
        }
    }
}
