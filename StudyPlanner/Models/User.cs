using System.ComponentModel.DataAnnotations;

namespace StudyPlanner.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
