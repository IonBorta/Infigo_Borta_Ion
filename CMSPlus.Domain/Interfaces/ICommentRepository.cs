using CMSPlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSPlus.Domain.Interfaces
{
    public interface ICommentRepository:IRepository<CommentEntity>
    {
        public Task<IEnumerable<CommentEntity>> GetCommentsByTopicId(int topicId);

    }
}
