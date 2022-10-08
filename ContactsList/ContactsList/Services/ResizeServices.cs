﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsList.Models;
using ContactsList.Services.Abstract;

namespace ContactsList.Services
{
    public class ResizeServices : IResizeService
    {
        public void AddResize(ref ContactModel[] contactList, ContactModel contact)
        {
            ContactModel[] newList = new ContactModel[contactList.Length + 1];
            for (int i = 0; i < contactList.Length; i++)
            {
                newList[i] = contactList[i];
            }

            contactList = newList;
            contactList[contactList.Length - 1] = contact;
        }

        public void RemoveResize(ref ContactModel[] contactList, int index)
        {
            ContactModel[] newList = new ContactModel[contactList.Length - 1];
            for (int i = 0; i < index; i++)
            {
                newList[i] = contactList[i];
            }

            for (int i = index; i < newList.Length; i++)
            {
                newList[i] = contactList[i + 1];
            }

            contactList = newList;
        }
    }
}