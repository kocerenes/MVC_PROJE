using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda kısmını boş geçemezsiniz.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Adınız 2 karakterden az olamaz");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Adınız 50 karakterden fazla olamaz.");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Soyadınız 2 karakterden az olamaz");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Soyadınız 50 karakterden fazla olamaz.");
        }
    }
}
