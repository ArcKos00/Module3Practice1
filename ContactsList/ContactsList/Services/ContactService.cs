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
        public ContactModel AddContact(string firstName, string secondName, string number)
        {
            return new ContactModel() { FirstName = firstName, LastName = secondName, Number = "+" + number };
        }

        public ContactModel RenameFirstNameContact(ContactModel contact, string newName)
        {
            return new ContactModel() { FirstName = newName, Number = contact.Number };
        }

        public ContactModel RenameLastNameContact(ContactModel contact, string newName)
        {
            return new ContactModel() { LastName = newName, Number = contact.Number };
        }

        public ContactModel RechangeContactNumber(ContactModel contact, string newNumber)
        {
            return new ContactModel() { FirstName = contact.FirstName, LastName = contact.LastName, Number = "+" + newNumber };
        }
    }
}
