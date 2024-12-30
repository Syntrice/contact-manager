using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactManager.Model
{
    public class PhoneNumber
    {
        [Key]
        public int PhoneNumberId { get; set; }

        [MaxLength(15)]
        public string Number { get; set; } = null!;

        // Navigation property
        public Contact Contact { get; set; } = null!;

        // Navigation property
        public PhoneNumberCategory Category { get; set; } = null!;
    }
}
