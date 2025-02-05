using ContactManager.Models;
using FluentValidation;

namespace ContactManager.Models.ContactModel
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(obj => obj.Name).NotEmpty().MaximumLength(100);
        }
    }
}
