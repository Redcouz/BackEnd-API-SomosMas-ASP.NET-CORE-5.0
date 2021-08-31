using OngProject.Core.DTOs;
using OngProject.Core.Helper;
using OngProject.Core.Helper.Pagination;
using OngProject.Core.Interfaces;
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
    public class MemberService: IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImagenService _imagenService;
        private readonly IUriPaginationService _uriPaginationService;

        public MemberService(IUnitOfWork unitOfWork, IImagenService imagenService, IUriPaginationService uriPaginationService)
        {
            _unitOfWork = unitOfWork;
            _imagenService = imagenService;
            _uriPaginationService = uriPaginationService;
        }


        public async Task<ResponsePagination<GenericPagination<MemberGetDto>>> GetAll(int page, int sizeByPage)
        {
            string nextRoute = null, previousRoute = null;
            IEnumerable<MemberModel> data = await _unitOfWork.MemberRepository.GetAll();

            var mapper = new EntityMapper();
            var membersDto = data.Select(m => mapper.FromMemberToMemberGetDto(m)).ToList();

            GenericPagination<MemberGetDto> objGenericPagination = GenericPagination<MemberGetDto>.Create(membersDto, page, sizeByPage);
            ResponsePagination<GenericPagination<MemberGetDto>> response = new ResponsePagination<GenericPagination<MemberGetDto>>(objGenericPagination);
            response.CurrentPage = objGenericPagination.CurrentPage;
            response.HasNextPage = objGenericPagination.HasNextPage;
            response.HasPreviousPage = objGenericPagination.HasPreviousPage;
            response.PageSize = objGenericPagination.PageSize;
            response.TotalPages = objGenericPagination.TotalPages;
            response.TotalRecords = objGenericPagination.TotalRecords;
            response.Data = objGenericPagination;

            if (response.HasNextPage)
            {
                nextRoute = $"/members?page={(page + 1)}";
                response.NextPageUrl = _uriPaginationService.GetPaginationUri(page, nextRoute).ToString();
            }
            else
            {
                response.NextPageUrl = null;
            }

            if (response.HasPreviousPage)
            {
                previousRoute = $"/members?page={(page - 1)}";
                response.PreviousPageUrl = _uriPaginationService.GetPaginationUri(page, previousRoute).ToString();
            }
            else
            {
                response.PreviousPageUrl = null;
            }

            return response;
        }

        public async Task<IEnumerable<MemberModel>> GetMembers()
        {
            return await _unitOfWork.MemberRepository.GetAll();
        }


        public async Task<MemberModel> Post(MemberCreateDto memberCreateDto)
        {
            var mapper = new EntityMapper();
            var member = mapper.FromMemberCreateDtoToMember(memberCreateDto);

            try
            {
                member.Image = await _imagenService.Save(member.Image, memberCreateDto.Image);
                await _unitOfWork.MemberRepository.Insert(member);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return member;
        }

        public async Task<MemberModel> GetById(int id)
        {
            return await _unitOfWork.MemberRepository.GetById(id);
        }
        public async Task<bool> Delete(int Id)
        {
            try
            {
                await _unitOfWork.MemberRepository.Delete(Id);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool EntityExists(int id)
        {
            return _unitOfWork.MemberRepository.EntityExists(id);
        }

        public async Task<MemberModel> Put(MemberUpdateDto memberUpdateDto, int id)
        {
            var mapper = new EntityMapper();
          
            try
            {
                MemberModel member = await _unitOfWork.MemberRepository.GetById(id);
                string imageAnterior = member.Image;

                member = mapper.FromMemberUpdateDtoToMember(memberUpdateDto, member);

                if (memberUpdateDto.Image != null)
                {
                    await _imagenService.Delete(imageAnterior); //borra imagen anterior de amazon
                    member.Image = await _imagenService.Save(member.Image, memberUpdateDto.Image); //actualiza con nueva
                }

                await _unitOfWork.MemberRepository.Update(member);
                await _unitOfWork.SaveChangesAsync();
                return member;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); 
            }
           
        }

    }
}
