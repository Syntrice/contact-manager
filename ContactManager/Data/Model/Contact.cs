using System.ComponentModel.DataAnnotations;

namespace ContactManager.Data.Model
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = null!;

    }
}
