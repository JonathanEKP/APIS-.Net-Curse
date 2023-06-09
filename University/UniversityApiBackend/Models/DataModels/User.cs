﻿using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class User : BaseEntity
    {
        [Required, StringLength(50)]
        public String Name { get; set; } = String.Empty;

        [Required, StringLength(100)]
        public String LastName { get; set; } = String.Empty;

        [Required, EmailAddress]
        public String Email { get; set; } = String.Empty;

        [Required]
        public String Password { get; set; } = String.Empty;





    }
}
