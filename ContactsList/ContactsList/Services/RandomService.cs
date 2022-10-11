using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsList.Services
{
    public class RandomService
    {
        private Random _random = new Random();
        public string RandNum(int count)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                stringBuilder.Append(_random.Next(1, 10));
            }

            return stringBuilder.ToString();
        }

        public string RandName(int count)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                stringBuilder.Append((char)_random.Next('а', 'я'));
            }

            return stringBuilder.ToString();
        }

        public string RandNameEng(int count)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                stringBuilder.Append((char)_random.Next('a', 'z'));
            }

            return stringBuilder.ToString();
        }

        public void RandomContacts9(ref MyContactsCollection contacts, int minCount, int maxCount)
        {
            contacts.Add(new ContactService().AddContact(
                RandName(_random.Next(minCount, maxCount)),
                RandName(_random.Next(minCount, maxCount)),
                RandNum(_random.Next(minCount, maxCount))));
            contacts.Add(new ContactService().AddContact(
                RandName(_random.Next(minCount, maxCount)),
                RandNameEng(_random.Next(minCount, maxCount)),
                RandNum(_random.Next(minCount, maxCount))));
            contacts.Add(new ContactService().AddContact(
                RandName(_random.Next(minCount, maxCount)),
                RandNum(_random.Next(minCount, maxCount)),
                RandNum(_random.Next(minCount, maxCount))));
            contacts.Add(new ContactService().AddContact(
                RandNameEng(_random.Next(minCount, maxCount)),
                RandName(_random.Next(minCount, maxCount)),
                RandNum(_random.Next(minCount, maxCount))));
            contacts.Add(new ContactService().AddContact(
                RandNameEng(_random.Next(minCount, maxCount)),
                RandNameEng(_random.Next(minCount, maxCount)),
                RandNum(_random.Next(minCount, maxCount))));
            contacts.Add(new ContactService().AddContact(
                RandNameEng(_random.Next(minCount, maxCount)),
                RandNum(_random.Next(minCount, maxCount)),
                RandNum(_random.Next(minCount, maxCount))));
            contacts.Add(new ContactService().AddContact(
                RandNum(_random.Next(minCount, maxCount)),
                RandName(_random.Next(minCount, maxCount)),
                RandNum(_random.Next(minCount, maxCount))));
            contacts.Add(new ContactService().AddContact(
                RandNum(_random.Next(minCount, maxCount)),
                RandNameEng(_random.Next(minCount, maxCount)),
                RandNum(_random.Next(minCount, maxCount))));
            contacts.Add(new ContactService().AddContact(
                RandNum(_random.Next(minCount, maxCount)),
                RandNum(_random.Next(minCount, maxCount)),
                RandNum(_random.Next(minCount, maxCount))));
        }
    }
}
