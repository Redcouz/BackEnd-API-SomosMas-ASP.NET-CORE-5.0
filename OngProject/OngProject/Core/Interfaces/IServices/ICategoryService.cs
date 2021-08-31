using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.DTOs;
using OngProject.Core.Helper.Pagination;
using OngProject.Core.Models;

namespace OngProject.Core.Interfaces
{
    public interface ICategoryService
    {
        public Task<ResponsePagination<GenericPagination<CategoryDto>>> GetAll(int page, int sizeByPage);
        public Task<CategoryModel> GetById(int Id);
        public Task<CategoryModel> Post(CategoryCreateDto categoryCreateDto);
        public Task<bool> Delete(int Id);
        public Task<CategoryModel> Put(CategoryCreateDto updateCategoryDto, int id);
        public bool EntityExists(int id);
    }
}
