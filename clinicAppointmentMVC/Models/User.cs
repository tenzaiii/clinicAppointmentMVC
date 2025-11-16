using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace clinicAppointmentMVC.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}