using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori ismi boş bırakılamaz.");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama alanı boş bırakılamaz.");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori isim alanı en az 3 karakterden oluşmalıdır.");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Kategori isim alanı en fazla 20 karakterden oluşmalıdır.");
        }
    }
}
