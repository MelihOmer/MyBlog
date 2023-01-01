using FluentValidation;
using MyBlog.Entity.Entities;

namespace MyBlog.Services.FluentValidationsService
{
    public class ArticleValidations : AbstractValidator<Article>
    {
        public ArticleValidations()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithName("Başlık");

            RuleFor(x => x.Content)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithName("İçerik");
        }

    }
}
