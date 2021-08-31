using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces.IServices.AWS
{
    public interface IImagenService
    {
        public Task<String> Save(string fileName, IFormFile image);
        public Task<bool> Delete(string path);
    }
}
