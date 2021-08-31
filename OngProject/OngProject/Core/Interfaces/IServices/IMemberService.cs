using Microsoft.AspNetCore.Mvc;
using OngProject.Core.DTOs;
using OngProject.Core.Helper.Pagination;
using OngProject.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IMemberService
    {
        public Task<IEnumerable<MemberModel>> GetMembers();
        public Task<MemberModel> Post(MemberCreateDto memberCreateDto);
        public Task<bool> Delete(int Id);
        public bool EntityExists(int id);
        public Task<MemberModel> Put(MemberUpdateDto memberUpdateDto, int id);
        public Task<ResponsePagination<GenericPagination<MemberGetDto>>> GetAll(int page, int sizeByPage);

    }
}
