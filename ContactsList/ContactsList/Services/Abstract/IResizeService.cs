using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsList.Models;

namespace ContactsList.Services.Abstract
{
    public interface IResizeService<T>
    {
        public void AddResize(ref T[] contacts, T contact);
        public void RemoveResize(ref T[] contacts, int index);
    }
}
