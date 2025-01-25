using System.ComponentModel.DataAnnotations;

namespace ContactManager.Model
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = null!;

        // Navigation Properties
        public ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();
        public ICollection<EmailAddress> EmailAddresses { get; set; } = new List<EmailAddress>();
    }
}
