using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OngProject.Core.Interfaces.IServices;
using OngProject.Core.Interfaces;
using OngProject.Core.Interfaces.IUnitOfWork;
using OngProject.Core.Models;
using OngProject.Core.DTOs;
using OngProject.Core.Mapper;
using OngProject.Core.Interfaces.IServices.AWS;
using OngProject.Core.Helper;
using OngProject.Core.Helper.Pagination;
using OngProject.Core.Interfaces.IServices.IUriPaginationService;

namespace OngProject.Core.Services
{
    public class NewsService : INewsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImagenService _imagenService;
        private readonly IUriPaginationService _uriPaginationService;

        public NewsService(IUnitOfWork unitOfWork, IImagenService imagenService, IUriPaginationService uriPaginationService)
        {
            _unitOfWork = unitOfWork;
            _imagenService = imagenService;
            _uriPaginationService = uriPaginationService;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await _unitOfWork.NewsRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public async Task<ResponsePagination<GenericPagination<NewsModel>>> GetAll(int page, int sizeByPage)
        {
            string nextRoute=null, previousRoute = null;
            IEnumerable<NewsModel> data = await _unitOfWork.NewsRepository.GetAll();
            GenericPagination<NewsModel> objGenericPagination = GenericPagination<NewsModel>.Create(data, page, sizeByPage);
            ResponsePagination<GenericPagination<NewsModel>> response = new ResponsePagination<GenericPagination<NewsModel>>(objGenericPagination);
            response.CurrentPage = objGenericPagination.CurrentPage;
            response.HasNextPage = objGenericPagination.HasNextPage;
            response.HasPreviousPage = objGenericPagination.HasPreviousPage;
            response.PageSize = objGenericPagination.PageSize;
            response.TotalPages = objGenericPagination.TotalPages;
            response.TotalRecords = objGenericPagination.TotalRecords;
            response.Data = objGenericPagination;

            if (response.HasNextPage)
            {
                nextRoute = $"/news?page={(page + 1)}";
                response.NextPageUrl = _uriPaginationService.GetPaginationUri(page, nextRoute).ToString();
            }
            else
            {
                response.NextPageUrl = null;
            }  

            if (response.HasPreviousPage)
            {
                previousRoute = $"/news?page={(page - 1)}";
                response.PreviousPageUrl = _uriPaginationService.GetPaginationUri(page, previousRoute).ToString();
            }
            else
            {
                response.PreviousPageUrl = null;
            }

            
            
            return response;
        }

        public async Task<NewsModel> GetById(int id)
        {
           
            var news = await _unitOfWork.NewsRepository.GetById(id);
            return news;
        }

        public async Task<NewsModel> Post(NewsDto newsCreateDto)
        {
            var mapper = new EntityMapper();
            var news = mapper.FromNewsDtoToNews(newsCreateDto);

            try
            {
                news.Image = await _imagenService.Save(news.Image, newsCreateDto.Image);
                await _unitOfWork.NewsRepository.Insert(news);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return news;
        }

        public Task Update(NewsModel newsModel)
        {

            return _unitOfWork.NewsRepository.Update(newsModel);

        }
        public async Task<NewsModel> Put(NewsUpdateDto newsUpdateDto, int id)
        {
            var mapper = new EntityMapper();

            try
            {
                NewsModel news = await _unitOfWork.NewsRepository.GetById(id);

                news = mapper.FromNewsUpdateDtoToNews(newsUpdateDto, news);

                if (newsUpdateDto.Image != null)
                    news.Image = await _imagenService.Save(news.Image, newsUpdateDto.Image);
                await _unitOfWork.NewsRepository.Update(news);
                await _unitOfWork.SaveChangesAsync();
                return news;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public bool NewsExists(int Id)
        {
            return _unitOfWork.NewsRepository.EntityExists(Id);
        }
    }
}
