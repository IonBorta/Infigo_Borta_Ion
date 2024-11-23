using CMSPlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSPlus.Services.Interfaces
{
    public interface ICommentService:IBasicService<CommentEntity>
    {
        public Task<IEnumerable<CommentEntity>> GetAllByTopicId(int topicId);
    }
}
