using CMSPlus.Domain.Models.CommentModel;
using FluentValidation;

namespace CMSPlus.Presentation.Validations.CommentValidations
{
    public class CommentCreateValidator:AbstractValidator<CreateCommentModel>
    {
        public CommentCreateValidator()
        {
            RuleFor(comm => comm.FullName)
                .NotEmpty().WithMessage("Full Name is required.");
            RuleFor(comm => comm.CommentText)
                .NotEmpty().WithMessage("Comment text is required.");
        }
    }
}
