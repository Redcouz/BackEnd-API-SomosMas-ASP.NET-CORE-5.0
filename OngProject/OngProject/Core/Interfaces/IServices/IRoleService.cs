 using OngProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces.IServices
{
    public interface IRoleService
    {
        public Task<IEnumerable<RoleModel>> GetAll();
        public Task<RoleModel> GetById(int Id);
        public Task Insert(RoleModel categoryModel);
        public Task Delete(int Id);
        public Task Update(RoleModel categoryModel);
    }
}
