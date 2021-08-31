using OngProject.Core.DTOs;
using OngProject.Core.Interfaces.IServices;
using OngProject.Core.Interfaces.IUnitOfWork;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Services
{
    public class OrganizationService: IOrganizationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrganizationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OrganizationDto> GetById(int id)
        {
            var mapper = new EntityMapper();
            var organization = await _unitOfWork.OrganizationRepository.GetById(id);
            var organizationDto = mapper.FromOrganizationToOrganizationDto(organization);
            return organizationDto;
        }

        public async Task<OrganizationDto> GetOrganizationWithSlides (int id)
        {
            var mapper = new EntityMapper();
            var organization = await _unitOfWork.OrganizationRepository.GetById(id);

            string organizationId = id.ToString();

            var slides = await _unitOfWork.SlideRepository.GetAll();

            List<SlideInfoDto> slidesInfoList = new List<SlideInfoDto>();

            foreach(SlideModel s in slides)
            {
                if(s.OrganizationId == organizationId)
                {
                    var item = mapper.FromSlideToSlideInfoDto(s);
                    slidesInfoList.Add(item);
                }
            }

            slidesInfoList.OrderBy(s => s.Order);

            var organizationDto = mapper.FromOrganizationToOrganizationDtoWithSlides(organization, slidesInfoList);

            return organizationDto;


        }

        public async Task<OrganizationDto> GetFirst()
        {
            var mapper = new EntityMapper();
            IEnumerable<OrganizationModel> ongList = await _unitOfWork.OrganizationRepository.GetAll();
            OrganizationModel ong = ongList.First();
            OrganizationDto ongDto = mapper.FromOrganizationToOrganizationDto(ong);
            return ongDto;
        }

        public async Task<OrganizationModel> Update(OrganizationUpdateDto organizationUpdateDto)
        {
            var mapper = new EntityMapper();

            try
            {
                OrganizationModel organization = await _unitOfWork.OrganizationRepository.GetById(1);

                organization = mapper.FromOrganizationUpdateToOrganization(organizationUpdateDto, organization);

                await _unitOfWork.OrganizationRepository.Update(organization);
                await _unitOfWork.SaveChangesAsync();
                return organization;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
