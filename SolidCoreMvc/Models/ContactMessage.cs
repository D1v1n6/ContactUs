using System;
using System.ComponentModel.DataAnnotations;

namespace SolidCoreMvc.Models
{
    public class ContactMessage
    {
        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime SentAt { get; set; } = DateTime.Now;
    }
}
