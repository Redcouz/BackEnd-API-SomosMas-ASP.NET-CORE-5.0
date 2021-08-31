using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.DTOs;
using OngProject.Core.Interfaces;
using OngProject.Core.Interfaces.IUnitOfWork;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Infrastructure;
using OngProject.Core.Interfaces.IServices.AWS;
using OngProject.Core.Helper;
using OngProject.Core.Helper.Pagination;
using OngProject.Core.Interfaces.IServices.IUriPaginationService;

namespace OngProject.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImagenService _imagenService;
        private readonly IUriPaginationService _uriPaginationService;

        public CategoryService(IUnitOfWork unitOfWork, IImagenService imagenService, IUriPaginationService uriPaginationService)
        {
            _unitOfWork = unitOfWork;
            _imagenService = imagenService;
            _uriPaginationService = uriPaginationService;
        }

        public async Task<ResponsePagination<GenericPagination<CategoryDto>>> GetAll(int page, int sizeByPage)
        {
            string nextRoute = null, previousRoute = null;
            IEnumerable<CategoryModel> data = await _unitOfWork.CategoryRepository.GetAll();

            var mapper = new EntityMapper();
            var categoriesDto = data.Select(c => mapper.FromCategoryToCategoryDto(c)).ToList();

            GenericPagination<CategoryDto> objGenericPagination = GenericPagination<CategoryDto>.Create(categoriesDto, page, sizeByPage);
            ResponsePagination<GenericPagination<CategoryDto>> response = new ResponsePagination<GenericPagination<CategoryDto>>(objGenericPagination);
            response.CurrentPage = objGenericPagination.CurrentPage;
            response.HasNextPage = objGenericPagination.HasNextPage;
            response.HasPreviousPage = objGenericPagination.HasPreviousPage;
            response.PageSize = objGenericPagination.PageSize;
            response.TotalPages = objGenericPagination.TotalPages;
            response.TotalRecords = objGenericPagination.TotalRecords;
            response.Data = objGenericPagination;

            if (response.HasNextPage)
            {
                nextRoute = $"/categories?page={(page + 1)}";
                response.NextPageUrl = _uriPaginationService.GetPaginationUri(page, nextRoute).ToString();
            }
            else
            {
                response.NextPageUrl = null;
            }

            if (response.HasPreviousPage)
            {
                previousRoute = $"/categories?page={(page - 1)}";
                response.PreviousPageUrl = _uriPaginationService.GetPaginationUri(page, previousRoute).ToString();
            }
            else
            {
                response.PreviousPageUrl = null;
            }

            return response;
        }
        public Task<CategoryModel> GetById(int Id)
        {
            return _unitOfWork.CategoryRepository.GetById(Id);
        }
        public async Task<CategoryModel> Post(CategoryCreateDto categoryCreateDto)
        {
            var mapper = new EntityMapper();
            var category = mapper.FromCategoryCreateDtoToCategory(categoryCreateDto);

            try
            {
                category.Image = await _imagenService.Save(category.Image, categoryCreateDto.Image);
                await _unitOfWork.CategoryRepository.Insert(category);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return category;
        }

       
        public async Task<bool> Delete(int Id)
        {
            try
            {                
                await _unitOfWork.CategoryRepository.Delete(Id);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public async Task<CategoryModel> Put(CategoryCreateDto updateCategoryDto, int id)
        {
            var mapper = new EntityMapper();

            CategoryModel category = await _unitOfWork.CategoryRepository.GetById(id);

            category = mapper.FromCategoryCreateDtoUpdateToCategory(updateCategoryDto, category);

            if (updateCategoryDto.Image != null)
               category.Image = await _imagenService.Save(category.Image, updateCategoryDto.Image);

            await _unitOfWork.CategoryRepository.Update(category);
            await _unitOfWork.SaveChangesAsync();

            return category;
        }

        public bool EntityExists(int id)
        {
            return _unitOfWork.CategoryRepository.EntityExists(id);
        }
    }
}
