using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRule
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().WithMessage("Yazar adı alanı boş geçilemez.");
            RuleFor(c => c.FirstName).MinimumLength(2).WithMessage("Yazar adı alanı en az 2 karakter olmalıdır.");
            RuleFor(c => c.FirstName).MaximumLength(50).WithMessage("Yazar adı alanı en çok 50 karakter olmalıdır.");
            RuleFor(c => c.LastName).NotEmpty().WithMessage("Yazar soyadı alanı boş geçilemez.");
            RuleFor(c => c.LastName).MinimumLength(2).WithMessage("Yazar soyadı alanı en az 2 karakter olmalıdır.");
            RuleFor(c => c.LastName).MaximumLength(50).WithMessage("Yazar soyadı alanı en çok 50 karakter olmalıdır.");
            RuleFor(c => c.Email).NotEmpty().WithMessage("Mail alanı boş geçilemez.");
            RuleFor(c => c.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez.");
            RuleFor(c => c.WriterImage).NotEmpty().WithMessage("Resim alanı boş geçilemez.");
            RuleFor(c => c.Title).NotEmpty().WithMessage("Yazar Ünvanı boş geçilemez.");
            RuleFor(c => c.Title).MinimumLength(3).WithMessage("Yazar Ünvan alanı en az 3 karakter olmalıdır.");
            RuleFor(c => c.About).NotEmpty().WithMessage("Hakkında alanı boş geçilemez.");
            RuleFor(c => c.About).Must(x => x != null && x.ToUpper().Contains("A")).WithMessage("Hakkında alanı en az bir karakter 'A' harfi içermelidir.");

        }
    }
}
