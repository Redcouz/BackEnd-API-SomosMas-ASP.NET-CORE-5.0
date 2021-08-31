using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OngProject.Core.DTOs;
using OngProject.Core.Helper.Pagination;
using OngProject.Core.Models;

namespace OngProject.Core.Interfaces.IServices
{
    public interface INewsService
    {
        public Task<ResponsePagination<GenericPagination<NewsModel>>> GetAll(int page, int sizeByPage);

        public Task<NewsModel> GetById(int id);

        public Task<NewsModel> Post(NewsDto newsCreateDto);

        public Task<bool> Delete(int id);

        public Task Update(NewsModel newsModel);
        public bool NewsExists(int Id);

        public Task<NewsModel> Put(NewsUpdateDto newsUpdateDto, int id);
    }
}
