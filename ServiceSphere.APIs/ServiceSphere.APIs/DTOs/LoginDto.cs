﻿using System.ComponentModel.DataAnnotations;

namespace ServiceSphere.APIs.DTOs
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
