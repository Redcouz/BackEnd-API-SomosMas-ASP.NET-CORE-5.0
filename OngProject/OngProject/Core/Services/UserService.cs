
using OngProject.Core.Interfaces.IServices;
using OngProject.Core.Interfaces.IUnitOfWork;
using OngProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OngProject.Core.DTOs;
using OngProject.Core.Mapper;
using OngProject.Core.Interfaces.IServices.AWS;

namespace OngProject.Core.Services
{
    public class UserService: IUserService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IImagenService _imagenService;

        public UserService(IUnitOfWork unitOfWork, IImagenService imagenService)
        {
            _unitOfWork = unitOfWork;
            _imagenService = imagenService;
        }

        public async Task<bool> DeleteUser(int Id)
        {

            try
            {           
                await _unitOfWork.UserRepository.Delete(Id);
                await _unitOfWork.SaveChangesAsync();
                
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UserExists(int Id)
        {
            return _unitOfWork.UserRepository.EntityExists(Id);
        }

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            return await _unitOfWork.UserRepository.GetAll();
        }

        public async Task<UserInfoDto> GetUserById(int Id)
        {
            UserModel user = await _unitOfWork.UserRepository.GetById(Id);
            EntityMapper mapper = new EntityMapper();
            UserInfoDto userInfoDto = mapper.FromUserModelToUserInfoDto(user);

            return userInfoDto;
        }

        public async Task<UserModel> Put(UserUpdateDto userUpdateDto, int id)
        {
            var mapper = new EntityMapper();

            try
            {
                UserModel user = await _unitOfWork.UserRepository.GetById(id);

                user = mapper.FromUserUpdateDtoToUser(userUpdateDto, user);

                if (userUpdateDto.Photo != null)
                    user.photo = await _imagenService.Save(user.photo, userUpdateDto.Photo);

                await _unitOfWork.UserRepository.Update(user);
                await _unitOfWork.SaveChangesAsync();

                return user;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
