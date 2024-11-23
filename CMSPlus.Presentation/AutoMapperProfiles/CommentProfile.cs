using AutoMapper;
using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Models.CommentModels;

namespace CMSPlus.Presentation.AutoMapperProfiles
{
    public class CommentProfile:Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentEntity, CommentModel>();
            CreateMap<CommentModel, CommentEntity>();
            CreateMap<CommentEntity, DetailsCommentModel>();
            CreateMap<CommentEntity, CreateCommentModel>();
            CreateMap<CreateCommentModel, CommentEntity>();
            CreateMap<CommentEntity, EditCommentModel>();
            CreateMap<EditCommentModel, CommentEntity>();
        }
    }
}
