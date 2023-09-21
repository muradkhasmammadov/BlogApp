using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator() {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Categoey Name cannot be empty!");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Categoey Description cannot be empty!");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Categoey Name cannot be longer than 50 characters!");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Categoey Name cannot be less than 2 characters!");
        }

    }
}
