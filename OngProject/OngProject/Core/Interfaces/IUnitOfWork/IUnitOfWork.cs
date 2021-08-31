using OngProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<CategoryModel> CategoryRepository { get; }
        IBaseRepository<ContactsModel> ContactsRepository { get; }
        IBaseRepository<MemberModel> MemberRepository { get; }
        IBaseRepository<RoleModel> RoleRepository { get; }
        IBaseRepository<ActivitiesModel> ActivitiesRepository { get; }
        IBaseRepository<CommentModel> CommentRepository { get; }
        IBaseRepository<OrganizationModel> OrganizationRepository { get; }
        IBaseRepository<SlideModel> SlideRepository { get; }
        IBaseRepository<TestimonialsModel> TestimonialsRepository { get; }
        IBaseRepository<NewsModel> NewsRepository { get; }
        IBaseRepository<UserModel> UserRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
