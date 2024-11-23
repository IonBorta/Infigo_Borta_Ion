using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSPlus.Domain.Models.CommentModels
{
    public abstract class BaseCommentModel
    {
        public BaseCommentModel()
        {
            CreatedOnUtc = DateTime.UtcNow;
        }
        public DateTime? CreatedOnUtc { get; set; }
    }
}
