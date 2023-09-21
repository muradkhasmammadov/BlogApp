using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator() { 
            RuleFor(x=>x.BlogTitle).NotEmpty().WithMessage("Blog Title can't be blank");
            RuleFor(x=>x.BlogContent).NotEmpty().WithMessage("Blog Content can't be blank");
            RuleFor(x=>x.BlogImage).NotEmpty().WithMessage("Blog Image can't be blank");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Please insert title with max 150 characters");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Please insert title with min 5 characters");
            RuleFor(x => x.BlogContent).MaximumLength(5000).WithMessage("Please insert content with max 5000 characters");
            RuleFor(x => x.BlogContent).MinimumLength(5).WithMessage("Please insert content with min 20 characters");
        }
    }
}
