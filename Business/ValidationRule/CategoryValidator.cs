using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRule
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Kategori alanı boş geçilemez.");
            RuleFor(c => c.Name).MinimumLength(3).WithMessage("Kategori alanı en az 3 karakter olmalıdır.");
            RuleFor(c => c.Name).MaximumLength(20).WithMessage("Kategori alanı en çok 20 karakter olmalıdır.");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez.");

        }
    }
}
