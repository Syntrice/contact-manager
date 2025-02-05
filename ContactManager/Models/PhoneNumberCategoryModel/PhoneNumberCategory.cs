using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models.PhoneNumberCategoryModel
{
    public class PhoneNumberCategory
    {
        [Key]
        public int PhoneNumberCategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Label { get; set; } = null!;

        public static PhoneNumberCategory[] GetDefaultPhoneNumberCategories()
        {
            return new[]
            {
                new PhoneNumberCategory { PhoneNumberCategoryId = 1, Label = "Home" },
                new PhoneNumberCategory { PhoneNumberCategoryId = 2, Label = "Work" },
                new PhoneNumberCategory { PhoneNumberCategoryId = 3, Label = "Mobile" },
                new PhoneNumberCategory { PhoneNumberCategoryId = 4, Label = "Other" }
            };
        }
    }
}
