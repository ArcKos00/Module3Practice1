using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsList.Models;

namespace ContactsList.Services.Abstract
{
    public interface IResizeService
    {
        public void AddResize(ref ContactModel[] contacts, ContactModel contact);
        public void RemoveResize(ref ContactModel[] contacts, int index);
    }
}
