using System.ComponentModel.DataAnnotations;

namespace UniversityCafeteria.Models
{
    public class RegisterDTO
    {
        [Required]
        public string FullName { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")] // Data annotation
        public string ConfirmPassword { get; set; } = "";
    }
}
