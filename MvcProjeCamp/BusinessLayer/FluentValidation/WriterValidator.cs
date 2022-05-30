using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Girilemez");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadı Boş Girilemez");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında Alanı Boş Girilemez");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Hakkında Alanı Boş Girilemez");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("En Az 2 Karakter Girişi Yapınız");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("En Fazla 50 Karakter Girişi Yapınız");

        }
    }
}
