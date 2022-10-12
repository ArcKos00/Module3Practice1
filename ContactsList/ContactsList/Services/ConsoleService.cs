using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsList.Models;

namespace ContactsList.Services
{
    public class ConsoleService
    {
        public void ViewCollecction(ContactModel[][] lists)
        {
            foreach (var list in lists)
            {
                foreach (var contact in list)
                {
                    Console.WriteLine(contact.FullName);
                    Console.WriteLine(contact.Number);
                    Console.WriteLine("---------------------");
                }
            }
        }

        public string ViewFiles(string defaultPath)
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + defaultPath);
            Console.WriteLine("Введите язык из перечисленых вариантов");
            foreach (var file in files)
            {
                string shortFile = Path.GetFileName(file);
                shortFile = shortFile.Split('.')[0];
                Console.Write(shortFile + "    ");
            }

            Console.WriteLine();
            return Console.ReadLine();
        }
    }
}
