using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ContactsList.Models;
using ContactsList.Services;
using ContactsList.Services.Abstract;

namespace ContactsList
{
    public class MyContactsCollection : IEnumerable
    {
        private const int Zero = 0;
        private ContactModel[][] _contactList;
        private ConsoleService _consoleExecutor = new ConsoleService();
        private LanguageConfigModel _language;

        public MyContactsCollection()
        {
            _language = new JsonConfigService().Extract(_consoleExecutor.ViewFiles(Config.DefaultPath));

            CultureInfo.CurrentCulture = new CultureInfo(_language.LCID);
            _contactList = new ContactModel[][]
            {
                new ContactModel[Zero],
                new ContactModel[Zero],
                new ContactModel[Zero]
            };
            CultureInfo.CurrentCulture = new CultureInfo(_language.LCID);
        }

        public ContactModel[][] Contacts
        {
            get { return _contactList; }
        }

        public int Length { get; set; }

        public void RechangeLanguage()
        {
            _language = new JsonConfigService().Extract(_consoleExecutor.ViewFiles(Config.DefaultPath));
            Rebuild();
            new ConsoleService().ViewCollecction(_contactList);
        }

        public void Rebuild()
        {
            Length = Zero;
            ContactModel[][] newContacts = new ContactModel[_contactList.Length][];
            for (int i = 0; i < newContacts.Length; i++)
            {
                newContacts[i] = new ContactModel[Zero];
            }

            for (int i = 0; i < newContacts.Length; i++)
            {
                for (int j = 0; j < _contactList[i].Length; j++)
                {
                    Add(_contactList[i][j], ref newContacts);
                }
            }

            _contactList = newContacts;
        }

        public void Add(IContactService contact)
        {
            Console.WriteLine("Введите имя контакта: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Введите фамилию контакта: ");
            string secondName = Console.ReadLine();
            Console.WriteLine("Введите номер контакта: ");
            bool succes = false;
            ulong number = 0;
            while (!succes)
            {
                try
                {
                    number = ulong.Parse(Console.ReadLine());
                    succes = true;
                }
                catch
                {
                    Console.WriteLine("Введите корректный номер контакта: ");
                }
            }

            ChangeWhereAdd(contact.AddContact(firstName, secondName, number.ToString()), ref _contactList);
            Sort();
            Length++;
        }

        public void Add(ContactModel contact)
        {
            ChangeWhereAdd(contact, ref _contactList);
            Sort();
            Length++;
        }

        public void Add(ContactModel contact, ref ContactModel[][] list)
        {
            ChangeWhereAdd(contact, ref list);
            Sort();
            Length++;
        }

        public void ChangeWhereAdd(ContactModel contact, ref ContactModel[][] list)
        {
            int count = 0;
            bool accessToLeterArray = false;
            char[] leters = _language.Alphabet.ToCharArray();
            char charToCompare = contact.FullName.ToCharArray()[0];
            for (int i = 0; i < leters.Length; i++)
            {
                if (charToCompare.Equals(leters[i]))
                {
                    accessToLeterArray = true;
                    break;
                }
            }

            if (accessToLeterArray)
            {
                count = 0;
            }
            else if (char.IsNumber(charToCompare))
            {
                count = 1;
            }
            else
            {
                count = 2;
            }

            new ResizeServices<ContactModel>().AddResize(ref list[count], contact);
        }

        public bool Remove(ContactModel contactToRemove)
        {
            bool success = false;
            for (int i = 0; i < _contactList.Length; i++)
            {
                for (int j = 0; j < _contactList[i].Length; j++)
                {
                    if (new ContactsComparer().Compare(_contactList[i][j], contactToRemove) == 0)
                    {
                        new ResizeServices<ContactModel>().RemoveResize(ref _contactList[i], j);
                        success = true;
                        Length--;
                        return success;
                    }
                }
            }

            return success;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Length)
            {
                return;
            }

            for (int i = 0; i < _contactList.Length; i++)
            {
                index -= _contactList[i].Length;
                if (index <= 0)
                {
                    index += _contactList[i].Length;
                    new ResizeServices<ContactModel>().RemoveResize(ref _contactList[i], index);
                    return;
                }
            }
        }

        public void Sort()
        {
            foreach (var list in _contactList)
            {
                Array.Sort<ContactModel>(list, new ContactsComparer());
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var list in _contactList)
            {
                yield return (IEnumerator)list.GetEnumerator();
            }
        }
    }
}
