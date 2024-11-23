using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Interfaces;
using CMSPlus.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSPlus.Services.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepostory;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepostory = commentRepository;
        }

        public async Task Create(CommentEntity entity)
        {
            await _commentRepostory.Create(entity);
        }

        public async Task Delete(int id)
        {
            await _commentRepostory.Delete(id);
        }

        public async Task<IEnumerable<CommentEntity>> GetAll()
        {
            return await _commentRepostory.GetAll();
        }

        public async Task<IEnumerable<CommentEntity>> GetAllByTopicId(int topicId)
        {
            return await _commentRepostory.GetCommentsByTopicId(topicId);
        }

        public async Task<CommentEntity> GetById(int id)
        {
            return await _commentRepostory.GetById(id);
        }

        public async Task Update(CommentEntity entity)
        {
            await _commentRepostory.Update(entity);
        }
    }
}
