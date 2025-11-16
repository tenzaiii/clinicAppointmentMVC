using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace clinicAppointmentMVC.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}

//CREATE TABLE[dbo].[Table]
//(
//    [id] INT NOT NULL PRIMARY KEY,
//    [email] VARCHAR(255) UNIQUE NOT NULL,
//    [password] VARCHAR(255) NOT NULL,
//    [created_at] TIMESTAMP DEFAULT CURRENT_TIMESTAMP
//)
