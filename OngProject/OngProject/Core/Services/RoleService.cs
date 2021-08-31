using OngProject.Core.Interfaces.IServices;
using OngProject.Core.Interfaces.IUnitOfWork;
using OngProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Delete(int id)
        {
            return _unitOfWork.RoleRepository.Delete(id);
        }

        public Task<IEnumerable<RoleModel>> GetAll()
        {
            return _unitOfWork.RoleRepository.GetAll();
        }

        public Task<RoleModel> GetById(int id)
        {
            return _unitOfWork.RoleRepository.GetById(id);
        }

        public Task Insert(RoleModel categoryModel)
        {
            return _unitOfWork.RoleRepository.Insert(categoryModel);
        }

        public Task Update(RoleModel categoryModel)
        {
            return _unitOfWork.RoleRepository.Update(categoryModel);
        }
    }
}
