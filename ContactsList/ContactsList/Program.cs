using ContactsList;
using ContactsList.Models;
using ContactsList.Services;

int minLength = 4;
int maxLength = 10;
var contacts = new MyContactsCollection();

new RandomService<MyContactsCollection>().RandomContacts9(ref contacts, minLength, maxLength);
new ConsoleService().ViewCollecction(contacts.Contacts);
Console.ReadLine();
contacts.RechangeLanguage();
Console.ReadLine();