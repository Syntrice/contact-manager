using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactManager.Model
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = null!;

    }
}
