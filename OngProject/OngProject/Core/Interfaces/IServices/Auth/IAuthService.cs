using OngProject.Core.DTOs;
using OngProject.Core.DTOs.Auth;
using OngProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Services.Auth
{
    public interface IAuthService
    {
        public Task<UserDto> register(RegisterDTO register);
        public Task<UserDto> login(LoginDTO login);
        public string GetToken(UserModel user);
        public int GetUserId(string token);
    }
}
