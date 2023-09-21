using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Areas.Admin.Models
{
    public class AddAdminViewModel
    {
        [Required(ErrorMessage = "Cannot be blank.")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Please enter your password!")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords didn't match!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter your email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your username!")]
        public string Username { get; set; }
    }
}
