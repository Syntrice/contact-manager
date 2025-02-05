using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models.EmailAddressCategoryModel
{
    public class EmailAddressCategory
    {
        [Key]
        public int EmailAddressCategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Label { get; set; } = null!;

        public static EmailAddressCategory[] GetDefaultEmailAddressCategories()
        {
            return new[]
            {
                new EmailAddressCategory { EmailAddressCategoryId = 1, Label = "Personal" },
                new EmailAddressCategory { EmailAddressCategoryId = 2, Label = "Work" },
                new EmailAddressCategory { EmailAddressCategoryId = 3, Label = "Other" }
            };
        }

    }
}
