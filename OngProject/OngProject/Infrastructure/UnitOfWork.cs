using OngProject.Core.Interfaces;
using OngProject.Core.Interfaces.IUnitOfWork;
using OngProject.Core.Models;
using OngProject.Infrastructure.Data;
using OngProject.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngProject.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private readonly IBaseRepository<NewsModel> _newsRepository;
        
        public IBaseRepository<NewsModel> NewsRepository => _newsRepository ?? new BaseRepository<NewsModel>(_context);
        

        private readonly IBaseRepository<ActivitiesModel> _activitiesRepository; 

        public IBaseRepository<ActivitiesModel> ActivitiesRepository => _activitiesRepository ?? new BaseRepository<ActivitiesModel>(_context); 
        
        private readonly IBaseRepository<CategoryModel> _categoryRepository; 

        public IBaseRepository<CategoryModel> CategoryRepository => _categoryRepository ?? new BaseRepository<CategoryModel>(_context);

        private readonly IBaseRepository<CommentModel> _commentRepository;

        public IBaseRepository<CommentModel> CommentRepository => _commentRepository ?? new BaseRepository<CommentModel>(_context);

        private readonly IBaseRepository<ContactsModel> _contactsRepository;

        public IBaseRepository<ContactsModel> ContactsRepository => _contactsRepository ?? new BaseRepository<ContactsModel>(_context);

        private readonly IBaseRepository<MemberModel> _memberRepository;

        public IBaseRepository<MemberModel> MemberRepository => _memberRepository ?? new BaseRepository<MemberModel>(_context);

        private readonly IBaseRepository<OrganizationModel> _organizationRepository;

        public IBaseRepository<OrganizationModel> OrganizationRepository => _organizationRepository ?? new BaseRepository<OrganizationModel>(_context);

        private readonly IBaseRepository<RoleModel> _roleRepository;

        public IBaseRepository<RoleModel> RoleRepository => _roleRepository ?? new BaseRepository<RoleModel>(_context);

        private readonly IBaseRepository<SlideModel> _slideRepository;

        public IBaseRepository<SlideModel> SlideRepository => _slideRepository ?? new BaseRepository<SlideModel>(_context);

        private readonly IBaseRepository<TestimonialsModel> _testimonialsRepository;

        public IBaseRepository<TestimonialsModel> TestimonialsRepository => _testimonialsRepository ?? new BaseRepository<TestimonialsModel>(_context);


        private readonly IBaseRepository<UserModel> _userRepository;

        public IBaseRepository<UserModel> UserRepository => _userRepository ?? new BaseRepository<UserModel>(_context);
        
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
