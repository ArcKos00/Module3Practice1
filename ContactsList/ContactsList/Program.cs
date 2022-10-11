using ContactsList;
using ContactsList.Models;
using ContactsList.Services;

int minLength = 1;
int maxLength = 5;
MyContactsCollection contacts = new MyContactsCollection();

new RandomService().RandomContacts9(ref contacts, minLength, maxLength);
contacts.ViewCollecction();
Console.ReadLine();