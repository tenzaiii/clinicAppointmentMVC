using System.Security.Cryptography;
using System.Text;

namespace clinicAppointmentMVC.Helpers
{
    
        public static class PasswordHelper
        {
            public static string HashPassword(string password)
            {
                using (var sha256 = SHA256.Create())
                {
                    // Add a salt for better security (in production, use a random salt per user)
                    var saltedPassword = password + "YourFixedSalt"; // Change this to your own salt
                    var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                    return Convert.ToBase64String(hashedBytes);
                }
            }

            public static bool VerifyPassword(string password, string hashedPassword)
            {
                var hashOfInput = HashPassword(password);
                return hashOfInput == hashedPassword;
            }
        }
}
