using ContactManager.Model;
using FluentValidation;

namespace ContactManager.Model.Validation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(obj => obj.Name).NotEmpty().MaximumLength(100);
        }
    }
}
