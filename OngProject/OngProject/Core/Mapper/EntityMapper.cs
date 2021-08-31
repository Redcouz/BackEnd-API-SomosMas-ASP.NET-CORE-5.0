using OngProject.Core.DTOs;
using OngProject.Core.DTOs.Auth;
using OngProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OngProject.Core.Mapper

{
    public class EntityMapper
    {
        public SlideDto FromSlideToSlideDto(SlideModel slide)
        {
            var slideDto = new SlideDto()
            {
                ImageUrl = slide.ImageUrl,
                Order = slide.Order
            };

            return slideDto;
        }
        public CommentDto FromCommentToCommentDto(CommentModel comment)
        {
            var commentDto = new CommentDto() { Body = comment.Body };

            return commentDto;
        }

        /* public NewsDto FromNewsToNewsDto(NewsModel news)
         {
             var newsDto = new NewsDto()
             {
                 Name = news.Name,
                 Image = news.Image, // no se puede convertir string a IFormFile
                 Content = news.Content
             };

             return newsDto;
         }
        */
        public ContactsModel FromContactsCreateDtoToContacts(ContactsCreateDto contactsCreateDto)
        {
            if (contactsCreateDto == null)
            {
                return null;
            }
            return new ContactsModel
            {
                Name = contactsCreateDto.Name,
                Email = contactsCreateDto.Email,
                Phone = contactsCreateDto.Phone,
                Message = contactsCreateDto.Message,
            };
        }

        public OrganizationDto FromOrganizationToOrganizationDto(OrganizationModel organization)
        {
            var organizationDto = new OrganizationDto()
            {
                Name = organization.Name,
                Image = organization.Image,
                Phone = organization.Phone,
                FacebookUrl = organization.FacebookUrl,
                LinkedinUrl = organization.LinkedinUrl,
                InstagramUrl = organization.InstagramUrl,
            };

            return organizationDto;
        }

        public ActivitiesModel FromActivitiesCreateDtoToActivities(ActivitiesCreateDto activitiesCreateDto)
        {
            if (activitiesCreateDto == null)
            {
                return null;
            }

            string image = null;
            if (activitiesCreateDto.Image != null)
                image = GetNameImage("activities");

            return new ActivitiesModel
            {
                Name = activitiesCreateDto.Name,
                Image = image,
                Content = activitiesCreateDto.Content,
            };
        }

        public ActivitiesModel FromActivitiesUpdateDtoToActivities(ActivitiesUpdateDto activitiesUpdateDto, ActivitiesModel activity)
        {
            string image = null;
            if (activitiesUpdateDto.Image != null)
                image = GetNameImage("activity");

            if (!string.IsNullOrEmpty(activitiesUpdateDto.Name))
                activity.Name = activitiesUpdateDto.Name;

            if (!string.IsNullOrEmpty(activitiesUpdateDto.Content))
                activity.Content = activitiesUpdateDto.Content;

            return activity;
        }

        public CategoryDto FromCategoryToCategoryDto(CategoryModel category)
        {
            var categoryDto = new CategoryDto()
            {
                Name = category.Name
            };
            return categoryDto;
        }

        public UserDto FromUserToUserDto(UserModel user, string token)
        {
            var userDto = new UserDto()
            {
                Name = $"{user.firstName} {user.lastName}",
                Email = user.email,
                Token = token
            };

            return userDto;
        }

        public CommentModel FromCommentCreateDtoToComment(CommentCreateDto commentCreateDto)
        {

            if (commentCreateDto == null)
            {
                return null;
            }

            return new CommentModel
            {
                User_id = commentCreateDto.User_id,
                post_id = commentCreateDto.post_id,
                Body = commentCreateDto.Body,
            };
        }
        public UserModel FromRegisterDtoToUser(RegisterDTO register)
        {
            string photo = null;
            if(register.photo!=null)
             photo = GetNameImage("user");

            var user = new UserModel()
            {
                firstName = register.firstName,
                lastName = register.lastName,
                email = register.email,
                password = register.password,
                photo = photo
            };

            return user;
        }
        public CategoryModel FromCategoryCreateDtoToCategory(CategoryCreateDto categoryCreateDto)
        {
            if (categoryCreateDto == null)
            {
                return null;
            }

            string image = null;
            if (categoryCreateDto.Image != null)
                image = GetNameImage("category");

            return new CategoryModel
            {
                Description = categoryCreateDto.Description,
                Image = image,
                Name = categoryCreateDto.Name,
            };
        }

        public CategoryModel FromCategoryCreateDtoUpdateToCategory(CategoryCreateDto categoryUpdateDto, CategoryModel category)
        {
            string image = null;
            if (categoryUpdateDto.Image != null)
                image = GetNameImage("category");

            if (!string.IsNullOrEmpty(categoryUpdateDto.Name))
                category.Name = categoryUpdateDto.Name;

            if (!string.IsNullOrEmpty(image))
                category.Image = image;

            if (!string.IsNullOrEmpty(categoryUpdateDto.Description))
                category.Description = categoryUpdateDto.Description;

            return category;
        }
        public MemberModel FromMemberUpdateDtoToMember(MemberUpdateDto memberUpdateDto, MemberModel member)
        {
            string image = null;
            if (memberUpdateDto.Image != null)
                image = GetNameImage("member");

            if(!string.IsNullOrEmpty(memberUpdateDto.Name))
            member.Name = memberUpdateDto.Name;

            if (!string.IsNullOrEmpty(memberUpdateDto.FacebookUrl))
                member.FacebookUrl = memberUpdateDto.FacebookUrl;

            if (!string.IsNullOrEmpty(memberUpdateDto.InstagramUrl))
                member.InstagramUrl = memberUpdateDto.InstagramUrl;

            if (!string.IsNullOrEmpty(memberUpdateDto.LinkedinUrl))
                member.LinkedinUrl = memberUpdateDto.LinkedinUrl;

            if (!string.IsNullOrEmpty(image))
                member.Image = image;

            if (!string.IsNullOrEmpty(memberUpdateDto.Description))
                member.Description = memberUpdateDto.Description;

            return member;
        }

        public UserModel FromUserUpdateDtoToUser(UserUpdateDto userUpdateDto, UserModel user)
        {
            string photo = null;
            if (userUpdateDto.Photo != null)
                photo = GetNameImage("user");

            if (!string.IsNullOrEmpty(userUpdateDto.FirstName))
                user.firstName = userUpdateDto.FirstName;

            if (!string.IsNullOrEmpty(userUpdateDto.LastName))
                user.lastName = userUpdateDto.LastName;

            if (!string.IsNullOrEmpty(photo))
                user.photo = photo;

            return user;
        }


        public MemberModel FromMemberCreateDtoToMember(MemberCreateDto memberCreateDto)
        {
            if (memberCreateDto == null)
            {
                return null;
            }

            string image = null;
            if (memberCreateDto.Image != null)
                image = GetNameImage("member");

            return new MemberModel
            {
                Name = memberCreateDto.Name,
                FacebookUrl = memberCreateDto.FacebookUrl,
                InstagramUrl = memberCreateDto.InstagramUrl,
                LinkedinUrl = memberCreateDto.LinkedinUrl,
                Image = image,
                Description = memberCreateDto.Description
            };
        }

        public NewsModel FromNewsDtoToNews(NewsDto newsCreateDto)
        {
            if (newsCreateDto == null)
            {
                return null;
            }
            string image = null;
            if (newsCreateDto.Image != null)
                image = GetNameImage("news");

            return new NewsModel
            {
                Name = newsCreateDto.Name,
                Content = newsCreateDto.Content,
                Image =image,
                CategoryId = newsCreateDto.CategoryId

            };
        }

        public UserInfoDto FromUserModelToUserInfoDto(UserModel user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserInfoDto
            {
                firstName = user.firstName,
                lastName = user.lastName,
                email = user.email,
                photo = user.photo,
                roleId = user.roleId
            };
        }
        public TestimonialsModel FromCreateTestimonialsDtoToTestimonials(CreateTestimonialsDto testimonialsCreateDto)
        {
            if (testimonialsCreateDto == null)
            {
                return null;
            }
            return new TestimonialsModel
            {
                Name = testimonialsCreateDto.Name,
                Content = testimonialsCreateDto.Content
            };
        }
        public string GetNameImage(string nameModel)
        {
            string image = DateTime.Now.ToString();
            image = image.Replace(":", "");
            image = image.Replace("/", "");
            image = image.Replace(" ", "");
            image = nameModel+"_" + image;

            return image;
        }

        public SlideInfoDto FromSlideToSlideInfoDto(SlideModel slide)
        {
            var slideInfoDto = new SlideInfoDto()
            {
                ImageUrl = slide.ImageUrl,
                Text = slide.Text,
                Order = slide.Order
            };

            return slideInfoDto;
        }

        public OrganizationDto FromOrganizationToOrganizationDtoWithSlides(OrganizationModel organization, List<SlideInfoDto> slides)
        {
            if(organization == null)
            {
                return null;
            }
            var organizationDto = new OrganizationDto()
            {
                Name = organization.Name,
                Image = organization.Image,
                Phone = organization.Phone,
                FacebookUrl = organization.FacebookUrl,
                LinkedinUrl = organization.LinkedinUrl,
                InstagramUrl = organization.InstagramUrl,
                Slides = slides,
            };

            return organizationDto;
        }

        public SlideModel FromSlideDtoToSlide(SlideDto slideCreateDto)

        {
            if (slideCreateDto == null)
            {

                return null;
            }
            return new SlideModel
            {
                ImageUrl = slideCreateDto.ImageUrl,
                Order = slideCreateDto.Order,
                Text = slideCreateDto.Text
            };
        }

        public CreateTestimonialsDto FromTestimonialsToCreateTestimonialsDto(TestimonialsModel testimonials)
        {
            var testimonialsDto = new CreateTestimonialsDto()
            {
                Name = testimonials.Name,
                Content = testimonials.Content
            };
            return testimonialsDto;
        }
        public NewsModel FromNewsUpdateDtoToNews(NewsUpdateDto newsUpdateDto, NewsModel news)
        {
            string image = null;
            if (newsUpdateDto.Image != null)
                image = GetNameImage("news");

            if (!string.IsNullOrEmpty(newsUpdateDto.Name))
                news.Name = newsUpdateDto.Name;

            if (!string.IsNullOrEmpty(newsUpdateDto.Content))
                news.Content = newsUpdateDto.Content;

            if (!string.IsNullOrEmpty(image))
                news.Image = image;
            if (newsUpdateDto.CategoryId != 0)
                news.CategoryId = newsUpdateDto.CategoryId;
            return news;
        }
        public CommentModel FromComentUpdateToComment(CommentUpdateDto commentUpdateDto, CommentModel comment)
        {
            if (commentUpdateDto.User_id != null)
                comment.User_id = commentUpdateDto.User_id;

            if (commentUpdateDto.post_id != null)
                comment.post_id = commentUpdateDto.post_id;

            if (commentUpdateDto.Body != null)
                comment.Body = commentUpdateDto.Body;

            return comment;
        }

        public OrganizationModel FromOrganizationUpdateToOrganization(OrganizationUpdateDto organizationUpdateDto, OrganizationModel organization)
        {
            if (!string.IsNullOrEmpty(organizationUpdateDto.Name))
                organization.Name = organizationUpdateDto.Name;

            if (!string.IsNullOrEmpty(organizationUpdateDto.Image))
                organization.Image = organizationUpdateDto.Image;         

            if (!string.IsNullOrEmpty(organizationUpdateDto.Email))
                organization.Email = organizationUpdateDto.Email;

            if (!string.IsNullOrEmpty(organizationUpdateDto.WelcomeText))
                organization.WelcomeText = organizationUpdateDto.WelcomeText;

            organization.Phone = organizationUpdateDto.Phone;

            organization.Adress = organizationUpdateDto.Adress;

            organization.FacebookUrl = organizationUpdateDto.FacebookUrl;

            organization.LinkedinUrl = organizationUpdateDto.LinkedinUrl;

            organization.InstagramUrl = organizationUpdateDto.InstagramUrl;

            organization.AboutUsText = organizationUpdateDto.AboutUsText;

            return organization;
        }

        public SlideModel FromSlideUpdateDtoToSlide(SlideUpdateDto slideUpdateDto, SlideModel slide)
        {

            if (slideUpdateDto.Image != null)

                slide.ImageUrl = GetNameImage("slide");

            if (slideUpdateDto.Order != null)

                slide.Order = (int)slideUpdateDto.Order;

            if (!string.IsNullOrEmpty(slideUpdateDto.Text))

                slide.Text = slideUpdateDto.Text;

            if (!string.IsNullOrEmpty(slideUpdateDto.OrganizationId))

                slide.OrganizationId = slideUpdateDto.OrganizationId;

            return slide;

        }
        public TestimonialsModel FromTestimonialsCreateDtoUpdateToTestimonials(CreateTestimonialsDto testimonialsUpdateDto, TestimonialsModel testimonials)
        {

            if (!string.IsNullOrEmpty(testimonialsUpdateDto.Name))
                testimonials.Name = testimonialsUpdateDto.Name;

            if (!string.IsNullOrEmpty(testimonialsUpdateDto.Content))
                testimonials.Content = testimonialsUpdateDto.Content;

            return testimonials;
        }
        



        public MemberGetDto FromMemberToMemberGetDto(MemberModel member)
        {
            string image = null;
            MemberGetDto memberDto = new MemberGetDto();

            if (member.Image != null)
                image = GetNameImage("member");

            if (!string.IsNullOrEmpty(member.Name))
                memberDto.Name = member.Name;

            if (!string.IsNullOrEmpty(member.FacebookUrl))
                memberDto.FacebookUrl = member.FacebookUrl;

            if (!string.IsNullOrEmpty(member.InstagramUrl))
                memberDto.InstagramUrl = member.InstagramUrl;

            if (!string.IsNullOrEmpty(member.LinkedinUrl))
                memberDto.LinkedinUrl = member.LinkedinUrl;
            if (!string.IsNullOrEmpty(member.Image))
                memberDto.Image = member.Image;

            if (!string.IsNullOrEmpty(member.Description))
                memberDto.Description = member.Description;

            return memberDto;
        }

        public OrganizationUpdateDto FromOrganizationToOrganizationUpdateDto(OrganizationModel organization)
        {

            if (organization == null)
            {
                return null;
            }

            var organizationUpdateDto = new OrganizationUpdateDto() 
            {
                Name = organization.Name,
                Image = organization.Image,
                Phone = organization.Phone,
                Adress = organization.Adress,
                Email = organization.Email,
                FacebookUrl = organization.FacebookUrl,
                LinkedinUrl = organization.LinkedinUrl,
                InstagramUrl = organization.InstagramUrl,
                WelcomeText = organization.WelcomeText,
                AboutUsText = organization.AboutUsText
            };

            return organizationUpdateDto;
        }
    }
}
