using System.ComponentModel.DataAnnotations;

namespace Portfoliowebsite.Models
{
    public class ContactViewModel
    {
        [Required, StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress, StringLength(200)]
        public string Email { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Subject { get; set; }

        [Required, StringLength(2000, MinimumLength = 5)]
        public string Message { get; set; } = string.Empty;

        public string? website { get; set; }
    }
}
