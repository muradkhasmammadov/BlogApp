using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Please enter full name!")]
        public string Fullname { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter your password!")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords didn't match!")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter your email!")]
        public string Email { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter your username!")]
        public string Username { get; set; }
    }
}
