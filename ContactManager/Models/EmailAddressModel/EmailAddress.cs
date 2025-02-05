using System.ComponentModel.DataAnnotations;
using ContactManager.Models.ContactModel;
using ContactManager.Models.EmailAddressCategoryModel;

namespace ContactManager.Models.EmailAddressModel
{
    public class EmailAddress
    {
        [Key]
        public int EmailAddressId { get; set; }

        [MaxLength(254)]
        public string Address { get; set; } = null!;

        // Navigation property
        public Contact Contact { get; set; } = null!;

        // Navigation property
        public EmailAddressCategory Category { get; set; } = null!;
    }
}
