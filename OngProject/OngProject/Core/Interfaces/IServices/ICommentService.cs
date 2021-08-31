using OngProject.Core.DTOs;
using OngProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces.IServices
{
    public interface ICommentService
    {
        public Task<IEnumerable<CommentDto>> GetAllComments();
        public Task<IEnumerable<CommentDto>> GetCommentsByPost(int idPost);
        public Task<bool> ValidateCreatorOrAdminAsync(ClaimsPrincipal user, int id);
        public Task<bool> Delete(int Id);
        public bool EntityExists(int id);
        public Task<CommentModel> Post(CommentCreateDto commentCreateDto);
        public Task<CommentModel> GetById(int Id);
        public Task<CommentModel> Update(CommentUpdateDto updateComentDto, int id);
    }
}
