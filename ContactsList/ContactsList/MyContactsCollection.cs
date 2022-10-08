using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ContactsList.Models;
using ContactsList.Services;
using ContactsList.Services.Abstract;

namespace ContactsList
{
    public class MyContactsCollection : IEnumerable
    {
        private const int DefaultCount = 0;
        private CultureInfo _culture;

        private ContactModel[] _contactList;
        private LanguageConfig _language;

        public MyContactsCollection()
        {
            _language = new JsonConfigService().Extract();
            _culture = new CultureInfo(1123);
            _contactList = new ContactModel[DefaultCount];
        }

        public void Add(IContactService contact)
        {
            Console.WriteLine("Введите имя контакта: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите номер контакта: ");
            string number = Console.ReadLine();
            new ResizeServices().AddResize(ref _contactList, contact.AddContact(name, number));
        }

        public bool Remove(ContactModel contactToRemove)
        {
            bool success = false;
            for (int i = 0; i < _contactList.Length; i++)
            {
                if (new ContactsComparer().Compare(_contactList[i], contactToRemove) == 0)
                {
                    new ResizeServices().RemoveResize(ref _contactList, i);
                    success = true;
                    break;
                }
            }

            return success;
        }

        public void RemoveAt(int index)
        {
            new ResizeServices().RemoveResize(ref _contactList, index);
        }

        public void Sort()
        {
        }

        public void ViewCollecction()
        {
            ViewContacts(_contactList);
        }

        public void ViewContacts(ContactModel[] list)
        {
            foreach (var contact in list)
            {
                Console.WriteLine(contact.Name);
                Console.WriteLine(contact.Number);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)_contactList.GetEnumerator();
        }
    }
}
