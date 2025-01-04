using ContactManager.Data.Model;
using FluentValidation;

namespace ContactManager.Data.Validation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(obj => obj.Name).NotEmpty().MaximumLength(100);
        }
    }
}
