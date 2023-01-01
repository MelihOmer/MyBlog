using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MyBlog.Services.Extensions
{
    public static class FluentValidationsExtensions
    {
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}

