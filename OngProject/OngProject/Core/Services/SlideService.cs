using Microsoft.AspNetCore.Http;
using OngProject.Core.DTOs;
using OngProject.Core.Helper;
using OngProject.Core.Interfaces.IServices;
using OngProject.Core.Interfaces.IServices.AWS;
using OngProject.Core.Interfaces.IUnitOfWork;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OngProject.Core.Services
{
    public class SlideService : ISlideService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImagenService _imagenService;

        public SlideService(IUnitOfWork unitOfWork, IImagenService imagenService)
        {
            _unitOfWork = unitOfWork;
            _imagenService = imagenService;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await _unitOfWork.SlideRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }


        public async Task<IEnumerable<SlideDto>> GetAll()
        {
            var mapper = new EntityMapper();
            var slideList = await _unitOfWork.SlideRepository.GetAll();
            var slidesDtoList = slideList.Select(x => mapper.FromSlideToSlideDto(x)).ToList();
            return slidesDtoList;
        }

        public Task<SlideModel> GetById(int Id)
        {
            return _unitOfWork.SlideRepository.GetById(Id);
        }

        public bool EntityExists(int id)
        {
            return _unitOfWork.SlideRepository.EntityExists(id);
        }

        public async Task<SlideModel> Post(SlideDto slideCreateDto)
        {
            if (slideCreateDto.Order == null)
            {
                var slideList = await _unitOfWork.SlideRepository.GetAll();
                var elem = slideList.Last();
                slideCreateDto.Order = elem.Order + 1;
            }
            byte[] bytesFile = Convert.FromBase64String(slideCreateDto.ImageUrl);
            string fileExtension = ValidateFiles.GetImageExtensionFromFile(bytesFile);
            string uniqueName = "slide_" + DateTime.Now.ToString().Replace(",", "").Replace("/", "").Replace(" ", "");
            FormFileData formFileData = new()
            {
                FileName = uniqueName + fileExtension,
                ContentType = "Image/" + fileExtension.Replace(".", ""),
                Name = null
            };
            IFormFile ImageFormFile = ConvertFile.BinaryToFormFile(bytesFile, formFileData);
            S3AwsHelper s3Helper = new();
            var result = await s3Helper.AwsUploadFile(uniqueName, ImageFormFile);
            if (result.Code == 200)
            {
                slideCreateDto.ImageUrl = result.Url;
                EntityMapper mapper = new();
                SlideModel slide = mapper.FromSlideDtoToSlide(slideCreateDto);
                await _unitOfWork.SlideRepository.Insert(slide);
                await _unitOfWork.SaveChangesAsync();
                return slide;
            }
            else
                throw new Exception(result.Errors);
        }

        public async Task<SlideModel> Update(SlideUpdateDto slideUpdateDto, int id)
        {
            var mapper = new EntityMapper();
            var slide = await _unitOfWork.SlideRepository.GetById(id);

            // There's a new image, delete old image
            if (slideUpdateDto.Image != null)
                await _imagenService.Delete(slide.ImageUrl);

            slide = mapper.FromSlideUpdateDtoToSlide(slideUpdateDto, slide);

            // Upload image with image name generated on mapper
            if (slideUpdateDto.Image != null)
                slide.ImageUrl = await _imagenService.Save(slide.ImageUrl, slideUpdateDto.Image);

            // If the user don't define a new order the slide it's moved to the first place
            if (slideUpdateDto.Order == null)
            {
                var slides = await _unitOfWork.SlideRepository.GetAll();
                slide.Order = slides.Last().Order + 1;
            }

            await _unitOfWork.SlideRepository.Update(slide);
            await _unitOfWork.SaveChangesAsync();
            return slide;
        }
    }
}
