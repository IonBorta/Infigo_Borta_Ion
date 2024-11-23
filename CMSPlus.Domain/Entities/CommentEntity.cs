using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSPlus.Domain.Entities
{
    public class CommentEntity:BaseEntity
    {
        public string FullName { get; set; } = null;
        public string CommentText { get; set; } = null;
        public int TopicId { get; set; } = 0;
    }
}
