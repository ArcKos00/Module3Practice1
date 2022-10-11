using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
        private ContactModel[][] _contactList;
        private LanguageConfigModel _language;
        private JsonConfigService _json = new JsonConfigService();

        public MyContactsCollection()
        {
            string culture = _json.ViewFiles();
            _language = _json.Extract(culture);

            CultureInfo.CurrentCulture = new CultureInfo(_language.LCID);
            _contactList = new ContactModel[][]
            {
                new ContactModel[DefaultCount],
                new ContactModel[DefaultCount],
                new ContactModel[DefaultCount]
            };
            CultureInfo.CurrentCulture = new CultureInfo(_language.LCID);
        }

        public int Length { get; set; }

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

            ContactModel con = contact.AddContact(firstName, secondName, number.ToString());
            ChangeWhereAdd(con);
            Sort();
            Length++;
        }

        public void Add(ContactModel contact)
        {
            ChangeWhereAdd(contact);
            Sort();
            Length++;
        }

        public void ChangeWhereAdd(ContactModel contact)
        {
            int count = 0;
            char charToCompare = contact.FullName.ToCharArray()[0];
            if ((charToCompare >= _language.UpperCharMin && charToCompare <= _language.UpperCharMax) ||
                (charToCompare >= _language.LowerCharMin && charToCompare <= _language.LowerCharMax))
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

            new ResizeServices().AddResize(ref _contactList[count], contact);
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
                        new ResizeServices().RemoveResize(ref _contactList[i], j);
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
                    new ResizeServices().RemoveResize(ref _contactList[i], index);
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

        public void ViewCollecction()
        {
            foreach (var list in _contactList)
            {
                foreach (var contact in list)
                {
                    Console.WriteLine(contact.FullName);
                    Console.WriteLine(contact.Number);
                    Console.WriteLine("---------------------");
                }
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
