﻿using System.ComponentModel.DataAnnotations;

namespace ContactManager.Data.Model
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
