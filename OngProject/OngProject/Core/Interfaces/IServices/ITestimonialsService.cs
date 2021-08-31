using OngProject.Core.DTOs;
using OngProject.Core.Helper.Pagination;
using OngProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces.IServices
{
    public interface ITestimonialsService
    {
        public Task<bool> Delete(int id);
        public Task<TestimonialsModel> Post(CreateTestimonialsDto testimonialsCreateDto);
        public bool EntityExist(int id);
        public Task<ResponsePagination<GenericPagination<CreateTestimonialsDto>>> GetAll(int page, int sizeByPage);

        public Task<TestimonialsModel> GetById(int Id);
        public Task<TestimonialsModel> Put(CreateTestimonialsDto updateTestimonialsDto, int id);
    }
}
