using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OngProject.Core.Models;

namespace OngProject.Core.Interfaces
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Insert(T entity);
        public Task<UserModel> GetByEmail(string email);
        Task Update(T entity);
        Task Delete(int id);
        bool EntityExists(int id);
    }
}
