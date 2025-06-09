using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.DTOs.AuthenticationDTOs
{
    public class RegisterDto
    {
    //    [Required(ErrorMessage = "Username is required.")]
    //    [MinLength(3, ErrorMessage = "FullNme must be at least 3 characters long.")]
        public string Username { get; set; } = string.Empty;

        //[Required(ErrorMessage = "Username is required.")]
        //[MinLength(3, ErrorMessage = "FullNme must be at least 3 characters long.")]
        //public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Role is required.")]
        [RegularExpression("^(Admin|Student|Teacher)$", ErrorMessage = "Role must be either 'Admin' , 'Student' or Teacher")]
        public string Role { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

    }
}
