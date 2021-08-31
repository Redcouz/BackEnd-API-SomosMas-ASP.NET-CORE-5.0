using OngProject.Core.DTOs;
using OngProject.Core.Helper.Pagination;
using OngProject.Core.Interfaces.IServices;
using OngProject.Core.Interfaces.IServices.AWS;
using OngProject.Core.Interfaces.IServices.IUriPaginationService;
using OngProject.Core.Interfaces.IUnitOfWork;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Services
{
    public class TestimonialsService : ITestimonialsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImagenService _imagenService;
        private readonly IUriPaginationService _uriPaginationService;

        public TestimonialsService(IUnitOfWork unitOfWork, IImagenService imagenService, IUriPaginationService uriPaginationService)
        {
            _unitOfWork = unitOfWork;
            _imagenService = imagenService;
            _uriPaginationService = uriPaginationService;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await _unitOfWork.TestimonialsRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public async Task<TestimonialsModel> GetById(int id)
        {
            return await _unitOfWork.TestimonialsRepository.GetById(id);
        }

        public async Task<TestimonialsModel> Post(CreateTestimonialsDto testimonialsCreateDto)
        {
            var mapper = new EntityMapper();
            var testimonials = mapper.FromCreateTestimonialsDtoToTestimonials(testimonialsCreateDto);

            await _unitOfWork.TestimonialsRepository.Insert(testimonials);
            await _unitOfWork.SaveChangesAsync();

            return testimonials;
        }

        public async Task<TestimonialsModel> Put(CreateTestimonialsDto updateTestimonialsDto, int id)
        {
            var mapper = new EntityMapper();

            TestimonialsModel testimonials = await _unitOfWork.TestimonialsRepository.GetById(id);

            testimonials = mapper.FromTestimonialsCreateDtoUpdateToTestimonials(updateTestimonialsDto, testimonials);

            await _unitOfWork.TestimonialsRepository.Update(testimonials);
            await _unitOfWork.SaveChangesAsync();

            return testimonials;
        }

        public async Task<ResponsePagination<GenericPagination<CreateTestimonialsDto>>> GetAll(int page = 1, int sizeByPage = 10)
        {
            string nextRoute = null, previousRoute = null;
            IEnumerable<TestimonialsModel> data = await _unitOfWork.TestimonialsRepository.GetAll();

            var mapper = new EntityMapper();
            var testimonialsDto = data.Select(c => mapper.FromTestimonialsToCreateTestimonialsDto(c)).ToList();

            GenericPagination<CreateTestimonialsDto> objGenericPagination = GenericPagination<CreateTestimonialsDto>.Create(testimonialsDto, page, sizeByPage);
            ResponsePagination<GenericPagination<CreateTestimonialsDto>> response = new ResponsePagination<GenericPagination<CreateTestimonialsDto>>(objGenericPagination);
            response.CurrentPage = objGenericPagination.CurrentPage;
            response.HasNextPage = objGenericPagination.HasNextPage;
            response.HasPreviousPage = objGenericPagination.HasPreviousPage;
            response.PageSize = objGenericPagination.PageSize;
            response.TotalPages = objGenericPagination.TotalPages;
            response.TotalRecords = objGenericPagination.TotalRecords;
            response.Data = objGenericPagination;

            if (response.HasNextPage)
            {
                nextRoute = $"/testimonials?page={(page + 1)}";
                response.NextPageUrl = _uriPaginationService.GetPaginationUri(page, nextRoute).ToString();
            }
            else
            {
                response.NextPageUrl = null;
            }

            if (response.HasPreviousPage)
            {
                previousRoute = $"/testimonials?page={(page - 1)}";
                response.PreviousPageUrl = _uriPaginationService.GetPaginationUri(page, previousRoute).ToString();
            }
            else
            {
                response.PreviousPageUrl = null;
            }

            return response;
        }

        public bool EntityExist(int id)
        {
            return _unitOfWork.TestimonialsRepository.EntityExists(id);
        }
    }
}
