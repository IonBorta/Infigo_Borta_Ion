using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSPlus.Domain.Models.CommentModel
{
    public class CreateCommentModel : BaseCommentModel
    {
        public string FullName { get; set; }
        public string CommentText { get; set; }
        public int TopicId { get; set; }
    }
}
