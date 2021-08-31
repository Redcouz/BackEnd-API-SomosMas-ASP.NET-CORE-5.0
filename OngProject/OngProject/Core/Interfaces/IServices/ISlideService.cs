using OngProject.Core.DTOs;
using OngProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces.IServices
{
    public interface ISlideService
    {
        public Task<IEnumerable<SlideDto>> GetAll();
        public Task<SlideModel> GetById(int Id);
        public bool EntityExists(int id);
        public Task<bool> Delete(int id);
        public Task<SlideModel> Post(SlideDto slideCreateDto);
        public Task<SlideModel> Update(SlideUpdateDto slideCreateDto, int id);
    }
}
