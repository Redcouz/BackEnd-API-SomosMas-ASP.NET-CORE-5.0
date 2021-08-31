using Microsoft.AspNetCore.Mvc;
using OngProject.Core.DTOs;
using OngProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces.IServices
{
    public interface IContactsService
    {
        public Task<IEnumerable<ContactsModel>> GetContacts();
        public Task<ContactsModel> Post(ContactsCreateDto contactsCreateDto);
    }
}
